# Sai Sports India

![Sai Sports India](https://saisportsindia.com/images/logo.png)

Corporate website for Sai Sports India - Built with ASP.NET Core MVC.

## 🚀 Tech Stack

- **Framework**: ASP.NET Core MVC 8
- **Database**: SQL Server with Entity Framework Core
- **Frontend**: HTML5, CSS3, JavaScript
- **Architecture**: MVC Pattern

## 📦 Installation & Setup

### Prerequisites
- .NET 8.0 SDK
- SQL Server 2019+
- Visual Studio 2022

### Development Setup

1. **Clone and Setup**
```bash
git clone https://github.com/saisportsindia/website.git
cd SaiSportsIndia
dotnet restore
```

2. **Database Configuration**
```json
// appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=SaiSportsIndia;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

3. **Database Migration**
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

4. **Run Application**
```bash
dotnet run
```
Access at: `https://localhost:7000`

## 🛠️ Development Features

### Implemented Functionality
- **Content Management**: Dynamic page content
- **Product Catalog**: Category-based product display
- **Contact System**: Inquiry form with backend processing
- **Admin Dashboard**: Content management interface
- **Responsive Design**: Mobile-first approach

### Key Controllers
- **HomeController**: Public-facing pages (Home, About, Products, Contact)
- **AdminController**: Backend management (Dashboard, CRUD operations)

### Data Models
- Product management with categories
- Customer inquiry tracking
- Content management system
- User authentication system

## 🎯 Build & Deployment

### Development Build
```bash
dotnet build
dotnet run
```

### Production Build
```bash
dotnet publish -c Release -o ./publish
```

### Environment Configuration
- **Development**: Detailed errors, local DB
- **Production**: Optimized, production DB, error logging

---

**Live**: [https://github.com/saisportsindia/website](https://saisportsindia.com/)
