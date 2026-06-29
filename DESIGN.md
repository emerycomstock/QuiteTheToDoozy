## Design

### Data Structures

ToDo record:
```
id: Unique identifier, service-assigned, non-secret,  characters
title: Short free text, max 2^8 (256) characters, UTF-8 (max 1KiB)
description: Longer free text, max 2^12 (4096) characters, UTF-8 (max 16KiB)
status: Integer representing one of: Not Started, In Progress, Completed, or Abandoned (max 2 bytes)
```

*Note: We are using reduced maximums for some integer fields due to SQLite's integer byte-level storage optimizations.*

### Frontend

Framework: Vue

...

### Backend

Framework: ASP.NET

...
