## Quite the ToDoozy!

*This is my ToDo application. There are many like it, but this one is mine.*

### Objective

This is an application for creating, viewing, and managing a collection of ToDo tasks. It will consist of both a backend API written in ASP.NET and a frontend written in Vue.

This service will *obviously* be *widely popular* and must scale to large loads and the expectations of its ferociously loyal customers, but the initial MVP will provide only basic functionalities and be capable of supporting the approximate lifetime average load. Additional infrastructure will be required to scale up to support expected lifetime peak loads defined below.

For the MVP phase of this project:
- We will define a "ToDo" as a task with a title and an optional description. The ToDo will be in one of a handful of states: "Not Started", "In Progress", "Completed", or "Abandoned".
- Users will have accounts from which they will be able to see and manage only the "ToDos" that they have created.
- ToDo text will not support any kind of styling.
- Simple "login or create account" auth flow, using email as user identifier
- Single page/view with modals for forms
- Ephemeral in-memory DB

Advanced features following the MVP phase may include:
- Attachments
- Third party login integrations
- User groups
- Additional user fields like profile picture or alternative username
- Nested ToDos and project/initiative ToDo buckets
- ToDo sharing and granular permissions management
- MCP APIs for agent-based access
- Richer user management experience
- Admin pages and flows
- Usage dashboards
- Deployment automation
- Persistent DB
- Caching & edge optimizations
- Support for load balancing, horizontal scaling, and data sharding

### User Stories

|**ID**|**Role**|**Goal**|**Benefit**|**Phase**|
|--|--|--|--|--|
|**US1**|As a User|I want to be able to create an account|So that I can access the same data across browsers and devices.|MVP|
|**US2**|As a User|I want to be able to log in to my account|So that I can access the same data across browsers and devices.|MVP|
|**US3**|As a User|I want to create new ToDo tasks|So that I can track them without having to remember everything.|MVP|
|**US4**|As a User|I want to give ToDo tasks a title|So I can quickly scan the list of ToDos for specific entries.|MVP|
|**US5**|As a User|I want to give ToDo tasks a description|So I can add more details about the ToDo without impacting readability of a list of ToDos.|MVP|
|**US6**|As a User|I want to assign ToDos to projects/initiatives|So that I can track ToDos towards different goals separately.|Post-MVP|
|**US7**|As a User|I want to assign parent/child relationships to ToDos|So that I can sub-task type ToDos effectively.|Post-MVP|
|**US8**|As a User|I want to add styling to my ToDos' text content|So that I can make my ToDos easier to read and scan.|Post-MVP|
|**US9**|As a User|I want to add attachments to my ToDos|So that I can enrich the details of my tasks with related documents.|Post-MVP|
|**US10**|As a User|I want to add tags to ToDo tasks|So that I can group related ToDos.|Post-MVP|
|**US11**|As a User|I want to change ToDo task titles|So that I can fix mistakes or add detail as the task changes.|MVP|
|**US12**|As a User|I want to change ToDo task descriptions|So that I can fix mistakes or add detail as the task changes.|MVP|
|**US13**|As a User|I want to change ToDo task tags|So that I can re-organize tasks as my project changes.|Post-MVP|
|**US14**|As a User|I want to delete ToDo tasks|So that I can stop tracking ToDos created in error.|MVP|
|**US15**|As a User|I want to mark ToDo tasks as completed|So that I can track how much progress I've made.|MVP|
|**US16**|As a User|I want to mark ToDo tasks as in progress|So that I can track my immediate workload.|MVP|
|**US17**|As a User|I want to mark ToDo tasks as abandoned|So that I can track which work was de-scoped or unnecessary.|MVP|
|**US18**|As a User|I want to view my open ToDo tasks|So that I can remind myself what work I haven't done yet.|MVP|
|**US19**|As a User|I want to view my completed ToDo tasks|So that I can remind myself what work is already complete.|MVP|
|**US20**|As a User|I want to view my abandoned ToDo tasks|So that I can remind myself what work was de-scoped or unnecessary.|MVP|
|**US21**|As a User|I want to view my in progress tasks|So I can see my immediate workload.|MVP|
|**US22**|As a User|I want to view all ToDo tasks, regardless of status|So I can assess total state of work towards my goal.|MVP|
|**US23**|As a User|I want to search ToDo tasks by name|So I can find specific ToDos easily when I have many ToDos.|MVP|
|**US24**|As a Team Member|I want to create user groups|So that I can group different sets of collaborators.|Post-MVP|
|**US25**|As a Team Member|I want to share ToDos with other users|So that we can collaborate on a group of tasks.|Post-MVP|
|**US26**|As a Team Member|I want to share ToDos with groups|So that I can manage multiple collaborators' permissions at once.|Post-MVP|
|**US27**|As a Team Member|I want to share ToDo projects/initiatives with users|So that I can share ToDos for a specific goal without sharing every ToDo.|Post-MVP|
|**US28**|As a Team Member|I want to share ToDo projects/initiatives with groups|So that I can share ToDos for a specific goal without sharing every ToDo.|Post-MVP|
|**US29**|As an Administrator|I want to view system-wide metrics|So that I can track health of the system and adoption.|Post=MVP|
|**US30**|As an Administrator|I want to ban and remove users & their resources|So that I can prevent use by malicious actors.|Post-MVP|

