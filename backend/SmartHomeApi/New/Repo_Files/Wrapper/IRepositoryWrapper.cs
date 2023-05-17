using SmartHomeApi.New.Repositories;
namespace SmartHomeApi.New.Repositories.Wrapper
{
    public interface IRepositoryWrapper
    {
        AccountRepo Account { get; }

        ThermostatRepo Thermostat { get; }
        ThermostatSensorRepo ThermostatSensor { get; }
        ThermostatActuatorRepo ThermostatActuator { get; }

        SmartBulbRepo SmartBulb  { get; }
        BulbSensorRepo BulbSensor { get; }
        BulbActuatorRepo BulbActuator { get; }

        SmartJalousineRepo SmartJalousine { get; }
        JalousineSensorRepo JalousineSensor { get; }
        JalousineActuatorRepo JalousineActuator { get; }
    }
}