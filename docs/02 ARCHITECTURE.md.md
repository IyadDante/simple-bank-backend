# 📐 Architecture Overview – SimpleBank

## 🧱 Microservices-Based Design

SimpleBank follows a modular microservices architecture. Each core business function is separated into its own independent service, allowing for better scalability, maintainability, and deployment flexibility.

### 🧩 Core Microservices

| Service             | Responsibility                                      |
|---------------------|------------------------------------------------------|
| **AuthService**     | User registration, login, JWT-based authentication  |
| **AccountService**  | Create, manage, and close user bank accounts        |
| **TransactionService** | Handle deposits, withdrawals, transfers         |
| **ReportingService**   | Generate statements and transaction summaries    |
| **NotificationService** *(Optional)* | Send email/SMS notifications for events |

Each service runs independently, communicates via APIs, and stores data in its own bounded context.

---

## 🔄 Communication Strategy

### 🔹 RESTful APIs
- Used for **external communication** (e.g., frontend, mobile apps).
- Follows standard HTTP methods and JSON responses.
- Easy to test and integrate.

### 🔹 gRPC APIs *(internal only)*
- Used for **high-performance inter-service communication**.
- Faster than REST (uses HTTP/2 and Protocol Buffers).
- Suitable for internal use where speed and efficiency matter.

> Example: `AccountService` may call `TransactionService` via gRPC to verify available balance before initiating a transfer.

---

## 💬 Messaging (Future)
- **RabbitMQ** (or similar) will be introduced to support **asynchronous event-driven communication**.
- Services like `NotificationService` will listen for events (e.g., `TransactionCreated`) and act accordingly.
- This ensures fault-tolerance and decoupling of responsibilities.

---

## 🧱 Infrastructure Components

- **API Gateway (optional)**: Routes requests to appropriate services (e.g., using YARP or Ocelot in .NET).
- **Docker**: Each service is containerized for consistent local and cloud deployment.
- **AWS RDS**: PostgreSQL or SQL Server hosted in AWS for persistent cloud storage.
- **Cloud Hosting**: Initial deployment to Render/Railway; production deployment to AWS.

---

## 📊 System Diagram

```text
[Client App (Web/Mobile)]
        ↓ REST
    [API Gateway (optional)]
        ↓ REST
[AuthService] ←→ [AccountService] ←→ [TransactionService]
                                  ↘
                                gRPC ↘
                              [ReportingService]
                                  ↘
                              Event Bus ↘
                            [NotificationService]