### Requirements

Requirements are be derived primarily from the user stories above.

#### Functional Requirements

|**ID**|**Requirement**|**Description**|**Phase**|
|--|--|--|--|
|**FR1**|ToDo CRUD Functionality|Create, read, update, delete on ToDo records.|MVP|
|**FR2**|ToDo Basic Fields|ToDos have title, description, status.|MVP|
|**FR3**|ToDo Advanced Fields|Attachments, tags, project.|Post-MVP|
|**FR4**|ToDo Text Content Styling|Title and description can be styled (bold, italic, headers, etc.)|Post-MVP|
|**FR5**|ToDo Filter Views|UI allows filtering views by enumerable fields.|MVP|
|**FR6**|ToDo Search View|UI allows searching ToDos across text-based fields.|MVP|
|**FR7**|User Group CRUD Functionality|Create, read, update, delete on User Groups.|Post-MVP|
|**FR8**|Initiative/Project CRUD Functionality|Create, read, update, delete on Initiatives/Projects.|Post-MVP|
|**FR9**|ToDo Parent/Child Relationships|Assign parent/child relationships between ToDos.|Post-MVP|
|**FR10**|Sharing & Permissions Management|Set permissions for users/groups on ToDos/Projects/Initiatives.|Post-MVP|
|**FR11**|Admin metrics dashboard|Admin portal with dashboard view for viewing system-wide metrics.|Post-MVP|
|**FR12**|Admin user & content management|Admin controls for managing and removing user abusive users and content.|Post-MVP|
|**FR13**|User creation & login flow|Users can create new accounts and log in to those accounts.|MVP|

#### Non-functional Requirements

|**ID**|**Requirement**|**Description**|
|--|--|--|
|**NFR1**|Extensibility|Each iteration should not close doors to forseen future features, avoid tight coupling wherever possible.|
|**NFR2**|Observability|Logs and metrics should be emitted and persisted for all components.|
|**NFR3**|Content Scrubbing|Escape and scrub any user-provided content to protect against injection attacks.|
|**NFR4**|HTTPS Only|Allow only HTTPS connections, redirect HTTP requests to HTTPS endpoint.|
|**NFR5**|Latency|API requests should always take < 250ms.|
|**NFR6**|Data Segregation|ToDos can only be viewed and updated by authorized individuals *(MVP: creator only)*.|
|**NFR7**|Horizontal Scalability|Sharding/some distribution strategy should be supported so that horizontal scaling is possible.|
|**NFR8**|Multi-language Support|Support characters beyond standard ASCII for multi-language support.|

### Assumptions & Scale

Assumptions about the service:
- The service will be maintained for 10 years (120 months)

Assumptions about users:
- Users may prefer languages other than English that include special characters not representable with ASCII
- Users will create on average 2^10 (1024) ToDos throughout their lifetime use of the service
- Across the lifetime of the service itself, there will be no more than 2^28 (268,435,456) total users
- Each user will submit a maximum of 2^8 (256) requests per day and an average of 2^5 (32) requests per day
- Daily active users will not exceed 30% of monthly active users
- Peak monthly active users will on average be 2^20 (1,048,576) but will not exceed 2^24 (16,777,216) users
- Emails will exceed 256 characters (consuming 512 bytes/0.5KiB if unicode)
- Passwords will be 256 character unicode strings when using ASP.NET Identity features (consuming 512 bytes/0.5KiB)

Assumptions about ToDos:
- Titles will require no more than 256 characters (512 bytes/0.5KiB if unicode)
- Descriptions will require no more than 4096 characters (8192 bytes/8KiB if unicode)
- Statuses will take a max of 1 byte (integer representation, assuming optimized integer storage)

Assumptions about metadata:
- Timestamps will consume 4 bytes (Unix timestamp consumes 4 bytes until 2038, after expected EoL of this service)

