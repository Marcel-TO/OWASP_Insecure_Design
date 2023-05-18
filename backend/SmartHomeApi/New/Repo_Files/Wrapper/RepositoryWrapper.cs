using SmartHomeApi.New.Repositories;
using SmartHomeApi.New.Contexts;
namespace SmartHomeApi.New.Repositories.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private SHDbContext repoContext;
        private AccountRepo account;

        private SmartDevicesRepo smartDevices;
        private ThermostatRepo thermostat;
        private ThermostatSensorRepo thermostatSensor;
        private ThermostatActuatorRepo thermostatActuator;

        private SmartBulbRepo smartBulb;
        private BulbSensorRepo bulbSensor;
        private BulbActuatorRepo bulbActuator;

        private SmartJalousineRepo smartJalousine;
        private JalousineSensorRepo jalousineSensor;
        private JalousineActuatorRepo jalousineActuator;
       
        public AccountRepo Account { get { return this.account; } }

        public SmartDevicesRepo SmartDevices { get { return this.smartDevices; } }

        public ThermostatRepo Thermostat { get { return this.thermostat; } }
        public ThermostatSensorRepo ThermostatSensor { get { return this.thermostatSensor; } }
        public ThermostatActuatorRepo ThermostatActuator { get { return this.thermostatActuator; } }

         
        public SmartBulbRepo SmartBulb  { get { return this.smartBulb; } }
        public BulbSensorRepo BulbSensor  { get { return this.bulbSensor; } }
        public BulbActuatorRepo BulbActuator  { get { return this.bulbActuator; } }


        public SmartJalousineRepo SmartJalousine  { get { return this.smartJalousine; } }
        public JalousineSensorRepo JalousineSensor  { get { return this.jalousineSensor; } }
        public JalousineActuatorRepo JalousineActuator  { get { return this.jalousineActuator; } }


        public RepositoryWrapper(SHDbContext repositoryContext)
        {
            this.repoContext = repositoryContext;
            this.account = new AccountRepo(this.repoContext);

            this.smartDevices = new SmartDevicesRepo(this.repoContext); 

            this.thermostat = new ThermostatRepo(this.repoContext);
            this.thermostatSensor = new ThermostatSensorRepo(this.repoContext);
            this.thermostatActuator = new ThermostatActuatorRepo(this.repoContext);

            this.smartBulb = new SmartBulbRepo(this.repoContext);;
            this.bulbSensor = new BulbSensorRepo(this.repoContext);;
            this.bulbActuator = new BulbActuatorRepo(this.repoContext);;

            this.smartJalousine = new SmartJalousineRepo(this.repoContext);;
            this.jalousineSensor = new JalousineSensorRepo(this.repoContext);;
            this.jalousineActuator = new JalousineActuatorRepo(this.repoContext);;
        }
    }
}