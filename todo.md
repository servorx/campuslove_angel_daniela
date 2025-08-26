primero debe de aparecer un mensaje de bienvenida 

el usuario debe de poder registrarse y crear una cuenta

el usuario debe de poder ver perfiles de otras personas con sus respectivas caracteristicas 

el usuario debe de poder escoger a cual usuario le da like y a cual no, debe de mostrar uno por uno y darle like o no, debe de ser una cantidad limitada

revisar matches (si a mi me ha dado like la misma persona a la que le di like)





Menu principal:

Crear usuario
Salir del programa

Funcionalidad de crear usuario:
Ingresar todos los datos del usuario e ingresar al MenuUsuario

MenuUsuario:

Ver todas las personas
Dar likes o dislike (mostrar persona por persona y dar like o no, limitar la cantidad de likes)
Ver coincidencias si dos usuarios se dan Like mutuamente. (matches)
Listar todas las coincidencias de un usuario.
Mostrar el usuario con mas likes recibidos.




crear el paswordHash
finish menus
refactorizar las partes innecesarias 
crear validaciones para todas las entradas



Revisar que el programa pueda cumplir con esto :
    Registro de usuarios (nombre, edad, género, intereses, carrera, frase de perfil).
    Visualización de perfiles disponibles (uno por uno) para dar Like o Dislike.
    Generación de coincidencias (match) si ambos usuarios se dan Like.
    Listado de todas las coincidencias de un usuario.
    Límite de likes diarios por usuario con lógica matemática.
    Estadísticas con LINQ:
    Usuario con más likes recibidos.
    Usuario con más matches.
    Promedio de interacciones.



### ✅ Requisitos funcionales  
- Menú en consola con las opciones:  
  1. Registrarse como nuevo usuario.  
  2. Ver perfiles y dar Like o Dislike.  
  3. Ver mis coincidencias (matches).  
  4. Ver estadísticas del sistema.  
  5. Salir.  
- Almacenamiento de usuarios e interacciones en **listas** o **diccionarios**.  
- Simulación de múltiples usuarios (**modo multicliente ficticio**).  
- Uso del **patrón Factory** para creación de usuarios o interacciones.  
- Separación de responsabilidades aplicando **SOLID**.  

### ⚡ Requisitos no funcionales  
- Interacción amigable, clara y fluida en consola.  
- Clases organizadas por responsabilidades (**Usuario, Interaccion, MatchService, etc.**).  
- Validación de entrada (**edad, texto, género, etc.**).  
- Uso de conversiones y formateo:  
  - `int.Parse`, `TryParse`  
  - `ToUpper`, `ToLower`  
  - `CultureInfo`, `NumberFormat`  