As a result:
- Peak daily active users will not exceed 5,033,165 (2^24 * 0.3)
- Peak requests per second will on average be approximately 33,554,432 (2^20 * 2^5)
- Peak daily requests will not exceed approximately 536,870,912 (2^24 * 2^5) 
- Peak requests per second will on average be 117 ((2^24 * 2^5 * 0.3) / (60 * 60 * 24))
- Peak requests per second will not exceed 1865 ((2^24 * 2^5 * 0.3) / (60 * 60 * 24))
- No more than 2^38 (2^10 * 2^28 = 274,877,906,944) ToDos will be created throughout the lifetime of the service
- ToDo IDs will require no more than 5 bytes (integer representation, assuming optimized integer storage)
- Each ToDo requires a maximum of ~8.5KiB (5 + 512 + 8192 + 1 + 4 + 4 = 8718 bytes) to store
- Each user requires a maximum of ~1KiB (512 + 512 + 4 + 4 = 1032 bytes) to store
- Total ToDo storage required over service lifetime is at maximum 2.23 TiB (2^38 * 8718 bytes)
- Total user storage required over service lifetime is at maximum 258 GiB (2^28 * 1032 bytes)
- Total lifetime storage requirement is at maximum 2.48 TiB (2.23 TiB + 258 GiB)

*Note: These numbers may seem large for a simple ToDo application. They probably are, but you really don't want to run out of ID space, so better safe than sorry with these calculations.*

### Key Considerations & Decisions

#### Identifiers

**Option 1:** ROWID/Auto-incrementing Integer

Use default integer primary key behavior in SQLite, it is effectively an auto-incrementing integer ID.

Pros:
- Simple, requires no service-side generation/management
- Guaranteed uniqueness for single DB instances
- Better performance and storage efficiency vs strings

Cons:
- Couples to nature/behavior of DB, which may change post-MVP
- If multiple servers or DB instances exist post-MVP uniqueness may be violated
- Less secure than string identifiers if user-facing

**Option 2 (Selected):** Service-generated Integer, Assigned Block

*Chosen for future extensibility, performance, and lower concerns around security due to nature of the service.*

The service generates an integer within its assigned ID range and uses that for a primary key.

Pros:
- No coupling to nature/behavior of DB, which may change post-MVP
- Guarantees uniqueness in case of future multi-server, multi-DB scenario
- Better performance and storage efficiency vs strings

Cons:
- Requires management of IDs
- Less secure than string identifiers if user-facing

**Option 3:** Service-generated String, GUID

The service generates a string GUID and uses that for a primary key.

Pros:
- No coupling to nature/behavior of DB, which may change post-MVP
- More secure than integer identifiers if user-facing

Cons:
- Requires management of IDs
- Worse performance and storage efficiency vs integers
- Risk of collisions, even if low probability

#### String Encodings

We will be using Entity Framework Core which allows choosing between unicode or non-unicode encodings and maps to underlying DB types automatically.

**Option 1 (Selected):** Unicode

*Chosen for wider language support listed as a requirement.*

Pros:
- Support for wider variety of characters languages

Cons:
- Uses two bytes per character rather than one

**Option 2:** Non-unicode

Pros:
- Uses one byte per character rather than two

Cons:
- Supports narrower variety of characters and languages.

#### Timestamp Representations in DB

**Option 1:** ISO String

String with format `YYYY-MM-DD HH:MM:SS`.

Pros:
- Readable for service operators

Cons:
- Requires more storage

**Option 2 (Selected):** Unix Timestamp Integer

Number of seconds since Unix epoch.

Pros:
- Consumes less storage

Cons:
- Not readable for service operatorss

#### Representing ToDo to User Relationships

**Option 1 (Selected):** On-record Foreign Key

*Chosen for one-to-many relationship of owner to ToDo.*

Embed the foreign key in the record itself.

Pros:
- Good for one-to-many or one-to-one relationships.

Cons:
- Not good for many-to-many relationships

**Option 2:** xRef Table

*Note: This will be useful post-MVP for granular additional permissions tracking.*

Use dedicated tables to map foreign keys across multiple tables.

Pros:
- Good for many-to-many relationships

Cons:
- Not good for one-to-many or one-to-one relationships.

#### MVP UI Page Structure

**Option 1 (Selected):** Single Page & Modal Forms

*Chosen for simplicity.*

Single page with search bar and filter controls. Records listed on the page have embedded control elements on each row. Any forms (login, create ToDo, edit ToDo, confirm) appear as modals.

Pros:
- Simple to implement
- Intuitive to use

Cons:
- Limited real estate

**Option 2:** Multi-page

Have separate pages for various functionalities (login, create ToDo, edit ToDo) and small decisions like action confirmations remain as modals.

Pros:
- More space to work with for each feature's UI

Cons:
- More work to implement
- May be less intuitive to use

## Appendix

### Environment Setup

*Note: Development was done on **Windows** and has not been tested on other platforms.*

#### Windows Environment Setup

...

### Repository Structure

...

### Branching Strategy

...

### AI Use Disclosure

Currently, no AI has been used on this project.
