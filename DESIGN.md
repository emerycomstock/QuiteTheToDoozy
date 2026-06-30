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

### Frontend

Framework: Vue

...

### Backend

Framework: ASP.NET

Remember: Security/Escaping content strings

...
