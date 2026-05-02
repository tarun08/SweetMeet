# SweetMeet 🍬🤝

SweetMeet is a modern, full-stack social meetup application designed to connect people with similar interests. Built with cutting-edge technologies, it provides a seamless and responsive experience for users to find and interact with others.

## 🚀 Features

- **User Authentication**: Secure registration and login using JWT and BCrypt hashing.
- **Modern UI**: A sleek, responsive interface built with Angular, Tailwind CSS, and DaisyUI.
- **Clean Architecture**: A well-structured .NET backend following domain-driven design principles.
- **Scalable Backend**: Powered by .NET 10 for high performance and reliability.
- **Database Integration**: Robust data management using SQL Server and Entity Framework Core.

## 🛠️ Tech Stack

### Frontend
- **Framework**: [Angular 21](https://angular.dev/)
- **Styling**: [Tailwind CSS 4](https://tailwindcss.com/) & [DaisyUI 5](https://daisyui.com/)
- **Testing**: [Vitest](https://vitest.dev/)
- **State Management**: RxJS

### Backend
- **Framework**: [.NET 10](https://dotnet.microsoft.com/)
- **API**: ASP.NET Core Web API
- **ORM**: Entity Framework Core
- **Database**: Microsoft SQL Server
- **Security**: JWT Bearer Authentication

## 🏁 Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Node.js](https://nodejs.org/) (v20 or higher)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB supported)
- [Angular CLI](https://angular.dev/tools/cli) (`npm install -g @angular/cli`)

### Setup

1. **Clone the repository**:
   ```bash
   git clone https://github.com/your-username/SweetMeet.git
   cd SweetMeet
   ```

2. **Backend Setup**:
   ```bash
   cd SweetMeet.API
   dotnet restore
   dotnet ef database update
   dotnet run
   ```

3. **Frontend Setup**:
   ```bash
   cd SweetMeet.Client
   npm install
   npm start
   ```

## 📂 Project Structure

- `SweetMeet.API`: The main entry point for the backend services.
- `SweetMeet.Client`: The Angular frontend application.
- `SweetMeet.Domain`: Core business logic and domain models.
- `SweetMeet.Data`: Data access layer and Entity Framework configurations.
- `SweetMeet.Infrastructure`: Cross-cutting concerns and external service integrations.

## 🧪 Testing

- **Frontend**: Run `npm test` in the `SweetMeet.Client` directory.
- **Backend**: Run `dotnet test` from the root or specific project folders.

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
