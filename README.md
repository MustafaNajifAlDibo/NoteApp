# NoteApp

A cross-platform note-taking application built with **.NET MAUI** following the **MVVM** architecture. The application allows users to create, edit, delete, and manage notes with persistent local storage using **SQLite** and **Entity Framework Core**.

## Features

* Create new notes
* Edit existing notes
* Delete notes
* Display all saved notes
* Select a note to view or edit its details
* Persistent local data storage with SQLite
* Cross-platform support using .NET MAUI
* MVVM architecture
* CommunityToolkit.Mvvm for simplified ViewModel implementation

## Technologies

* .NET MAUI
* C#
* MVVM Pattern
* CommunityToolkit.Mvvm
* Entity Framework Core
* SQLite
* Microsoft.Data.Sqlite

## Project Structure

```
NoteApp
│
├── Models
├── Views
├── ViewModels
├── Data
└── Platforms
```

## Development Timeline

### Project Initialization

* Created the .NET MAUI project.
* Added the `Note` model.
* Created the main note view.

### MVVM Implementation

* Implemented `INotifyPropertyChanged`.
* Added properties to `NoteViewModel`.
* Implemented data binding between the View and ViewModel.
* Added commands for adding and removing notes.

### CRUD Features

* Added support for creating notes.
* Implemented editing functionality.
* Fixed selected item synchronization.
* Added delete functionality.
* Implemented loading notes from the database.

### Toolkit Integration

* Refactored the ViewModel using **CommunityToolkit.Mvvm**.
* Replaced manual property notification with toolkit attributes.
* Simplified command implementation.

### Local Database

* Integrated SQLite.
* Added Entity Framework Core.
* Configured local database creation.
* Implemented complete CRUD operations using EF Core.

## Getting Started

### Prerequisites

* Visual Studio 2022 or later
* .NET 9 SDK (or the version used by the project)
* MAUI workload installed

### Run the Project

```bash
git clone https://github.com/<username>/NoteApp.git
cd NoteApp
dotnet build
dotnet maui run
```

## Architecture

The application follows the MVVM design pattern.

```
View
   │
Binding
   │
ViewModel
   │
Entity Framework Core
   │
SQLite Database
```

## Future Improvements

* Search notes
* Categories or tags
* Dark mode support
* Cloud synchronization
* Export and import notes
* Rich text editing

## License

This project is intended for learning and educational purposes.
