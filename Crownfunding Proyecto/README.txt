Manual Técnico

1.	Introducción:
Crowdfunding es una plataforma que facilita la visibilidad y alcance de proyectos y/o emprendimientos con el objetivo de obtener algún tipo de incentivo no monetario como ser: Becas, Cursos de capacitación, entre otros.
En este Manual Técnico se describirán la funcionalidad del proyecto y los pasos a seguir para su instalación.  
2.	Descripción del proyecto:
El objetivo del proyecto es proporcionar un lugar para que los usuarios puedan solicitar ayudas o incentivos no monetarios para sus proyectos. El proyecto también proporciona visibilidad de los proyectos y aumenta sus posibilidades de éxito.

El proyecto de crowdfunding fue desarrollado en el lenguaje C# con la plantilla de ASP.NET Core, esta es una plataforma que permite a los usuarios registrarse en el sitio y crear proyectos para recibir ayudas o incentivos no monetarios, como becas, cursos, talleres, etc. Los usuarios también pueden seguir los proyectos de otros usuarios, y los administradores que realizan un seguimiento de los proyectos que son subidos a la plataforma.

El usuario que recibe un apoyo puede hacer una review de su patrocinador para confirmar que efectivamente ha recibido el apoyo acordado previamente.

Las características principales del proyecto incluyen:

-	Creación de cuentas para nuevos usuarios.
-	Creación de proyectos especificando el tipo de apoyo que se desea recibir.
-	Seguimiento de proyectos.
-	Control de proyectos por parte de administradores.
-	Apartado de revisión personal de apoyos recibidos.
-	Perfil personal donde se visualizan los proyectos propios, en seguimiento y apoyados.

3.	Roles / integrantes
LEADER/DEVELOPER: Sacha Rigel Flores Delgadillo

Responsabilidades: Encargado del liderazgo del proyecto y desarrollo de características clave. Coordina la colaboración entre los diferentes miembros del equipo.
DEVELOPER/QA: Diego Anthony Flores Sudanez

Responsabilidades: Desarrollador con enfoque en aseguramiento de la calidad. Encargado de realizar pruebas exhaustivas para garantizar la estabilidad y funcionalidad del software.
DEVELOPER/GIT MASTER: Victor Hugo Tapia Leon

Responsabilidades: Encargado en el sistema de control de versiones Git. Encargado de gestionar ramas, fusiones y asegurar la integridad del código base. Encargado del front-end.
DEVELOPER/DB MASTER: Cristian Nahuel Callisaya Viza

Responsabilidades: Encargado en administración de bases de datos. Encargado de diseñar la base de datos del proyecto. Asegura la integridad de las operaciones de la base de datos.
4.	Arquitectura del software: 

Frontend:
El frontend está desarrollado con ASP.NET integrado con HTML, JSON y CSS. La estructura de archivos incluye:

ASP.NET Pages: Utilizadas para construir la interfaz de usuario y gestionar las interacciones del usuario.

HTML: Incorporado en las páginas Razor para la estructura y presentación de la interfaz.

JSON: Se utiliza en la misma página para almacenar datos, proporcionando una fuente de información dinámica.

CSS: Los estilos están organizados en carpetas para una fácil gestión y mantenimiento.

Backend:
El backend utiliza SQL Server como base de datos y sigue la arquitectura DAO (Data Access Object). La estructura de carpetas incluye:

Modelos: Contiene las clases para construir objetos que representan las entidades en la base de datos.

Vistas: Incluye métodos de implementación para interactuar con las clases de modelos y realizar operaciones CRUD.

Implementaciones: Contiene la cadena de conexión y todas las clases necesarias para las operaciones CRUD de las tablas.

Patrones de Diseño:
El proyecto ASP.NET con Razor Pages se centra en la construcción de páginas Razor para las vistas. Además, se integra con un proyecto DAO que almacena las clases de implementación (Impl) para realizar las operaciones CRUD en la base de datos. Este enfoque sigue un patrón de diseño modular y separación de preocupaciones para facilitar el mantenimiento y la escalabilidad del sistema.

 
5.	Requisitos del sistema:

Requerimientos de Hardware (Cliente)
Computadora personal con al menos 4 GB de RAM.
Procesador Intel Core i3 o equivalente.
Pantalla con resolución mínima de 1366 x 768 píxeles.
Ratón o dispositivo apuntador compatible.
Teclado estándar.

Requerimientos de Software (Cliente)
Sistema operativo compatible: Windows 10 o posteriores.
Navegador web actualizado: Microsoft Edge, Google Chrome o Mozilla Firefox.

Requerimientos de Hardware (Servidor/Hosting/BD)
Servidor con al menos 8 GB de RAM.
Procesador multicore.
Espacio en disco suficiente para almacenar datos y realizar Backups periódicos.

Requerimientos de Software (Servidor/Hosting/BD)
Sistema operativo compatible para el servidor: Windows Server 2016 o posterior.
Servidor web: IIS (Internet Information Services) configurado y habilitado.
Base de datos: Microsoft SQL Server 2022 o posterior.

