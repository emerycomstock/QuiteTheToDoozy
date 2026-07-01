## Quite the ToDoozy!

*This is my ToDo application. There are many like it, but this one is mine.*

### Objective

This is an application for creating, viewing, and managing a collection of ToDo tasks. It will consist of both a backend API written in ASP.NET and a frontend written in Vue.

This service will *obviously* be *widely popular* and must scale to large loads and the expectations of its ferociously loyal customers, but the initial MVP will provide only basic functionalities and be capable of supporting the approximate lifetime average load. Additional infrastructure will later be required to scale up to support expected lifetime storage requirements or lifetime peak loads.

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

Assumptions about users:
- Users may prefer languages other than English that include special characters not representable with ASCII
- Users will not create more than 1,000,000 ToDos throughout their lifetime use of the service
- Emails will not exceed 256 characters
- Hashed passwords will be 256 character unicode strings when using ASP.NET Identity features

Assumptions about ToDos:
- Titles will require no more than 256 characters
- Descriptions will require no more than 2048 characters
- Not Started, In Progress, Completed, and Abandoned are sufficient statuses for this use case

### Key Considerations & Decisions

#### Identifiers

**Option 1 (Selected):** Auto-incrementing Integer

*Chosen for simplicity, performance, and lower concerns around security due to nature of the service.*

Utilize an auto-incrementing integer key.

Pros:
- Guarantees uniqueness for current scenario
- Better performance and storage efficiency vs strings

Cons:
- Less secure than string identifiers if user-facing

**Option 2:** Service-generated String, GUID

The service generates a string GUID and uses that for a primary key.

Pros:
- More secure than integer identifiers if user-facing

Cons:
- Worse performance and storage efficiency vs integers
- Risk of collisions, even if low probability

#### String Encodings

We will be using Entity Framework Core which allows choosing between unicode or non-unicode encodings and maps to underlying DB types automatically.

**Option 1 (Selected):** Unicode

*Chosen for wider language support.*

Pros:
- Support for wider variety of characters languages

Cons:
- Uses two bytes per character rather than one

**Option 2:** Non-unicode

Pros:
- Uses one byte per character rather than two

Cons:
- Supports narrower variety of characters and languages.

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

Prerequisites:
1. Install .NET 10 SDK
2. Optional: Install Visual Studio
3. Install Node 24

Running backend:
```
cd ToDoozy.Server
dotnet run --project ToDoozy.Server.API
# HTTP runs on port 5087
# HTTPS runs on port 7081
```

Running frontend:
```
cd ToDoozy.UI
npm install
npm run dev
# HTTP runs on port 5173
```

Testing:
1. To test the backend you can use the "play" button in Visual Studio to launch the server. Some sample requests are defined in `ToDoozy.Server.API.http` and can be executed with a click to run manual tests.
2. To test end-to-end from the frontend start both the backend and frontend simultaneously, access the frontend at `http://localhost:5173` and use the app.

### What Remains Incomplete

- Post-MVP User Stories From Above
- Proper Testing Automation (UTs & E2E Integration Tests)
- Proper Metrics/Logs/Monitoring
- Proper Documentation
- Integration with CI/IaC
- Other Infra (External Load Balancers, "Scale Out" Story, etc.)
- Some Known Bugs
    - Currently filtering away all statuses "loops back" to including all statuses
    - Pagination allows you to navigate to an empty page if total records are divisible by page size
    - Some API responses could be tightened (leak less stack traces, etc.)
- UI Tweaks
    - Could use a facelift in general
    - Logout button is too close/not aligned with email
    - Color scheme needs a major revamp
    - Using reduced icon set due to an issue with the icon package
    - Multi-layout support (including mobile)
    - Need to tighten up API response validation & response (surfacing API errors, etc.)
    - Some extra consistency/redundancy to ensure authentication state is valid would help
- Frontend code could use some light cleanup
    - Factor out the ToDo access code into a separate store/client type
    - Some duplicate code across components that do similar things, especially modals

### AI Use Disclosure

Currently, no AI has been used on this project.
