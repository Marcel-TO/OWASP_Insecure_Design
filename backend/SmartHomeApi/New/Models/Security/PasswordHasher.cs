using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;

namespace SmartHomeApi.New.Models;
public class PasswordHasher
{
    private readonly PasswordHasherCompatibilityMode _compatibilityMode;
    private readonly int _iterCount;
    private readonly RandomNumberGenerator _rng;

    private static readonly PasswordHasherOptions DefaultOptions = new PasswordHasherOptions();

    public PasswordHasher()
    {
        
        var options = DefaultOptions;
        
        _compatibilityMode = options.CompatibilityMode;
        switch (_compatibilityMode)
        {
            case PasswordHasherCompatibilityMode.IdentityV2:
                // nothing else to do
                break;

            case PasswordHasherCompatibilityMode.IdentityV3:
                _iterCount = options.IterationCount;
               break;
          
        }

        _rng = RandomNumberGenerator.Create();
    }

    private static bool ByteArraysEqual(byte[] a, byte[] b)
    {
        if (a == null && b == null)
        {
            return true;
        }
        if (a == null || b == null || a.Length != b.Length)
        {
            return false;
        }
        var areSame = true;
        for (var i = 0; i < a.Length; i++)
        {
            areSame &= (a[i] == b[i]);
        }
        return areSame;
    }


     public virtual string HashPassword(string password)
    {
        if(password == null){
            throw new ArgumentNullException("password empty");
        }

        if (_compatibilityMode == PasswordHasherCompatibilityMode.IdentityV2)
        {
            return Convert.ToBase64String(HashPasswordV2(password, _rng));
        }
        else
        {
            return Convert.ToBase64String(HashPasswordV3(password, _rng));
        }
    }