6.	Instalación y configuración: 
Instalación del software
Tener instalado previamente Visual Studio Community.

Para usar el software, se deben seguir los siguientes pasos:

Crear una carpeta nueva para guardar el programa descargado desde el repositorio git.
Descargar el software desde el repositorio de GitHub.

Navegar por la carpeta hasta encontrar el archivo sln para abrirlo con el programa de Visual Studio.

En la solución de CrowfundingDAO dirigirse a la carpeta Implementation y a la clase “BaseImpl” para cambiar la cadena de conexión string en la línea 15 con el siguiente formato:
   string connectionString = @ " S e r v e r = su localhost ; Database=nombreBaseDeDatos;
User Id= suUsuario; 
Password= suContraseña; ";


7.	PROCEDIMIENTO DE HOSTEADO / HOSTING (configuración)
•	Sitio Web.
Descargar el proyecto del repositorio




•	B.D.
Usando las imagen del proyecto cargarlo en un Windows server, (CrowdFundingDAO) cambiar el Puerto en la Carpeta ‘Implementation’, en la clase BaseImpl.cs y en la cadena de conexión cambiar puerto según sea su servidor de B.D. Usar localhost en caso sea local.

“Server = localhost,1434: Database = Crowdfunding; User Id = suUsuario; Password = suContraseña;”

Verificar con el de la otra imagen que estén Correctos e iguales.

Credenciales:
	Nombre usuario: Brande123@gmail.com
	Contraseña: Brande123
	*BD-con .bak 
Base de datos:
Ya tener instalado el programa de SQL Server.
Localizar  el archivo .bak que contiene nuestra base de datos ya poblado
Este se encuentra en Crownfunding/CrownfundingProyecto/Crowfunding.bak.

Restaurar esta base de datos y listo.

El servicio de sqlserver debe estar activo.

Ahora ya puede iniciar la aplicación , puede registrarse  o usar alguna de las sgtes cuentas 
Correo				Password			Rol
Brande123@gmail.com		Brande123			Admin
marcocallejas@gmail.com		marcocallejas			User
 
SaraCol_2@gmail.com		SaraCol			User


•	API / servicios Web

•	Otros (firebase, etc.)


8.	GIT: 

Link del Git: https://github.com/VictorHugoTapLeo/Crownfunding.git

9.	Personalización y configuración: 
Puede Personalizarse mediante código del Software en el ‘wwwroot’ ya que es donde se guarda el tema de los diseños de las páginas.
Y dentro del software puede configurar la información del usuario, editándolo según las necesidades del Usuario. 
También Configurar Proyectos subidos en la plataforma.

10.	Seguridad: 

Autenticación

Los usuarios deben autenticarse antes de realizar donaciones o crear proyectos.

Gestión de Roles

La aplicación debe tener roles como "Usuario", y "Administrador" 
Los administradores tienen acceso a funciones administrativas, mientras que los Usuarios pueden gestionar sus proyectos.
Restringiendo el acceso de acuerdo a su rol.

Encriptación de Datos Sensibles:

Las contraseñas de los usuarios son altamente seguras con la función de cifrado.


11.	Depuración y solución de problemas: 
Para depurar y solucionar problemas de la plataforma, se pueden utilizar las siguientes herramientas:
-	Visual Studio: IDE de desarrollo de software.
SQL Server Management Studio: herramienta de administración de bases de datos.


12.	Glosario de términos:
Apoyo Recibido: Cuando se efectúa algún patrocinio a un proyecto
Review Apoyo: El control de usuario hacia su patrocinador.
ASP.NET Core: Framework de desarrollo web de código abierto desarrollado por Microsoft. Es una versión modular y de alto rendimiento de ASP.NET que es multiplataforma y compatible con la nube. 
Razor: Sintaxis de marcado utilizada en las vistas de ASP.NET Core para combinar código C# con HTML. Facilita la creación de páginas web dinámicas.
Razor Pages: Característica de ASP.NET Core que simplifica el desarrollo de páginas web al combinar el código C# y el HTML en un único archivo.

13.	Referencias y recursos adicionales: 
Documentación de ASP.NET
https://learn.microsoft.com/es-es/aspnet/core/?view=aspnetcore-8.0

Documentación de Microsoft SQL
https://learn.microsoft.com/es-es/aspnet/core/?view=aspnetcore-8.0

14.	Herramientas de Implementación:
•	Lenguaje de Programación:  C#.
•	Framework: ASP.NET y NET.FRAMEWORK.
•	Plataforma DB: SQL Server.

15.	Bibliografía

Guia de dockerizado Sql
https://hub.docker.com/r/rapidfort/microsoft-sql-server-2019-ib
Correcion de Versiones Kernel/Docker
https://www.youtube.com/watch?v=aJ76VCZczBw
Guia de Razor Pages aplicación web
https://www.youtube.com/watch?v=3F9SpUYTB6Y&list=PL6n9fhu94yhX6J31qad0wSO1N_rgGbOPV
INTRODUCCION A ASP.NET CORE
https://learn.microsoft.com/es-es/aspnet/core/mvc/overview?view=aspnetcore-8.0




LEGITIMO



