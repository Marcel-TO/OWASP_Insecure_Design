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

| account_id | role  | username | password |
| :--------: | :---: | :------: | :------: |
|   . . .    | . . . |  . . .   |  . . .   |

**_thermostats_**
| thermostat_id | acc_id |
|:----------:|:----:|
| . . . | . . . |

**_thermostat_sensors_**

| sensor_id | name  | status | temperature | actuator_id | therm_id |
| :-------: | :---: | :----: | :---------: | :---------: | :------: |
|   . . .   | . . . | . . .  |    . . .    |    . . .    |  . . .   |

**_thermostat_actuators_**

| actuator_id | name  | status | target_temperature | sensor_id | therm_id |
| :---------: | :---: | :----: | :----------------: | :-------: | :------: | ----- |
|    . . .    | . . . | . . .  |       . . .        |   . . .   |  . . .   | . . . |

**_light_bulbs_**
| smartbulb_id | acc_id |
|:----------:|:----:|
| . . . | . . . |

**_bulb_sensors_**

| sensor_id | name  | status | brightness | actuator_id | bulb_id |
| :-------: | :---: | :----: | :--------: | :---------: | :-----: |
|   . . .   | . . . | . . .  |   . . .    |    . . .    |  . . .  |

**_bulb_actuators_**

| actuator_id | name  | status | target_brightness | sensor_id | bulb_id |
| :---------: | :---: | :----: | :---------------: | :-------: | :-----: | ----- |
|    . . .    | . . . | . . .  |       . . .       |   . . .   |  . . .  | . . . |

**_jalousines_**
| jalousine_id | acc_id |
|:----------:|:----:|
| . . . | . . . |

**_jalousine_sensors_**

| sensor_id | name  | status | state | actuator_id | jal_id |
| :-------: | :---: | :----: | :---: | :---------: | :----: |
|   . . .   | . . . | . . .  | . . . |    . . .    | . . .  |

**_jalousine_actuator_**

| actuator_id | name  | status | target_state | sensor_id | jal_id |
| :---------: | :---: | :----: | :----------: | :-------: | :----: | ----- |
|    . . .    | . . . | . . .  |    . . .     |    . . .  | . . .  | . . . |

### Migration

Classes/entities have been declared in the .NET-project. Running the migration command via EF Core creates the correspondnig rows/entities.
Steps for migrating the database via Visual Studio Code (For Visual Studio or more info: https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=vs):

(Within the project folder "SmartHomeApi")

**1. Adding migration**

`dotnet ef migrations add InitialCreate`

**2. Adding MySql database to corresponding migration**

`dotnet ef database update`

## API (REST)

PLEASE READ FOLLOWING RELEVANT INFO:

Running on `localhost` with Swagger UI. Example: `http://localhost:5274/swagger/index.html`.

Reponse: HTTP-Response with data. Example: `OK()` and `body` containing the data

Request: All the requests should work the same if there is no example given.

**_INSERTING/DELETIONS ETC. OF DEVICES A SMART DEVICE (Thermostat etc.)_**

CAN ONLY BE CREATED FOR AN EXISTING ACCOUNT-HOLDER.

A SENSOR/ACTUATOR (such as thermostat-sensor etc.) CAN ONLY BE **CREATED** FOR ITS CORRESPONDING EXISTING SMART DEVICE.

THE DEFAULT GUID IS: **00000000-0000-0000-0000-000000000000**.

Account objects need to be **null** within **json request body** of other objects (See example thermostat etc.) -> "account": null,

### Endpoints

header:

### SmartDevices

- **_GET: /api/devices/byUserId/getById -> Gets all smart devices by accountid_**

Example: http://localhost:5274/api/devices/byUserId/getById?id=a14da44c-b379-4db9-adbd-51ee6c9fb65e

### Accounts

- **_GET: /api/account -> Gets all accounts_**
- **_POST: /api/account/create -> Create a new accounts_**

Example:

header:

body:

