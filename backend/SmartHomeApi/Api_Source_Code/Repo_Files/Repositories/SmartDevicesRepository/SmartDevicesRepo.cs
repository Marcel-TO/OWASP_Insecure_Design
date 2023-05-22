
using Microsoft.EntityFrameworkCore;

using MySql.Data;
using MySqlConnector;

using SmartHomeApi.Api_Source_Code.Models;
using SmartHomeApi.Api_Source_Code.Contexts;

namespace SmartHomeApi.Api_Source_Code.Repositories;
public class SmartDevicesRepo
{
    private SHDbContext context;
    public SmartDevicesRepo(SHDbContext context){
        this.context = context;
    }

    public SmartDevices GetDevicesById(string id)
    {     
        var thermostats = this.context.Thermostats.Where(t=> t.Acc_Id == id)
        .Include(i => i.Sensors)
        .Include(i => i.Actuators).ToList();     
        
        var bulbs = this.context.SmartBulbs.Where(b => b.Acc_Id == id)
        .Include(i => i.Sensors)
        .Include(i => i.Actuators).ToList();     

        var jalousines = this.context.SmartJalousines.Where(j => j.Acc_Id == id)
         .Include(i => i.Sensors)
         .Include(i => i.Actuators).ToList();

        var devices = new SmartDevices(thermostats,bulbs,jalousines);
        return devices;
    }
}