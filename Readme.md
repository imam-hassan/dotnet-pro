# dotnet-pro

**dotnet-pro** is a robust Telecommunication Management System built on .NET. It provides a central platform to monitor telecommunication towers and efficiently assign maintenance jobs to field technicians.

## 🚀 Key Features

* **Tower Monitoring:** Keep track of live telecom tower statuses and metrics.
* **Technician Dispatch:** Manage field personnel records, specialized skills, and workloads.
* **Automated & Manual Assignment:** Streamline the allocation of repair tasks to available tech teams.
* **Maintenance Job Tracking:** Monitor the lifecycle of maintenance requests from creation to completion.

---

## 🗺️ API Endpoints & Accurate JSON Payloads

The Web API exposes four primary REST endpoints. Below are the precise property mappings, data constraints, and expected JSON structures derived directly from the application's core data structures.

### 1. Towers (`/api/tower`)
Used to monitor physical telecom infrastructure, spatial coordinates, and physical properties.

* **Supported Methods:** `GET`, `POST`, `PUT`, `DELETE`
* **Validation Rules:** `TowerId` max 50 chars; `SiteName` max 200 chars; `Location` max 500 chars; `State` max 100 chars; `TowerHeight` ranges from 1.0 to 500.0 meters.
* **Enum Lookups:**
  * `TowerType`: `0` (Monopole), `1` (Lattice), `2` (Guyed)
  * `Status`: `0` (Active), `1` (UnderMaintenance), `2` (InActive)
* **Sample Payload (`POST` / `PUT`):**
```json
{
  "towerId": "TWR-FCT-001",
  "siteName": "Zuma Rock Broadcast Terminal",
  "location": "Suleja-Abuja Expressway",
  "state": "Federal Capital Territory",
  "latitude": 9.123456,
  "longitude": 7.234567,
  "towerType": 1,
  "towerHeight": 120.5,
  "installationDate": "2026-10-01T10:30:00Z",
  "status": 0
}
```

### 2. Maintenance Jobs (`/api/maintenance-jobs`)
Used to register field issues, schedule maintenance, and update repair details.

* **Supported Methods:** `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}`
* **Validation Rules:** `JobTitle` between 5 and 150 chars; `Description` between 5 and 500 chars.
* **Enum Lookups:**
  * `JobType`: `0` (PreventiveMaintenance), `1` (CorrectiveMaintenance), `2` (EquipmentInstallation), `3` (GeneratorMaintenance), `4` (BatteryReplacement), `5` (TowerInspection)
  * `Priority`: `0` (Low), `1` (Medium), `2` (High), `3` (Critical)
  * `Status`: `0` (Pending), `1` (Assigned), `2` (InProgress), `3` (Completed), `4` (Canceled)
* **Sample Payload (`POST` / `PUT`):**
```json
{
  "jobID": "JOB-2026-09A",
  "jobTitle": "Replace Damaged Backup Generator Battery",
  "description": "The cooling fan on the backup diesel generator failed, causing severe overheating.",
  "jobType": 4,
  "priority": 2,
  "dateReported": "2026-10-07",
  "scheduledDate": "2026-10-08",
  "completionDate": null,
  "status": 0,
  "remarks": "Requires dispatch of senior power technician with safety gear."
}
```

### 3. Technicians (`/api/technicians`)
Manages structural field operations engineering data, skills, and emergency contact registries.

* **Supported Methods:** `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}`
* **Validation Rules:** `FName` between 2 and 150 chars; `Address` max 500 chars; `PhoneNumber` requires true phone formatting.
* **Enum Lookups:**
  * `Skill` (Specialization): `0` (Electrical), `1` (Network), `2` (Rf), `3` (Power_Systems), `4` (GeneratorMaintenance), `5` (TowerMaintenance)
  * `AvailabilityStatus`: `0` (Available), `1` (Busy), `2` (OnLeave)
  * `Status` (AvailableStatus): `0` (Active), `1` (InActive)
* **Sample Payload (`POST` / `PUT`):**
```json
{
  "fName": "Chidi Okonkwo",
  "phoneNumber": "+2348012345678",
  "email": "chidi.okonkwo@telecom.com",
  "address": "12 Abuja Tower Way, Central Area, Abuja",
  "dateOfEmployment": "2024-03-15",
  "skill": 3,
  "experienceLevel": "Senior Engineer",
  "availabilityStatus": 0,
  "status": 0
}
```

### 4. Assign (`/api/assign`)
Maps specific technician relational profiles onto pending infrastructure work order items.

* **Supported Methods:** `POST`, `GET /{id}`, `DELETE /{id}`
* **Sample Payload (`POST`):**
```json
{
  "technicianId": 1,
  "dateAssigned": "2026-10-07T16:00:00Z",
  "maintenanceJobId": 3
}
```

---

## 🛠️ Prerequisites

Ensure you have the following software installed locally:
* **[.NET 8.0 SDK](https://microsoft.com)** (or higher)
* An IDE such as **[Visual Studio 2026](https://microsoft.com)** or **[VS Code](https://visualstudio.com)** (with the C# Dev Kit extension).
* **[SQL Server Express / Developer Edition](https://microsoft.com)** & **[SQL Server Management Studio (SSMS)](https://microsoft.com)** to host and run operations on your backend `AppDbContext`.

---

## 🏁 Getting Started

Follow these steps to spin up the API locally:

### 1. Clone the Repository
```bash
git clone https://github.com/imam-hassan/dotnet-pro
```

### 2. Configure the Database Connection
Open `appsettings.json` and adjust the connection string to match your local SQL Server environment parameters:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=DotNetProDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 3. Restore Dependencies & Run Migrations
Download NuGet packages and build your schemas (`Assigments`, `MaintenanceJobs`, `Technicians`, and `Towers`):
```bash
dotnet restore
dotnet ef database update
```

### 4. Build and Launch the Project
```bash
dotnet build
dotnet run
```

---

## 📅 Development Roadmap (Under Production)

This project is actively being developed. The following architecture components and features are scheduled for upcoming releases:

- [ ] **Service Layer:** Abstracting business logic out of controllers into dedicated business services.
- [ ] **Data Transfer Objects (DTOs):** Implementing clean mapping request/response records to isolate database entities from the presentation layer.
- [ ] **Authentication & Authorization:** Securing endpoints via JWT (JSON Web Tokens) and Role-Based Access Controls (RBAC) for Admins vs Field Technicians.
- [ ] **Advanced Business Rule Validation:** Enforcing strict scheduling logic (e.g., stopping assignments if a technician status is set to `OnLeave` or `Busy`).

---

## 📄 License
This project is licensed under the MIT License.
