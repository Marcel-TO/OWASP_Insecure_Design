using SmartHomeApi.New.Repositories;
namespace SmartHomeApi.New.Repositories.Wrapper
{
    public interface IRepositoryWrapper
    {
        IAccountRepo Account { get; }
        void Save();
    }
}