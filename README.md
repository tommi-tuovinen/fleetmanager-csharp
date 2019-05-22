# FleetManager - programming assignment
Forked from https://github.com/eatechoy/fleetmanager-csharp.

## Database
Application uses MongoDB. Two databases named FleetManagerDB and FleetManagerTestDB (for tests), are created automatically (if they don't exist). By default application tries to connect to `mongodb://localhost:27017` (as specified in appsettings.json).

CSV-file named car.csv in seed_data folder can be used to seed the database. Note that you should convert values of "year" field to integer. Otherwise query for finding cars in specific year range won't return them.

## API documentation
When application is running Swagger documentation can be found in following url: 
`<base address>/swagger`

## TODO
* Searching with id that is not valid as a Bson ObjectId should result in 422 HTTP status code instead of an internal server error.
* More unit tests.
