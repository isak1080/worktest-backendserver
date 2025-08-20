# 1080Motion – Training Sessions API (Timeboxed)

A minimal, production-flavored ASP.NET Core Web API skeleton for a 4–5 hour coding test.

## Task

You will build a production-grade REST API for coaches to plan workouts and for athletes to 
log results measured by connected devices. Focus on clean domain modeling, correctness, performance, and operability.

Attached is a skeleton solution to get you started, but it's fine to start clean and design your own solution.

Below is a list of things to implement. Try to implement as much as possible, but don't get stuck for too long on any specific task. 

If you skip some part of the task, be prepared to discuss during the interview how it could be solved

### Security (minimal but real)

* **JWT bearer**, with **two seeded users**:

    * **coach1** (role `Coach`)
    * **athlete1** (role `Athlete`, linked to one seeded Athlete entity)
    
* Provide a quick **/auth/token** endpoint that issues JWTs for the users in the database (no signup needed).
  * For simplicity, use a static symmetric key and hard coded values for audience and issuer. (there's an example in appsettings.Development.json)
   
(If you strongly prefer, Basic Auth or a static API key is acceptable, but be prepared to discuss the trade-off.)*

### Endpoints:
Implement at least some of these endpoints, and be prepared to discuss how to implement the others. 

1. **Coach role only** 

    * `POST /api/athletes` → create athlete
    * `GET  /api/athletes` → list athletes 
        - Bonus: add filter parameters and pagination 
    * `POST /api/workout-templates` → create template
    * `POST /api/sessions` → create planned session

2. **Athlete role only**

    * `GET  /api/sessions/mine?from=&to=` → list **own** planned sessions
    * **Set ingestion:**
      `POST /api/sessions/{sessionId}/sets?sequenceNumber=`
      * Log training data for a planned session. 
      * Use `Idempotency-Key` header to avoid duplicates:
            * First call creates the set
            * Repeat with same body → **200** returning same resource
            * Repeat with different body → **409 Conflict**

3. **Quick stats (computed on read)**

   * Athlete:  `GET /api/stats/mine/daily?from=&to=` → returns aggregated per-day `{ day, setCount, avgMetric }` from CompletedSet for the authenticated athlete. *(No background jobs—just a SQL/LINQ GROUP BY.)*

4. **Ops**

    * `GET /health` → returns 200 if app + DB reachable

5. **Authentication**

    * `POST /auth/token` → returns JWT token for the seeded users
```   
POST /auth/token
{
  "username": "coach1",
  "password": "coach123"
}
→ 200 { "access_token": "..." }
```
Use the returned `access_token` as a Bearer token in subsequent requests.

### Tests 
Optional, but recommended. If skipped, be prepared to discuss how to implement testing
in a real-world scenario.

* **Unit**: domain/input validation, helper methods, individual services/repositories,...
* **Integration** (Perform requests against a running API)

    * Happy path: Coach creates athlete → template → session; Athlete lists sessions; Athlete logs a set idempotently (same key twice).
    * Conflict on idempotency with different payload.

Full coverage is not required, it's more important to show that you know how to write test.

### Stretch Goals
Implement these if you have time and want to, but be prepared to discuss during interview
regardless of whether you implement them or not.

* Use **Problem Details** (`application/problem+json`) for 400/404/409.
* Implement Caching (e.g., in-memory or distributed cache) for GET endpoints.
* Basic **validation** (FluentValidation optional or custom attributes).
* Add observability (logging, metrics, tracing) to the API.
* Add remaining CRUD endpoints for all the domain models  

## Deliverables

Source code (either in a public repo or as a zip file)

A short ARCHITECTURE.md covering:
- Code structure, design choices. How will you scale?
- Did you make any changes to the API endpoints or Domain model? Why?
- Why controllers vs minimal APIs.
- Error handling strategy - for example concurrency and idempotency design.
- Caching strategy.

HTTP file with example requests (include auth flow).

## Requirements
- .NET 9 SDK
- Development Environment: Visual Studio 2022, VSCode, Jetbrains Rider, etc.

## Data model
The `Training.Data` project contains a `TrainingDbContext` with the model to use for this exercise.

It's seeded with a single Athlete (See `TrainingDataSeed.SeedData`) and two users 
