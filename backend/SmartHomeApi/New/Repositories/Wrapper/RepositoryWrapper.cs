using SmartHomeApi.New.Repositories;
using SmartHomeApi.New.Contexts;
namespace SmartHomeApi.New.Repositories.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private SHDbContext _repoContext;
        private IAccountRepo _account;
       
        public IAccountRepo Account {
            get 
            {
                if(_account == null)
                {
                    _account = new AccountRepo(_repoContext);
                }
                return _account;
            }
        }
        public RepositoryWrapper(SHDbContext repositoryContext)
        {
            this._repoContext = repositoryContext;
        }
        public void Save()
        {
            this._repoContext.SaveChanges();
        }
    }
}