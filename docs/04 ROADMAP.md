# Project Roadmap

## Phase 1 – Base Microservices Setup
- [ ] Create project repo and folder structure
- [ ] Setup AuthService with REST
- [ ] Setup AccountService
- [ ] Setup TransactionService
- [ ] Dockerize all services

## Phase 2 – Add gRPC
- [ ] Create gRPC proto files
- [ ] Implement gRPC between Account ↔ Transaction

## Phase 3 – Add Queue (RabbitMQ)
- [ ] Setup RabbitMQ container
- [ ] Implement async event handling for notifications

## Phase 4 – Cloud Deployment
- [ ] Deploy to Render (or Railway)
- [ ] Migrate DB to AWS RDS
- [ ] Setup environment variables securely

## Phase 5 – Polish & Documentation
- [ ] Add README setup instructions
- [ ] Add Swagger/OpenAPI docs
- [ ] Optional: Rebuild one service in Python (FastAPI)
