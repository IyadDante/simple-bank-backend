# 🧰 Technology Stack Justification – SimpleBank

This document explains the rationale behind each major technology and tool used in the development of the **SimpleBank** microservices-based backend system.

---

## 🔙 Backend Framework: ASP.NET Core (.NET 8)

**Why we chose it:**
- High-performance, cross-platform, and cloud-ready.
- Supports both RESTful and gRPC APIs natively.
- Strong type safety and built-in dependency injection.
- Mature ecosystem with enterprise-grade tooling (e.g., Visual Studio, Rider, .NET CLI).
- Excellent support for JWT-based authentication, logging, validation, and exception handling.

---

## 🔌 API Communication Protocols

### ✅ RESTful APIs (External Communication)
**Why:**
- Simple and well-understood standard.
- Ideal for client-facing applications like mobile and web frontends.
- Easily debuggable using tools like Postman and Swagger.
- Flexible and language-agnostic (works with any platform that can make HTTP requests).

**Usage in SimpleBank:**
- Used for all external communications (e.g., login, account info, transactions).
- Follows standard HTTP verbs: GET, POST, PUT, DELETE.

---

### ✅ gRPC (Internal Microservice Communication)
**Why:**
- Faster than REST due to HTTP/2 and Protocol Buffers (binary format).
- Enforces strong API contracts using `.proto` files.
- Great for low-latency, high-throughput communication between services.

**Usage in SimpleBank:**
- Enables fast communication between `AccountService`, `TransactionService`, and `ReportingService`.
- gRPC will be introduced after the REST architecture is in place.

---

## 🛢 Database: AWS RDS (PostgreSQL)

**Why:**
- Managed relational database with high availability and automatic backups.
- Offers built-in monitoring, scaling, and security features.
- PostgreSQL is open-source, widely adopted, and SQL-compliant.
- Easily integrates with .NET via `Npgsql`.

**Usage in SimpleBank:**
- Each microservice connects to its own schema/database.
- PostgreSQL allows enforcing relational constraints like transactions and foreign keys.

---

## 📦 Containerization: Docker

**Why:**
- Ensures consistency across development, staging, and production environments.
- Allows each microservice to run independently in its own container.
- Easy to manage dependencies, isolate services, and scale horizontally.

**Usage in SimpleBank:**
- Each service has its own Dockerfile.
- All services orchestrated via `docker-compose.yml`.
- Simplifies onboarding and CI/CD workflows.

---

## 📨 Asynchronous Messaging: RabbitMQ *(planned)*

**Why:**
- Enables asynchronous, event-driven architecture.
- Improves performance and fault tolerance by decoupling services.
- Supports retry logic and message durability.
- Widely supported and easy to integrate with .NET via libraries like `MassTransit` or `RabbitMQ.Client`.

**Usage in SimpleBank:**
- Services (e.g., `TransactionService`) will publish events like `TransactionCreated`.
- Other services (e.g., `NotificationService`) will subscribe to and handle those events.

---

## ☁️ Cloud Deployment Strategy

### 🔹 Initial Deployment: **Render / Railway**
**Why:**
- Developer-friendly platforms with free tiers.
- Quick to deploy Docker containers or web services from GitHub.
- Ideal for MVP, testing, and demos.

### 🔹 Final Deployment: **AWS**
**Why:**
- Industry-standard cloud provider with deep support for .NET and RDS.
- Real-world deployment experience with services like:
  - **EC2** for hosting containers or services.
  - **ECS / EKS** for container orchestration.
  - **RDS** for managed databases.
  - **IAM** for secure role-based access.

---

## 🔐 Security Technologies

- **JWT (JSON Web Tokens):** Stateless authentication for all REST APIs.
- **HTTPS:** Enforced for all traffic.
- **Role-Based Access Control (RBAC):** Enforced per service (e.g., admin vs user).
- **Environment Variables:** Used for secrets, DB credentials, API keys (managed via `.env` or Docker secrets).

---

## 📈 Monitoring and Logging *(Optional Future Phase)*

- **Serilog / Seq / ELK Stack:** For centralized logging and structured logs.
- **Prometheus + Grafana:** For metrics and performance monitoring.
- **OpenTelemetry:** For tracing gRPC and REST communication between services.

---

## 🧩 Summary Table

| Component              | Technology         | Justification                                           |
|------------------------|--------------------|----------------------------------------------------------|
| Backend Framework      | ASP.NET Core (.NET 8) | Enterprise-ready, performant, and cross-platform         |
| External API Protocol  | REST               | Standard for clients; easy to integrate and debug        |
| Internal API Protocol  | gRPC               | Fast binary communication between microservices          |
| Database               | AWS RDS (PostgreSQL) | Scalable, managed, and SQL-compliant                     |
| Containerization       | Docker             | Portability, consistency, and deployment flexibility     |
| Messaging Queue        | RabbitMQ (future)  | Enables asynchronous, decoupled workflows                |
| Deployment (Dev)       | Render/Railway     | Fast, simple hosting for prototyping                     |
| Deployment (Prod)      | AWS                | Real-world, secure, scalable infrastructure              |
| Authentication         | JWT                | Secure, stateless user authentication                    |
