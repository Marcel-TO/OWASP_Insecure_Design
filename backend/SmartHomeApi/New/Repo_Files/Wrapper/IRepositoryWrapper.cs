using SmartHomeApi.New.Repositories;
namespace SmartHomeApi.New.Repositories.Wrapper
{
    public interface IRepositoryWrapper
    {
        AccountRepo Account { get; }
        ThermostatRepo Thermostat { get; }
        ThermostatSensorRepo ThermostatSensor { get; }

    }
}