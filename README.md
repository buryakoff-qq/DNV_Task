# Cube Intersection – Test Task
## Overview

A minimal Clean Architecture solution that determines whether two cubes intersect and calculates the intersected volume.

---

## Architecture

### Domain Layer (`CubeIntersection.Domain`)

**Purpose:** Contains pure business logic, isolated from any external frameworks.

**Contents:**
- **Entities**
  - `Cube` – represents a cube in 3D space, validates dimensions, calculates axis ranges.
  - `Position` – immutable value object representing cube center coordinates.
- **Value Object**
  - `IntersectionResult` – holds the result of intersection and calculated volume.
- **Service**
  - `CubeIntersectionDomainService` – encapsulates core intersection logic.
- **Interface**
  - `ICubeIntersectionService` – abstraction for the domain service.


---

### Application Layer (`CubeIntersection.Application`)

**Purpose:** Defines use cases, validation, and DTO mapping between presentation and domain.

**Contents:**
- `CubeInputDto` – user input data.
- `IntersectionResultDto` – result data.
- `CubeIntersectionAppService` – validates input, constructs domain entities, delegates computation to the domain service.

**Responsibilities:**
- Validate and sanitize input.
- Convert DTOs to domain entities and back.
- Keep orchestration separate from domain logic.

---

### Presentation Layer (`CubeIntersection.Console`)

**Purpose:** Console-based entry point for demonstration and testing of the architecture.

**Structure:**
- **Commands**
  - `ReadCubeCommand` – handles user input.
  - `CalculateIntersectionCommand` – invokes the Application layer.
  - `PrintResultCommand` – displays the result.
- **Program.cs**
  - Composition root that wires dependencies manually:
    ```
    Domain → Application → Presentation
    ```

**Input:** cube side lengths and center coordinates.  
**Output:** intersection flag and volume.

---

## Tests

**Framework:** xUnit

**Projects:**
- `CubeIntersection.Domain.Tests`
- `CubeIntersection.Application.Tests`

**Coverage:**
- Non-intersecting cubes (volume = 0)
- Touching cubes (volume = 0)
- Partial overlap
- Full containment
- Invalid input validation

Each test isolates its layer. Domain tests cover business logic, Application tests cover use-case behavior.

---

## Principles Applied

| Principle | Implementation |
|------------|----------------|
| Clean Architecture | Clear dependency direction: Domain → Application → Presentation |
| DDD Elements | Entities, Value Objects, Domain Service |
| SOLID | SRP, OCP, DIP |
| Testability | Deterministic logic, no framework coupling |
| Composition Root | Dependencies created manually in Program.cs |

---

## Run & Test

```bash
dotnet build
dotnet test
dotnet run --project src/CubeIntersection.Console
