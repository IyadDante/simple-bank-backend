# SimpleBank

A microservices-based digital banking backend built with ASP.NET Core, Docker, REST/gRPC APIs, and AWS RDS.

## 🚀 Features
- User authentication and role-based access
- Account management (create, close, view)
- Transactions (deposit, withdrawal, transfer)
- Cloud database with AWS RDS
- REST APIs for external access
- gRPC for internal service communication
- Dockerized microservices
- Cloud deployment via Render (initial), AWS (final)

## 🛠 Tech Stack
- **Backend:** ASP.NET Core (.NET 8)
- **API:** REST (initial), gRPC (internal)
- **Database:** PostgreSQL on AWS RDS
- **Containerization:** Docker
- **Deployment:** Render (initial), AWS Free Tier (final)
- **Optional:** RabbitMQ (for async event handling)

## 📂 Services Overview
- `AuthService` – Handles registration and login
- `AccountService` – Manages bank accounts
- `TransactionService` – Handles money transfers
- `ReportingService` – Generates transaction reports/statements
- `NotificationService` (Optional) – Sends emails or SMS notifications

## 🧰 Getting Started
> Will include setup steps for Docker, DB, and services later.
