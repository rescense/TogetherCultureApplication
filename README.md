# Together Culture Application

A Windows Forms (C#) desktop application for a community hub, with a SQL Server
(LocalDB) backend. Built as a group project ("Dream Team").

## Features

- **Member accounts** — sign up, log in, two-factor-style verification (email/phone
  code windows), forgotten-password flow, account settings
- **Events** — browse/search events, book, and leave feedback
- **Skill Share** — post and search for skills, with a "time bank" for tracking
  exchanged hours
- **Admin dashboard** — search/manage users, approve pending memberships, manage
  events
- **Landing page** — about us, blog, memberships, shop, venue hire

## Project structure

```
Together Culture (Dream Team)/
├── Back-End/
│   ├── Main/              # Program entry point
│   └── ToolBoxItems/      # DatabaseConnect, shared UI components
├── Front-End/
│   ├── Screens/           # Forms: Admin, Events, Skill Share, Profile, Landing Page
│   └── User Controls/     # Shared reusable controls
├── Database/              # SQL scripts + LocalDB files
└── Resources/              # Images

TogetherCultureTests/       # Unit tests (database, admin search, user search)
```

## Setup

1. Open `Together Culture (Dream Team).sln` in Visual Studio.
2. The database is SQL Server LocalDB (`Database/db_TogetherCulture.mdf`).
3. Update the connection string in
   `Back-End/ToolBoxItems/DatabaseConnect.cs` to match your local path for the
   `.mdf` file (it currently points to a specific development machine's folder).
4. Build and run.

## Tests

Unit tests for database access, admin user search, and event search are in
`TogetherCultureTests/`.