{

"account_Id": "00000000-0000-0000-0000-000000000000",

"role": "admin",

"userName": "chris",

"password": "1234"

}

- **_DELETE: /api/account/delete -> Deletes an account_**

Example: http://localhost:5274/api/account/delete?id=a14da44c-b379-4db9-adbd-51ee6c9fb65e

- **_PUT: /api/account/update -> Updates an account_**

Example-body:

{

"account_Id": "3e5de7f1-09bd-4351-90b7-285f05651402",

"role": "chris",

"userName": "admin",

"password": ""

}

- **_POST: /api/account/login -> Inserts the new account (Request: Login object) and returns the inserted accounts id_**

Example-body:

{

"userName": "walter",

"password": "1234"

}

RETURNS YOU ID OF LOGGED IN USER AND OK RESPONSE

### LoggedData

- **_GET: /api/log -> Gets all logged entries_**
- \*_\_GET: /api/log/getById -> Gets a logged entry by its id_
- **\_GET: /api/log/getByAccountId -> Gets all logged entries matching an account id**
- **_POST: /api/log/create -> Create an logged entry_**

Example-body:

{

"log_Id": "00000000-0000-0000-0000-000000000000",

"data": "Some logged data",

"acc_Id": "43572ee6-61b3-405e-980e-352907c2e2a7",

"account": null

}

- **\_DELETE: /api/log/delete -> Deletes an logged entry**

---

### Thermostat

- **_GET: /api/log -> Gets all thermostats_**
- **\_GET: /api/log/getById -> Gets a thermostat by its id**
- **_POST: /api/thermostat/create -> Create a new thermostat_**

Example-body:

{

"thermostat_Id": "00000000-0000-0000-0000-000000000000",

"acc_Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",

"account": null,

"sensors": [],

"actuators": []

}

- **_DELETE: /api/thermostat/delete -> Deletes a thermostat and its children_**

### ThermostatActuator

- **_GET: /api/thermostat/actuator -> Gets all thermostat actuators_**
- **_POST: /api/thermostat/actuator/create -> Create a new thermostat actuator_**
  Example-body:

{

"actuator_Id": "00000000-0000-0000-0000-000000000000",

"name": "string",

"status": "string",

"target_Temperature": 0,

"sensor_Id": "00000000-0000-0000-0000-000000000000",

"therm_Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",

"thermostat": null

}

SENSOR ID DOESN'T HAVE TO BE DEFAULT

- **_GET: /api/thermostat/actuator/getById -> Gets a thermostat actuator by its id_**
- **_DELETE: /api/thermostat/actuator/delete -> Deletes a thermostat actuator_**
- **_PUT: /api/thermostat/actuator/update -> Updates a thermostat actuator_**

Example-body: SAME AS POST-REQUEST (Create)

### ThermostatSensor

- **_GET: /api/thermostat/sensor -> Gets all thermostat sensors_**
- **_POST: /api/thermostat/sensor/create -> Create a new thermostat sensor_**

Example-body:

{

"sensor_Id": "00000000-0000-0000-0000-000000000000",

"name": "string",

"status": "string",

"temperature": 0,

"actuator_Id": "00000000-0000-0000-0000-000000000000",

"therm_Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",

"thermostat": null

}

- **_GET: /api/thermostat/sensor/getById -> Gets a thermostat sensor by its id_**
- **_DELETE: /api/thermostat/sensor/delete -> Deletes a thermostat sensor_**
- **_PUT: /api/thermostat/sensor/update -> Updates a thermostat sensor_**

## Example-body: SAME AS POST-REQUEST (Create)

### SmartBulb

- **_GET: /api/bulb -> Gets all bulbs_**
- **_GET: /api/bulb/getById -> Gets a bulb by its id_**
- **_POST: /api/bulb/create -> Create a new bulb_**
- **_DELETE: /api/bulb/delete -> Deletes a bulb and its children_**

Example-body:

{

"smartbulb_Id": "00000000-0000-0000-0000-000000000000",

"acc_Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",

"account": null,

"sensors": [],

"actuators": []

}

###BulbActuator

- **_GET: /api/bulb/actuator -> Gets all bulb actuators_**
- **_POST: /api/bulb/actuator/create -> Create a new bulb actuator_**

Example-body:

{

"actuator_Id": "00000000-0000-0000-0000-000000000000",

"name": "string",

"status": "string",

"target_Brightness": 0,

"sensor_Id": "00000000-0000-0000-0000-000000000000",

"bulb_Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",

"smartBulb": null

}

- **_GET: /api/bulb/actuator/getById -> Gets a bulb actuator by its id_**
- **_DELETE: /api/bulb/actuator/delete -> Deletes a bulb actuator_**
- **_PUT: /api/bulb/actuator/update -> Updates a bulb actuator_**

Example-body: SAME AS POST-REQUEST (Create)

### BulbSensor

- **_GET: /api/bulb/sensor -> Gets all bulb sensors_**
- **_POST: /api/bulb/sensor/create -> Create a new bulb sensor_**

Example-body:

{

"sensor_Id": "00000000-0000-0000-0000-000000000000",

"name": "string",

"status": "string",

"brightness": 0,

"actuator_Id": "00000000-0000-0000-0000-0000000000006",

"bulb_Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",

"smartBulb": null

}

- **_GET: /api/bulb/sensor/getById -> Gets a bulb sensor by its id_**
- **_DELETE: /api/bulb/sensor/delete -> Deletes a bulb sensor_**
- **_PUT: /api/bulb/sensor/update -> Updates a bulb sensor_**

Example-body: SAME AS POST-REQUEST (Create)

---

### SmartJalousine

- **_GET: /api/jalousine -> Gets all jalousines_**
- **_GET: /api/jalousine/getById -> Gets a jalousine by its id_**
- **_POST: /api/jalousine/create -> Create a new jalousine_**

Example-body:

{

"jalousine_Id": "00000000-0000-0000-0000-000000000000",

"acc_Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",

"account": null,

"sensors": [],

"actuators": []

}

- **_DELETE: /api/jalousine/delete -> Deletes a jalousine and its children_**

### JalousineActuator

- **_GET: /api/jalousine/actuator -> Gets all jalousine actuators_**
- **_POST: /api/jalousine/actuator/create -> Create a new jalousine actuator_**

Example-body:

{

"actuator_Id": ""00000000-0000-0000-0000-000000000000",

"name": "string",

"status": "string",

"target_State": 0,

"sensor_Id": ""00000000-0000-0000-0000-000000000000",

"jal_Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",

"smartJalousine": null

}

- **_GET: /api/jalousine/actuator/getById -> Gets a jalousine actuator by its id_**
- **_DELETE: /api/jalousine/actuator/delete -> Deletes a jalousine actuator_**
- **_PUT: /api/jalousine/actuator/update -> Updates a jalousine actuator_**

Example-body: SAME AS POST-REQUEST (Create)

### JalousineSensor

- **_GET: /api/jalousine/sensor -> Gets all jalousine sensors_**
- **_POST: /api/jalousine/sensor/create -> Create a new jalousine sensor_**

Example-body:

{

"sensor_Id": ""00000000-0000-0000-0000-000000000000",

"name": "string",

"status": "string",

"state": "string",

"actuator_Id": ""00000000-0000-0000-0000-000000000000",

"jal_Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",

"smartJalousine": null

}

- **_GET: /api/jalousine/sensor/getById -> Gets a jalousine sensor by its id_**
- **_DELETE: /api/jalousine/sensor/delete -> Deletes a jalousine sensor_**
- **_PUT: /api/jalousine/sensor/update -> Updates a jalousine sensor_**

Example-body: SAME AS POST-REQUEST (Create)

## Running the project

Go to the solution folder `backend` and open the `SmartHomeApi` project. Run the project after successfully migrating the database with `dotnet run`.