    private static byte[] HashPasswordV2(string password, RandomNumberGenerator rng)
    {
        const KeyDerivationPrf Pbkdf2Prf = KeyDerivationPrf.HMACSHA1; // default for Rfc2898DeriveBytes
        const int Pbkdf2IterCount = 1000; // default for Rfc2898DeriveBytes
        const int Pbkdf2SubkeyLength = 256 / 8; // 256 bits
        const int SaltSize = 128 / 8; // 128 bits

        // Produce a version 2 (see comment above) text hash.
        byte[] salt = new byte[SaltSize];
        rng.GetBytes(salt);
        byte[] subkey = KeyDerivation.Pbkdf2(password, salt, Pbkdf2Prf, Pbkdf2IterCount, Pbkdf2SubkeyLength);

        var outputBytes = new byte[1 + SaltSize + Pbkdf2SubkeyLength];
        outputBytes[0] = 0x00; // format marker
        Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
        Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, Pbkdf2SubkeyLength);
        return outputBytes;
    }

    private byte[] HashPasswordV3(string password, RandomNumberGenerator rng)
    {
        return HashPasswordV3(password, rng,
            prf: KeyDerivationPrf.HMACSHA512,
            iterCount: _iterCount,
            saltSize: 128 / 8,
            numBytesRequested: 256 / 8);
    }

    private static byte[] HashPasswordV3(string password, RandomNumberGenerator rng, KeyDerivationPrf prf, int iterCount, int saltSize, int numBytesRequested)
    {
        // Produce a version 3 (see comment above) text hash.
        byte[] salt = new byte[saltSize];
        rng.GetBytes(salt);
        byte[] subkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, numBytesRequested);

        var outputBytes = new byte[13 + salt.Length + subkey.Length];
        outputBytes[0] = 0x01; // format marker
        WriteNetworkByteOrder(outputBytes, 1, (uint)prf);
        WriteNetworkByteOrder(outputBytes, 5, (uint)iterCount);
        WriteNetworkByteOrder(outputBytes, 9, (uint)saltSize);
        Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
        Buffer.BlockCopy(subkey, 0, outputBytes, 13 + saltSize, subkey.Length);
        return outputBytes;
    }

    public virtual PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
    {
         if(hashedPassword == null){
            throw new ArgumentNullException(hashedPassword);
        }
         if(providedPassword == null){
            throw new ArgumentNullException(providedPassword);
        }
       

        byte[] decodedHashedPassword = Convert.FromBase64String(hashedPassword);

        // read the format marker from the hashed password
        if (decodedHashedPassword.Length == 0)
        {
            return PasswordVerificationResult.Failed;
        }
        switch (decodedHashedPassword[0])
        {
            case 0x00:
                if (VerifyHashedPasswordV2(decodedHashedPassword, providedPassword))
                {
                    // This is an old password hash format - the caller needs to rehash if we're not running in an older compat mode.
                    return (_compatibilityMode == PasswordHasherCompatibilityMode.IdentityV3)
                        ? PasswordVerificationResult.SuccessRehashNeeded
                        : PasswordVerificationResult.Success;
                }
                else
                {
                    return PasswordVerificationResult.Failed;
                }

            case 0x01:
                if (VerifyHashedPasswordV3(decodedHashedPassword, providedPassword, out int embeddedIterCount, out KeyDerivationPrf prf))
                {
                    // If this hasher was configured with a higher iteration count, change the entry now.
                    if (embeddedIterCount < _iterCount)
                    {
                        return PasswordVerificationResult.SuccessRehashNeeded;
                    }

                    // V3 now requires SHA512. If the old PRF is SHA1 or SHA256, upgrade to SHA512 and rehash.
                    if (prf == KeyDerivationPrf.HMACSHA1 || prf == KeyDerivationPrf.HMACSHA256)
                    {
                        return PasswordVerificationResult.SuccessRehashNeeded;
                    }

                    return PasswordVerificationResult.Success;
                }
                else
                {
                    return PasswordVerificationResult.Failed;
                }

            default:
                return PasswordVerificationResult.Failed; // unknown format marker
        }
    }

    private static bool VerifyHashedPasswordV2(byte[] hashedPassword, string password)
    {
        const KeyDerivationPrf Pbkdf2Prf = KeyDerivationPrf.HMACSHA1; // default for Rfc2898DeriveBytes
        const int Pbkdf2IterCount = 1000; // default for Rfc2898DeriveBytes
        const int Pbkdf2SubkeyLength = 256 / 8; // 256 bits
        const int SaltSize = 128 / 8; // 128 bits

        // We know ahead of time the exact length of a valid hashed password payload.
        if (hashedPassword.Length != 1 + SaltSize + Pbkdf2SubkeyLength)
        {
            return false; // bad size
        }

        byte[] salt = new byte[SaltSize];
        Buffer.BlockCopy(hashedPassword, 1, salt, 0, salt.Length);

        byte[] expectedSubkey = new byte[Pbkdf2SubkeyLength];
        Buffer.BlockCopy(hashedPassword, 1 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);

        // Hash the incoming password and verify it
        byte[] actualSubkey = KeyDerivation.Pbkdf2(password, salt, Pbkdf2Prf, Pbkdf2IterCount, Pbkdf2SubkeyLength);
  
        return CryptographicOperations.FixedTimeEquals(actualSubkey, expectedSubkey);

    }

    private static bool VerifyHashedPasswordV3(byte[] hashedPassword, string password, out int iterCount, out KeyDerivationPrf prf)
    {
        iterCount = default(int);
        prf = default(KeyDerivationPrf);

        try
        {
            // Read header information
            prf = (KeyDerivationPrf)ReadNetworkByteOrder(hashedPassword, 1);
            iterCount = (int)ReadNetworkByteOrder(hashedPassword, 5);
            int saltLength = (int)ReadNetworkByteOrder(hashedPassword, 9);

            // Read the salt: must be >= 128 bits
            if (saltLength < 128 / 8)
            {
                return false;
            }
            byte[] salt = new byte[saltLength];
            Buffer.BlockCopy(hashedPassword, 13, salt, 0, salt.Length);

            // Read the subkey (the rest of the payload): must be >= 128 bits
            int subkeyLength = hashedPassword.Length - 13 - salt.Length;
            if (subkeyLength < 128 / 8)
            {
                return false;
            }
            byte[] expectedSubkey = new byte[subkeyLength];
            Buffer.BlockCopy(hashedPassword, 13 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);

            // Hash the incoming password and verify it
            byte[] actualSubkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, subkeyLength);

            return CryptographicOperations.FixedTimeEquals(actualSubkey, expectedSubkey);
        }
        catch
        {
            // This should never occur except in the case of a malformed payload, where
            // we might go off the end of the array. Regardless, a malformed payload
            // implies verification failed.
            return false;
        }
    }

    private static uint ReadNetworkByteOrder(byte[] buffer, int offset)
    {
        return ((uint)(buffer[offset + 0]) << 24)
            | ((uint)(buffer[offset + 1]) << 16)
            | ((uint)(buffer[offset + 2]) << 8)
            | ((uint)(buffer[offset + 3]));
    }

    private static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
    {
        buffer[offset + 0] = (byte)(value >> 24);
        buffer[offset + 1] = (byte)(value >> 16);
        buffer[offset + 2] = (byte)(value >> 8);
        buffer[offset + 3] = (byte)(value >> 0);
    }
}