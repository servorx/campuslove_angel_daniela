# ❤︎ Campus Love ❤︎  
**Aplicación de emparejamiento en consola (C#)**  

---

## 📌 Autores  
- **Ángel David Pinzón Serrano**  
- **Daniela Sofía Herrera Rojas**  

---

## 📖 Descripción del Proyecto  
**Campus Love** es una aplicación de consola en **C#** que simula un sistema de emparejamiento entre estudiantes de Campuslands.  
El sistema permite registrar usuarios, visualizar perfiles, dar **“Like”** o **“Dislike”**, revisar coincidencias (**matches**) y consultar estadísticas de interacción.  

El proyecto está desarrollado aplicando:  
- **Arquitectura limpia**  
- **Principios SOLID**  
- **Patrones de diseño**  
- **Colecciones genéricas y LINQ**  
- **Buenas prácticas de validación y formateo**  

Adicionalmente, incorpora un sistema de **créditos de interacción** que limita la cantidad de likes diarios por usuario.

---

## 🎯 Objetivos del Proyecto  
- Simular un sistema de emparejamiento universitario.  
- Practicar y aplicar conceptos avanzados de **POO en C#**.  
- Implementar un diseño basado en **patrones** y **principios SOLID**.  
- Usar **LINQ** y **colecciones** para el manejo de datos.  
- Fomentar un flujo de interacción amigable en consola.  

---

## ⚙️ Especificaciones del Sistema  

### ✔️ Funcionalidades principales  
- Registro de usuarios (nombre, edad, género, intereses, carrera, frase de perfil).  
- Visualización de perfiles disponibles (uno por uno) para dar **Like** o **Dislike**.  
- Generación de coincidencias (**match**) si ambos usuarios se dan Like.  
- Listado de todas las coincidencias de un usuario.  
- Límite de **likes diarios** por usuario con lógica matemática.  
- Estadísticas con LINQ:  
  - Usuario con más likes recibidos.  
  - Usuario con más matches.  
  - Promedio de interacciones.  

---

## 📋 Requisitos  

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

---

## 📊 Diagramas  

### 📌 Diagrama de Clases (ejemplo conceptual)  
- **Usuario**  
- **Like**  
- **Intereses**  
- **InteresesUsuario**  
- **Dislike**  

---

## 🛠️ Herramientas y Tecnologías  
- **Lenguaje:** C#  
- **Framework:** .NET Core 9.0  
- **IDE sugerido:** Visual Studio Code  
- **Control de versiones:** Git + GitHub  

---

## 💡 Sugerencias de implementación  
- Usar `List<Usuario>` para guardar likes.  
- Usar **LINQ** para:  
  - Buscar matches.  
  - Ordenar por likes.  
  - Contar usuarios activos.  
- Aplicar **patrón Strategy** para definir reglas de emparejamiento (por intereses, edad, carrera).  
- Usar `Math.Min` y `Math.Max` para controlar límites de likes diarios.  

---

## 📦 Entregables del Proyecto  
- Código fuente completo en C#.  
- Archivos **SQL** para la base de datos.  
- Listado de **tablas de base de datos** utilizadas por cada componente.  
- Listado de **clases y servicios** utilizados en cada módulo.  