# PatientRecordsAPI
Patient Management API Documentation

Project Overview

The Patient Management API is a simple CRUD-based .NET 8 Web API designed to manage patients and their associated medical records. It provides functionalities to create, retrieve, update, and soft-delete patient data while maintaining related consultations, medications, prescriptions, and vital signs.

Key Features:

Patient CRUD operations.
Management of patient-related records such as medications, consultations, prescriptions, and vital signs.
SQLite as the database for simplicity and portability.
Unit testing using Moq and XUnit.
API documentation using Swagger.
EF Core Migrations with initial sample data.
Dependency Injection for service-based architecture.
Docker support for easy deployment.
Implementation Thought Process
The API is built following RESTful principles while ensuring scalability and ease of extension. Below are the core design decisions and justifications:

1. Architecture Design

Layered Architecture:

Services: Contain business logic and interact with the repository layer.

**Design Pattern**
The Repository pattern was used in order to separate the data kayer from the Service/business logic layer. This is to allow for a more flexible choice of storage technology and implementation.

**Dependency Injection**

Promotes testability and flexibility by allowing different implementations (e.g., swapping out repositories or database providers easily).

2. Entity Relationships and Design

The key entities are structured as follows:
Patient: Core entity containing personal details.
Consultation: Links to a Patient, capturing the physician's notes and diagnoses.
Medication: Represents prescribed drugs linked to a Patient.
Prescription: Groups medications prescribed by a doctor.
VitalSign: Tracks a patient's health indicators over time.
All relationships use EF Core Foreign Keys for proper data consistency.

**Unit Testing Strategy**

Moq: Mocks services for isolated unit testing of controllers.
XUnit: Ensures robust test execution and result validation.

**Future Enhancements**

Implement authentication & authorization using JWT.
Introduce pagination and sorting for patient listings.
Implement GraphQL support for flexible querying.
Enable Multi-Tenancy for handling multiple healthcare institutions.
Migrate to Cloud Databases (e.g., Azure SQL, PostgreSQL) for production.

