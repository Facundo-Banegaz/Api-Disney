# API Disney

Esta es una **Web API** construida en **C#** que gestiona información sobre personajes, películas y géneros de Disney. La API está diseñada para ofrecer funcionalidades completas de autenticación, autorización y operaciones CRUD, con un enfoque en la protección de rutas según los roles de los usuarios.
## Funcionalidades

- **Autenticación y Autorización**: Registro de usuarios, inicio de sesión y protección de rutas mediante **JWT**. El acceso a determinadas rutas está controlado por roles de usuario.
  
- **Operaciones CRUD**: 
  - **Personajes**: Crear, leer, actualizar y eliminar personajes.
  - **Películas**: Crear, leer, actualizar y eliminar películas.
  - **Géneros**: Crear, leer, actualizar y eliminar géneros.
  - Estas operaciones están disponibles solo para usuarios autorizados.

- **Listados y Detalles**: 
  - Ver todos los personajes, películas y géneros disponibles.
  - Consultar detalles específicos de un personaje, película o género. Algunos accesos requieren autorización.

- **Búsqueda y Filtros**: 
  - Funcionalidades para buscar personajes, películas y géneros por distintos criterios.
  - Filtrar resultados según diferentes atributos.
  - Algunas rutas de búsqueda están protegidas por roles de usuario.



## Tecnologías

- **WEB API .NET Core 8.0**
- **Entity Framework Core**
- **SQL Server**
- **CORS** configurado para permitir solicitudes desde el frontend
- **Swagger** para la documentación interactiva


## Endpoints
### Autenticación

| Método | Endpoint                 | Descripción                           |
|--------|--------------------------|---------------------------------------|
| POST   | `/api/auth/register`     | Registra un nuevo usuario.            |
| POST   | `/api/auth/login`        | Inicia sesión y devuelve un token JWT.|


### Géneros (Genres)

| Método | Endpoint                 | Descripción                           |
|--------|------------------------- |---------------------------------------|
| GET    | `/api/Genres`            | Obtiene todos los géneros.            |
| GET    | `/api/Genres/{id}`       | Obtiene un género por ID.             |
| POST   | `/api/Genres`            | Crea un nuevo género.                 |
| PUT    | `/api/Genres/{id}`       | Actualiza un género existente.        |
| DELETE | `/api/Genres/{id}`       | Elimina un género por ID.             |

### Películas (Movies)

| Método | Endpoint                 | Descripción                          |
|--------|--------------------------|--------------------------------------|
| GET    | `/api/Movies`            | Obtiene todas las películas.         |
| GET    | `/api/Movies/{id}`       | Obtiene una película por ID.         |
| GET    | `/api/Movies/filter`     | Filtra películas según criterios.    |
| POST   | `/api/Movies`            | Crea una nueva película.             |
| PUT    | `/api/Movies/{id}`       | Actualiza una película existente.    |
| DELETE | `/api/Movies/{id}`       | Elimina una película por ID.         |

### Personajes (Characters)

| Método | Endpoint                  | Descripción                           |
|--------|---------------------------|---------------------------------------|
| GET    | `/api/Characters`         | Obtiene todos los personajes.         |
| GET    | `/api/Characters/{id}`    | Obtiene un personaje por ID.          |
| GET    | `/api/Characters/filter`  | Filtra personajes según criterios.    |
| POST   | `/api/Characters`         | Crea un nuevo personaje.              |
| PUT    | `/api/Characters/{id}`    | Actualiza un personaje existente.     |
| DELETE | `/api/Characters/{id}`    | Elimina un personaje por ID.          |


## Instalación

### Requisitos Previos

- .NET 6.0 SDK o superior
- SQL Server (o cualquier otro servidor de base de datos compatible)
- Visual Studio 2022 (opcional pero recomendado)

### Configuración del proyecto

1. Clona este repositorio en tu máquina local.

   ```bash
   git clone https://github.com/tu_usuario/tu_proyecto_api.git
