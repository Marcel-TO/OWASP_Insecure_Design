# Backend

The backend for this project has been done with `MySQL` and `ASP.NET CORE 7.0`.

## Database

### MySQL Server

- `Version 8.0.33`

- `Port: 3306`

- `Password: password`

### MySQL Wokbench

- `Version 8.0.33`

### Model/Schema

The database model is as following:

### Tables
**_accounts_**

| account_id | role | username | password |
|:----------:|:----:|:--------:|:--------:|
|     . . .    | . . .  |   . . .    |   . . .    |

**_actuators_**

| actuator_id | name | target_temperature | account_id |
|:----------:|:-----:|:------------------:|:----------:|
|     . . .    |  . . .  |        . . .         |    . . .     |

**_sensors_**


| sensor_id | name | temp | status | account_id |
|:---------:|:----:|:----:|:------:|:----------:|
|     . . .   | . . .  |  . . . |   . . .  |    . . .   |


## API

### Endpoints
Account
Sensor
Actuator
System

