## Quite the ToDoozy!

*This is my ToDo application. There are many like it, but this one is mine.*

### Objective

This is an application for creating, viewing, and managing a collection of ToDo tasks. It will consist of both a backend API written in ASP.NET and a frontend written in Vue.

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
|--|--|--|
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

### Key Considerations & Decisions

...
Remember: Security/Escaping content
...

### Assumptions

...

### High-level Approach

...

## Appendix

### Repository Structure

...

### Branching Strategy

...

### AI Use Disclosure

Currently, no AI has been used on this project.
