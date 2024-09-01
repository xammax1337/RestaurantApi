# RestaurantApi
## Version: 1.0

### /api/Booking/CreateBooking

#### POST
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Booking/DeleteBooking

#### POST
##### Parameters
int Id
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Booking/GetAllBookings

#### GET
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Booking/GetBookingById

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | query |  | No | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Booking/GetBookingByCustomer

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| name | query |  | No | string |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Booking/GetBookingByTable

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| tableNumber | query |  | No | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Customer/AddCustomer

#### POST
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Customer/DeleteCustomer

#### POST
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | query |  | No | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Customer/GetAllCustomers

#### GET
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Customer/GetCustomerById

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | query |  | No | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Customer/UpdateCustomer

#### POST
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Menu/AddMenuItem

#### POST
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Menu/DeleteMenuItem

#### POST
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | query |  | No | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Menu/GetAllMenuItems

#### GET
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Menu/GetMenuItemById

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | query |  | No | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Menu/UpdateMenuItem

#### POST
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | query |  | No | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Table/AddTable

#### POST
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Table/DeleteTable

#### POST
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| tableId | query |  | No | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Table/GetAllTables

#### GET
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |
