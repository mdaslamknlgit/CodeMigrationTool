# .NET Framework 4 → .NET 10 Migration Tool

A comprehensive, automated tool for migrating legacy ASP.NET Framework applications (MVC, Web API) to modern .NET 10.

## 🎯 Features

- **Automated Analysis** - Scan .NET Framework projects for migration compatibility
- **Code Transformation** - Automatic namespace rewrites, API updates, and config migration
- **Roslyn-based** - Deep C# AST analysis and transformation
- **Clean Architecture Support** - Handles complex layered architectures
- **EF 6 → EF Core** - Database context migration assistance
- **Comprehensive Reports** - Detailed migration analysis and recommendations
- **Large Project Support** - Optimized for projects with 100s of files

## 🚀 Quick Start

### Prerequisites
- .NET 10 SDK
- Visual Studio 2022+ or VS Code
- Git

### Setup

```bash
git clone https://github.com/mdaslamknlgit/CodeMigrationTool.git
cd CodeMigrationTool
dotnet build