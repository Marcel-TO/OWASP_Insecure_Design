using System.Collections;
namespace SmartHomeApi.Api_Source_Code.Models.SystemModel;
public class MySystem{
    public List<Sensor> StoredSensors{get;set;}
    public List<Actuator> StoredActuators{get;set;}
    public MySystem(List<Sensor>storedSensors, List<Actuator>storedActuators){
        this.StoredSensors = storedSensors;
        this.StoredActuators = storedActuators;
    }
}