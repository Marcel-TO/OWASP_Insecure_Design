# Backend

The backend for this project has been done with `MySQL` and `ASP.NET CORE 7.0`.

## Database
### Installation
#### MySQL Server

- `Version 8.0.33`

- `Port: 3306`

- `Password: password`

#### MySQL Wokbench

- `Version 8.0.33`

### Model/Schema

The database model is as following:

### Tables
**_accounts_**

| account_id | role | username | password |
|:----------:|:----:|:--------:|:--------:|
|     . . .    | . . .  |   . . .    |   . . .    |

**_thermostats_**
| thermostat_id | acc_id |
|:----------:|:----:|
|     . . .    | . . .  | 

**_thermostat_sensors_**

| sensor_id | name | status | temperature |  actuator_id |  therm_id |
|:----------:|:-----:|:------------------:|:----------:|:----------:|:----------:|
|     . . .    |  . . .  |        . . .         |    . . .     |  . . .     |  . . .     |

**_thermostat_actuators_**

| actuator_id | name | status | target_temperature | sensor_id | therm_id |
|:----------:|:-----:|:------------------:|:----------:|:----------:|:----------:|
|     . . .    |  . . .  |        . . .         |    . . .     ||        . . .         |    . . .     |



**_light_bulbs_**
| smartbulb_id | acc_id |
|:----------:|:----:|
|     . . .    | . . .  | 

**_bulb_sensors_**

| sensor_id | name | status | brightness |  actuator_id |  bulb_id | therm_id |
|:----------:|:-----:|:------------------:|:----------:|:----------:|:----------:|:----------:|
|     . . .    |  . . .  |        . . .         |    . . .     |  . . .     |  . . .     |  . . .     |

**_bulb_actuators_**

| actuator_id | name | status | target_brightness | sensor_id | bulb_id | therm_id |
|:----------:|:-----:|:------------------:|:----------:|:----------:|:----------:|:----------:|
|     . . .    |  . . .  |        . . .         |    . . .     ||        . . .         |    . . .     |   . . .     |





**_jalousines_**
| jalousine_id | acc_id |
|:----------:|:----:|
|     . . .    | . . .  | 

**_jalousine_sensors_**

| sensor_id | name | status | state |  actuator_id |  jal_id |
|:----------:|:-----:|:------------------:|:----------:|:----------:|:----------:|
|     . . .    |  . . .  |        . . .         |    . . .     |  . . .     |  . . .     |

**_jalousine_actuator_**

| actuator_id | name | status | target_state | sensor_id | jal_id |
|:----------:|:-----:|:------------------:|:----------:|:----------:|:----------:|
|     . . .    |  . . .  |        . . .         |    . . .     ||        . . .         |    . . .     |

### Migration
Classes/entities have been declared in the .NET-project. Running the migration command via EF Core creates the correspondnig rows/entities.
Steps for migrating the database via Visual Studio Code (For Visual Studio or more info: https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=vs):

**1. Adding migration**
`dotnet ef migrations add InitialCreate`

**2. Adding MySql database to corresponding migration**
`dotnet ef database update`

## API

### Endpoints
- **_SmartDevices_**

- **_Account_**

- **_Thermostat_**
- **_ThermostatActuator_**
- **_ThermostatSensor_**

- **_SmartBulb_**
- **_BulbActuator_**
- **_BulbSensor_**

- **_SmartJalousine_**
- **_JalousineActuator_**
- **_JalousineSensor_**

