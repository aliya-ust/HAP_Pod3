# HealthCare — Agent Instructions

## Repository

4 projects in a .NET 10 solution (`HealthCare.slnx`) + 1 standalone Angular app:

| Project | Type | Entry point |
|---------|------|-------------|
| `HealthCare.Api/` | ASP.NET Core Web API | `Program.cs` |
| `HealthCare.Admin/` | Blazor WebAssembly | `Program.cs` |
| `HealthCare.Shared/` | Class library | DTOs + `ApiResponse<T>` |
| `HealthCare.Api.Tests/` | xUnit test suite | — |
| `HealthCare.Portal/` | Angular 21 (standalone, not in `.slnx`) | `ng serve` on :4200 |

## Commands

- `dotnet build` — build solution
- `dotnet test` — run all unit tests (81 tests)
- `dotnet run --project HealthCare.Api` — API (http://localhost:5090 / https://localhost:7223)
- `dotnet run --project HealthCare.Admin` — Blazor admin (calls API at https://localhost:7223)
- `ng serve` in `HealthCare.Portal/` — Angular portal (http://localhost:4200)
- `.\run-sonar.bat` — local SonarQube scan (requires `dotnet sonarscanner` + SonarQube on localhost:9000)
- `.\start-logging.bat` — start Elasticsearch (http://localhost:9200) + Kibana (http://localhost:5601)
- `.\start-elasticsearch.bat` — start Elasticsearch only
- `.\start-kibana.bat` — start Kibana only
- `.\stop-logging.bat` — stop Elasticsearch and Kibana

## Auth & Unified Login Flow

- **Single login page**: Angular Portal at `http://localhost:4200/login` is the only login page.
- **Admin redirect**: After login, if JWT role is `"Admin"`, Angular redirects to `https://localhost:7166/auth-callback?token={jwt}`.
- **AuthCallback.razor**: Blazor page at `/auth-callback` reads the token from query string and stores it in `localStorage` (key `authToken`) via `TokenService.SetToken()`.
- **No Blazor login page**: `Login.razor` was deleted. All Blazor pages have no `[Authorize]` attributes — the API enforces auth server-side.
- **Token attachment**: `AuthTokenHandler` (DelegatingHandler) reads `authToken` from localStorage and attaches `Authorization: Bearer` to every request via the named `AdminPortalAPI` HttpClient.
- **401 redirect**: `GlobalExceptionHandler` redirects to `http://localhost:4200/login` on 401.

## Quirks & Conventions

- **DTO namespace**: DTOs sit in `HealthCare.Shared/DTOs/` but use namespace `HealthCare.Shared.DTOs.*` (migrated from `HealthCare.Api.DTOs.*`).
- **DbContext**: `HealthCareDbContext` extends `IdentityDbContext<User>` (fixed from `IdentityDbContext<IdentityUser>`).
- **JWT claims**: Tokens carry custom `PatientId` / `DoctorId` claims. Controllers extract them via `ClaimsHelper.GetPatientId(User)` / `ClaimsHelper.GetDoctorId(User)` (static class in `Utilities/`).
- **CORS**: Allows `https://localhost:7166` (Blazor Admin) and `http://localhost:4200` (Angular Portal).
- **Admin API URL**: Set in `HealthCare.Admin/wwwroot/appsettings.json` under `ApiBaseUrl`.
- **ApiResponse wrapping**: All API controllers wrap returns in `ApiResponse<T>.Ok()` / `ApiResponse.Fail()`. Admin services unwrap `.Data`.
- **Error handling**: `GlobalExceptionHandler` (IExceptionHandler) maps domain exceptions (`*NotFoundException`) to 404, `DbUpdateException` to 500, `InvalidLoginException` to 401, `InvalidOperationException` to 400.
- **Custom exceptions**: `PatientNotFoundException`, `DoctorNotFoundException`, `AppointmentNotFoundException`, `HealthRecordNotFoundException`, `DbHandleException`, `InvalidLoginException`, `EmailAlreadyInUseException`, `RoleNotAssignedException`, `InvalidRoleException`, `UserNotFoundException`, `IdentityOperationException`, `NoAvailableSlotsException`, `SlotAlreadyBookedException`, `PastAppointmentException`.
- **Controllers**: Each domain entity has a public controller and an `*AdminController` for admin operations.
- **Seed data**: DbContext seeds one Doctor + one Patient. `RoleSeeder` and `UserSeeder` run at startup.
- **.gitignore**: Covers `.vs/`, `bin/`, `obj/`, `.sonarqube/`, `TestResults/`, `appsettings.Development.json`, `node_modules/`, `dist/`, `tools/elasticsearch/`, `tools/kibana/`.

## Testing

- **Framework**: xUnit + Moq + EF Core InMemory.
- **Pattern**: Each test class creates a unique InMemory DB via `new DbContextOptionsBuilder<HealthCareDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString())`.
- **Not-found assertions**: Services throw custom exceptions (`*NotFoundException`); tests assert with `Assert.ThrowsAsync<*NotFoundException>`.
- **GetAllAsync tests**: Mock `GetQueryable()` by returning `_context.Set<T>()` (real EF DbSet with async support) and seed data into the InMemory context.
- **No integration tests**: All 5 test files (`*ServiceTests.cs`) are pure unit tests with mocked repositories.
