# Instrucciones:

# Base de datos:
- Se debe ejecutar la migración del proyecto "PruebaTecnicaUltragroup.Infrastructure" a fin de crear las tablas, para lo cual en el servidor se debe crear una base de datos con el nombre "DBPruebaUltragroup".
- Desde Visual Studio en la consola de Administrador de Paquetes se debe seleccionar como proyecto predeterminado "PruebaTecnicaUltragroup.Infrastructure" y ejecutar la instrucción "dotnet ef database update -p PruebaTecnicaUltragroup.Infrastructure -s PruebaTecnicaUltragroup.Api".

# Proyecto:
- Se debe tener presente que la versión utilizada para la solución es NET Core 8
- Se debe cambiar el nombre del servidor a utilizar en el archivo "appsettings.json", en la clave "ConnectionStrings" y "PruebaUltragroup", en el apartado "Data Source". En caso de utilizar un servidor con conexión de usuario y clave sql se debe realizar el respectivo cambio y especificar estos datos en la cadena de conexión.
- Se debe establecer como proyecto de inicio "PruebaTecnicaUltragroup.Api", seleccionando el proyecto, clic derecho y seleccionar "Establecer como proyecto de inicio"

# Endpoints:
- /api/EmergencyContact => Corresponde a la gestión de los contactos de emergencia para las reservas (Creación = POST, Listado = GET, Búsqueda por id = GET)
- /api/Hotel => Corresponde a la gestión de los hoteles (Creación = POST, Actualización = PUT, Listado = GET, Búsqueda por id = GET, Habilitar/Deshabilitar = PATCH)
- /api/Hotel/Search => Corresponde a la búsqueda de hoteles con habitaciones disponibles para reserva (Ejemplo: api/Hotel/Search?checkIn=2025-03-01&checkOut=2025-03-10&guests=2&city=Cartagena)
- /api/HotelRoom => Corresponde a la gestión de las habitaciones de los hoteles (Creación = POST, Actualización = PUT, Búsqueda por id = GET, Habilitar/Deshabilitar = PATCH)
- /api/HotelRoom/Hotel/{idHotel} => Corresponde al listado de habitaciones para un hotel en especifico (GET)
- /api/Reservation => Corresponde a la gestión de la reserva (Creación = POST, Listado = GET, Búsqueda por id = GET)
- /api/ReservationDetail => Corresponde a la gestión del detalle de la reserva (Creación = POST, Obtener listado para una reserva especifica = GET)
