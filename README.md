# Play System Trade - Microservices

### Docs

- Postman Collection: [Docs](./Docs)

### Play.Catalog

- Items

### Play.Common

- Lib package


## Installation

- Build the lib package: `dotnet pack -o <path>`
- Add package reference into Play.Catalog project: `dotnet nuget add source <path> -n PlaySystemTrade`

- Run Docker
  - `docker compose up` (optional: run with `-d` parameter for detach mode)
