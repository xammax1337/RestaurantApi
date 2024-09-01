# RestaurantApi
## Version: 1.0

### /api/Booking/CreateBooking
#### POST
##### Responses
| 200 | Success |

### /api/Booking/DeleteBooking
#### POST
##### Parameters
int Id
##### Responses
| 200 | Success |

### /api/Booking/GetAllBookings
#### GET
##### Responses
Example:
[
  {
    "id": 1,
    "timeBooked": "2024-08-28T12:19:16.687",
    "customerCount": 1,
    "tableId": 2,
    "table": null,
    "customerId": 2,
    "customer": null
  },

  {
    "id": 2,
    "timeBooked": "2024-09-01T15:30:20.87",
    "customerCount": 4,
    "tableId": 3,
    "table": null,
    "customerId": 2,
    "customer": null
  }
]

| 200 | Success |

### /api/Booking/GetBookingById
#### GET
##### Parameters
int Id
##### Responses
Example:
{
  "id": 1,
  "timeBooked": "2024-08-28T12:19:16.687",
  "customerCount": 1,
  "tableId": 2,
  "table": null,
  "customerId": 2,
  "customer": null
}

| 200 | Success |

### /api/Customer/AddCustomer
#### POST
##### Responses
| 200 | Success |

### /api/Customer/DeleteCustomer
#### POST
##### Parameters
int Id
##### Responses
| 200 | Success |

### /api/Customer/GetAllCustomers
#### GET
##### Responses
Example:
[
  {
    "customerId": 2,
    "firstName": "John",
    "lastName": "Johnsson",
    "email": "john@mail",
    "phoneNumber": "0",
    "bookings": null
  },
  
  {
    "customerId": 3,
    "firstName": "Test",
    "lastName": "Tests",
    "email": "test@mail",
    "phoneNumber": "0",
    "bookings": null
  }
]

| 200 | Success |

### /api/Customer/GetCustomerById
#### GET
##### Parameters
int Id
##### Responses
  {
    "customerId": 2,
    "firstName": "John",
    "lastName": "Johnsson",
    "email": "john@mail",
    "phoneNumber": "0",
    "bookings": null
  }
| 200 | Success |

### /api/Customer/UpdateCustomer
#### POST
##### Responses
| 200 | Success |

### /api/Menu/AddMenuItem
#### POST
##### Responses
| 200 | Success |

### /api/Menu/DeleteMenuItem
#### POST
##### Parameters
int Id
##### Responses
| 200 | Success |

### /api/Menu/GetAllMenuItems
#### GET
##### Responses
Example:
[
  {
    "id": 1,
    "name": "Cheeseburger",
    "description": "Cheeseburger with 200g patty, Onion, Ketchup and Mustard",
    "price": 120,
    "available": true
  },
  
  {
    "id": 3,
    "name": "Ultimate Burger",
    "description": "Epic burger with 300g patty, Onion, Mayonaise, Pickles, Secret Sauce",
    "price": 125,
    "available": false
  }
]

| 200 | Success |

### /api/Menu/GetMenuItemById
#### GET
##### Parameters
int Id
##### Responses
{
  "id": 1,
  "name": "Cheeseburger",
  "description": "Cheeseburger with 200g patty, Onion, Ketchup and Mustard",
  "price": 120,
  "available": true,
  "menus": null
}

| 200 | Success |

### /api/Menu/UpdateMenuItem
#### POST
##### Parameters
int Id
##### Responses
| 200 | Success |

### /api/Table/AddTable
#### POST
##### Responses
| 200 | Success |

### /api/Table/DeleteTable
#### POST
##### Parameters
int Id
##### Responses
| 200 | Success |

### /api/Table/GetAllTables

#### GET
##### Responses
Example:
[
  {
    "tableId": 2,
    "tableNumber": 25,
    "seats": 2,
    "available": false,
    "booking": null
  },
  
  {
    "tableId": 3,
    "tableNumber": 12,
    "seats": 5,
    "available": false,
    "booking": null
  }
]

| 200 | Success |
