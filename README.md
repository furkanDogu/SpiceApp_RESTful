# SpiceApp_RESTful
SpiceApp_RESTful is web API of SpiceApp project. It consists of 6 routes;
  - Brand
  - Car
  - Rent
  - Report
  - Reservation
  - User

##Brand Route
1. **GET: api/Brand** : Brings all brands available.
2. **POST: api/Brand**: Adds a new brand.
3. **PUT: api/Brand**: Updates an existing brand.
4. **GET: api/Brand/{id}**: Fetches the brand with given id.
------------
##Car Route
1.  **GET: api/Car/Company/{id}**: Fetches all cars of the company with given id.
2. **POST: api/Car**: Adds a new car.
3. **GET: api/Car/{id}**: Fetches the car with given id.
4. **DELETE: api/Car/{id}**: Deletes the car with given id.
5. **GET: api/Car/Activate/{id}**:Reactivates the deleted car.
6. **PUT: api/Car**: Updates information of given car.
------------
##Rent Route
1. **GET: api/Rent/CompleteRez/{id}**: Completes the reservation with given id.
2. **GET: api/Rent/{id}**: Fetches details of rent with given id.
3. **GET: api/Rent/GetByCst/{id}**: Fetches all rent details of a customer with given id.
4. **POST: api/Rent**: Returns the car to the company.
------------
##Report Route
1. **GET: api/Report/DailyKm/{id}**: Fetches all km daily information of the company whose manager id is given. 
2. **GET: api/Report/Balance/{id}**: Fetches balance and properties of the company whose manager id is given.
3. **GET: api/Report/DailyKmByRent/{Id}/{rentId}**: Fetches detailed km information of the given rent id in the company whose manager id is given.
4. **GET: api/Report/OverKm/{id}**:  Fetches monthly going over km rate of all the cars the company whose manager id is given. 
5. **GET: api/Report/MonthlyRent/{id}/{ticks}**: Fetches rent rates of given date (as ticks) of the company whose manager id is given.
------------
##Reservation Route
1. **GET: api/Reservation/Available/{id}/{sTicks}/{eTicks}**: Fetches all available reservation options for the user with given id for the dates between sTicks - eTicks (dates as ticks)
2. **GET: api/Reservation/{id}**: Fetches all reservations of the user with given id.
3. **POST: api/Reservation**:  Makes a new reservation.
4. **DELETE: api/Reservation/{id}**: Cancels the reservation with given id.
------------
##User Route
1. **POST: api/User/Login**: Logs in the user
2. **POST: api/User/Register**: Registers the user to the app.
3. **GET: api/User**: Fetches all the customers in app.
4. **PUT: api/User**: Updates user information.
