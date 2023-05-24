
namespace SmartHomeApi.Api_Source_Code.Models;

public static class Mapper
{
    public static IEnumerable<DT_Account> MapAccounts(IEnumerable<Account> accounts)
    {
        List<DT_Account> mappedAccounts = new List<DT_Account>();
        foreach(var acc in accounts)
        {
            mappedAccounts.Add(new DT_Account(acc.Account_Id,acc.Role,acc.UserName,string.Empty));
        }
        return mappedAccounts;
    }
}