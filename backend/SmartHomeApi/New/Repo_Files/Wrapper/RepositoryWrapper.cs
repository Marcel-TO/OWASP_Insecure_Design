using SmartHomeApi.New.Repositories;
using SmartHomeApi.New.Contexts;
namespace SmartHomeApi.New.Repositories.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private SHDbContext _repoContext;
        private AccountRepo _account;
        private ThermostatRepo _thermostat;
        private ThermostatSensorRepo _thermostatSensor;
        private ThermostatActuatorRepo _thermostatActuator;
       
        public AccountRepo Account {
            get 
            {
                if(_account == null)
                {
                    _account = new AccountRepo(this._repoContext);
                }
                return _account;
            }
        }

        public ThermostatRepo Thermostat {
            get 
            {
                if(_thermostat == null)
                {
                    _thermostat = new ThermostatRepo(this._repoContext);
                }
                return _thermostat;
            }
        }

        public ThermostatSensorRepo ThermostatSensor {
            get 
            {
                if(_thermostatSensor == null)
                {
                    _thermostatSensor = new ThermostatSensorRepo(this.logger, this._repoContext);
                }
                return _thermostatSensor;
            }
        }

        public ThermostatActuatorRepo ThermostatActuator {
            get 
            {
                if(_thermostatActuator == null)
                {
                    _thermostatActuator = new ThermostatActuatorRepo(this.logger, this._repoContext);
                }
                return _thermostatActuator;
            }
        }

        private readonly ILogger logger;

        public RepositoryWrapper(ILogger logger, SHDbContext repositoryContext)
        {
            this.logger = logger;
            this._repoContext = repositoryContext;
            this._account = new AccountRepo(this._repoContext); 
            this._thermostat = new ThermostatRepo(this._repoContext);
            this._thermostatSensor = new ThermostatSensorRepo(this.logger,this._repoContext);
            this._thermostatActuator = new ThermostatActuatorRepo(this.logger,this._repoContext);
        }
    }
}