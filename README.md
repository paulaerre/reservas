# Reservas | Challenge.

Se realiza un backend .NET 8 en proyecto ASP.NET Core, con base de datos Sqlit3 y React en el frontend.

### Instrucciones de ejecución
## Backend
- Clonar el repositorio
- Abriendo una terminal en la raiz del proyecto, correr `cd reservas-backend/ReservasAPI/`
- Abrir la solución con Visual Studio teniendo en cuenta el SDK indicado previamente
- Compilar la solución desde el menú desplegable correspondiente.
- Ejecutarlo con F5.
- El backend puede testearse con la interfaz de swagger integrada, desde postman o el tester de RestAPIs que se desee.
- Se accede a la base de datos automáticamente al abrir el proyecto, es el archivo `appointments.db`, por lo que no tenemos que realizar ningún paso para la conexión.
## Frontend
- Si bien se puede abrir en cualquier IDE, estas instrucciones son para Visual Studio Code
- Volvemos a la terminal y corremos los siguientes comandos:
- `cd reservas-frontend`
- `code .` para abrir el proyecto.
- Instalamos las dependencias con `npm i`
- Corremos el proyecto con `npm run dev`

El proyecto está listo para ser utilizado.

# API endpoints

## GET
 [/appointments](#GET-appointments) <br/>
 [/appointments/timeslots](#GET-appointmentstimeslots) <br/>
 [/services](#GET-services) <br/>

## POST
[/appointment](#POST-appointment) <br/>

### GET /appointments
Lista todas las reservas de la applicación

**Parámetros**

Ninguno.

**Response**
```json List
[
  {
    "id": 0,
    "date": "string",
    "time": "string",
    "client": "string",
    "serviceId": 0
  },
  {
    "id": 0,
    "date": "string",
    "time": "string",
    "client": "string",
    "serviceId": 0
  }
]
```

### GET /services
Lista todos los servicios de la applicación


**Parámetros**

Ninguno.

**Response**
```json List
[
  {
    "id": 0,
    "name": "string"
  },
  {
    "id": 0,
    "name": "string"
  }
]
```

### GET /appointments/timeslots
Lista todos los horarios disponibles según la fecha enviada

**Parámetros**

- `date` (query parameter): La fecha para la cual queremos ver los horarios disponibles. Debe estar en formato `DD-MM-YYYY`

**Response**
```json List
[
  "10",
  "11",
  "14",
]
```

### POST /appointment
Crea una reserva

**Parámetros**

Body:
|          Name | Required |  Type     | Description                      |
|---------------|----------|-----------| ---------------------------------|
|       `date`  | required | DateTime  | El día de la reserva.            |  
|       `time`  | required | string    | El horario de la reserva.        |  
|      `client` | required | string    | El nombre del Cliente.           |  
|   `serviceId` | required | int       | El id de servicio de la reserva. |  

**Response**

```json
{
    "id": 0,
    "date": "string",
    "time": "string",
    "client": "string",
    "serviceId": 0
  }
```
