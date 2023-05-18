namespace InsecureDesignClassLib;
public interface IResponse<T>
{
    T Value{get;set;}
    bool Success{get;set;}
    string Message{get;set;}
}
