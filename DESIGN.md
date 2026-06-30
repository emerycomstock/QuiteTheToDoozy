## Design

### Data Structures

#### ToDo record

|**Field**|**Type**|**Description**|**Required**|
|--|--|--|--|
|id|Integer|Unique, service-assigned identifier, non-secret|Yes|
|title|Unicode String|Short free text describing the ToDo, max 256 characters|Yes|
|description|Unicode String|Longer free text describing the ToDo in more detail, max 2048 characters|No|
|status|Integer|Represents enum, one of: "Not Started", "In Progress", "Completed", or "Abandoned"|Yes|
|ownerId|Unicode String|Foreign key referring to user that owns the record|Yes|
|createdAt|Integer Timestamp|Creation time as Unix epoch timestamp|Yes|
|updatedAt|Integer Timestamp|Last updated time as Unix epoch timestamp|Yes|

#### User record

|**Field**|**Type**|**Description**|**Required**|
|--|--|--|--|
|email|Unicode String|User email, serves as user identifier, max 256 characters|Yes|
|password|Unicode String|Hashed user password, 256 characters|Yes|
|createdAt|Integer Timestamp|Creation time as Unix epoch timestamp|Yes|
|updatedAt|Integer Timestamp|Last updated time as Unix epoch timestamp|Yes|

## Backend API Shapes

*Note: All HTTP requests will redirect to HTTPS with a 308 response code.*

### [POST] /user

Create user API.

*Note: 400 response will not specify reason for failure for security reasons.*

Request body:
```
{
    email: <email>,
    password: <password>
}
```

Responses:
- `200` -> Success
- `400` -> Bad Request/Email In-use
- `500` -> Internal Server Error

Success response body:
```
{
    Token: <JWT>
}
```

### [POST] /login

Login API.

*Note: 400 response will not specify reason for failure for security reasons.*

Request body:
```
{
    email: <email>,
    password: <password>
}
```

Responses:
- `200` -> Success
- `400` -> Bad Request/Email Not Found/Password Mismatch
- `500` -> Internal Server Error

Success response body:
```
{
    token: <JWT>
}
```

### [GET] /todo

List API for ToDo resources, returns partial information about records, simple pagination and status-based filtering.

Query parameters:
- `page`
- `limit`
- `status`

Responses:
- `200` -> Success
- `400` -> Bad Request
- `401` -> Unauthorized
- `500` -> Internal Server Error

Success response body:
```
{
    todos: {
        {
            id: <identifier>,
            title: <title>,
            status: <status>
        },
        ...
    }
}
```

### [GET] /todo/{id}

Get API for ToDo resources, retrieves information about a single ToDo.

Responses:
- `200` -> Success
- `400` -> Bad Request
- `401` -> Unauthorized
- `404` -> Not found
- `500` -> Internal Server Error

Success response body:
```
{
    id: <identifier>,
    title: <title>,
    description: <description>,
    status: <status>,
    createdAt: <createdAt>,
    updatedAt: <updatedAt>
}
```

### [POST] /todo

Post API for ToDo resources, creates a new ToDo.

Request body:
```
{
    title: <title>
    description: <description>
}
```

Responses:
- `200` -> Success
- `400` -> Bad Request
- `401` -> Unauthorized
- `500` -> Internal Server Error

Response body:
```
{
    todoId: <identifier>
}
```

### [PATCH] /todo/{id}

Request body:
```
{
    title: <title>
    description: <description>
    status: <status>
}
```

Responses:
- `200` -> Success
- `400` -> Bad Request
- `401` -> Unauthorized
- `404` -> Not found
- `500` -> Internal Server Error

### [DELETE] /todo/{id}

Delete API for ToDo resources, deletes the record permanently.

Responses:
- `200` -> Success
- `400` -> Bad Request
- `401` -> Unauthorized
- `404` -> Not found
- `500` -> Internal Server Error

### Frontend

Framework: Vue

...

### Backend

Framework: ASP.NET

Remember: Security/Escaping content strings

...
