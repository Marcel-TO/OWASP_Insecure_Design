using SmartHomeApi.Api_Source_Code.Repositories;
namespace SmartHomeApi.Api_Source_Code.Repositories.Wrapper
{
    public interface IRepositoryWrapper
    {
        AccountRepo Account { get; }
        LoggedDataRepo LoggedData { get; }
        SmartDevicesRepo SmartDevices { get; }

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