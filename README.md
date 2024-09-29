# Ejercicio Cursos

Se debe crear una página para visualizar los datos de un curso desde la base de datos.

**Courses**
- Name (requerido, min 10, max 100)
- Description (opcional, max 1000)
- CourseType (virtual, presencial) => combo cargado desde CourseTypes
- Active
- Visible
	
Dicha pagina debe verificar en base a una configuración si está habilitado para visualizar y para editar los datos (en el front y en el back verificar si tiene permisos de edición). El modulo de cursos es el llamado **"courses"** y las acciones son **"view"** y **"edit"** respectivamente. Si puede editar se muestra el botón y en caso contrario se quita del HTML.

**Permissions**
- Module
- Feature
- Description
- Enabled
 
Una vez cargados y enviados los datos en caso de tener permisos se debe mostrar un mensaje de confirmación en otra pantalla con los datos interesados. Si el usuario acepta se envía a la API y en caso contrario se vuelve a la página anterior con los datos cargados. 
En el mismo momento en que se da de alta el curso se debe agregar un registro en la tabla Logs con la siguiente informacion:

**Logs**
- Data (objeto curso en formato JSON)
- DataId (Id curso)
- Date
- User (legajo en formato string)

En caso de guardarse exitosamente se le debe mostrar un mensaje al usuario con el ID del registro generado.

Se debe utilizar el enfoque **DataBase First** con los siguientes datos de conexion:
- Server: SQL5111.site4now.net
- Base Datos: db_aa579f_courses
- Usuario: db_aa579f_courses_admin
- Password: c0urses_202a_tup
	
