# Map Demo (Angular + ASP.NET Core / ASP.NET 6+)

This repository demos an Angular SPA and an ASP.NET Core web API application.

## Demo
## Solution Structure

This repository includes two applications: an Angular SPA in the `angular` folder, and an ASP.NET Core web API app in the `webapi` folder. The SPA makes HTTP requests to the server side (the `webapi` app) using an API BaseURL `https://localhost:5001`. The API BaseURL is set in the `environment.ts` file and the `environment.prod.ts` file, which can be modified based on your situation.

- `angular`
  The SPA is served using NGINX on Docker. The application demonstrates JWT authorization in the front-end.
- `webapi`
  The ASP.NET Core web API app is served by Kestrel on Docker. This app has implemented HTTPS support.

## Usage

The demo is configured to run by Docker Compose. The services are listed in the `docker-compose.yml` file. You can launch the demo by the following command.

```bash
docker-compose up --build --remove-orphans
```

Then visit [http://localhost:8080](http://localhost:8080) for the app, and [https://localhost:5001](https://localhost:5001) for Swagger document for the web API project.

**NOTE:** You can also move the folders around to consolidate the solution as one ASP.NET Core web app using the SPA service.

## Screenshots

- **Front-end** ([http://localhost:8080](http://localhost:8080))


- **Back-end** ([https://localhost:5001](https://localhost:5001))

## License

Feel free to use the code in this repository as it is under MIT license.
