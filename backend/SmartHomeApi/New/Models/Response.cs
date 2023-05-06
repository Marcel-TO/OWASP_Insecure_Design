using InsecureDesignClassLib;
namespace SmartHomeApi.New.Models;
public class Response<T> :IResponse<T>
{
    public T Value{get;set;}
    public bool Success{get;set;}
    public string Message{get;set;}
    public Response(T value, bool success, string message){
        this.Value = value;
        this.Success = success;
        this.Message = message;
    }
}