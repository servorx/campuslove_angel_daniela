DROP DATABASE IF EXISTS examen_csharp;
CREATE DATABASE IF NOT EXISTS examen_csharp;
USE examen_csharp;

-- esta seria la tabla principal de la base de datos
CREATE TABLE IF NOT EXISTS usuarios(
    id INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(80) NOT NULL,
    apellido VARCHAR(80) NOT NULL,
    correo VARCHAR(80) NOT NULL,
    constrasenia VARCHAR(40) NOT NULL,
    edad INT NOT NULL,
    carrera VARCHAR(100),
    frase VARCHAR (255),
    orientacion VARCHAR(70) NOT NULL, 
    busqueda VARCHAR(40) NOT NULL
) ENGINE=INNODB;

-- esto corresponde a los intereses que se coloca en tabla aparte porque un usuario puede tener mas de un interes
CREATE TABLE IF NOT EXISTS intereses(
    id INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(50) NOT NULL,
    descripcion TEXT
) ENGINE=INNODB;

-- tabla intermedia por la relacion de intereses y usuarios de muchos a muchos
CREATE TABLE IF NOT EXISTS intereses_usuarios(
    id_usuario INT NOT NULL,
    id_intereses INT NOT NULL,
    PRIMARY KEY (id_usuario, id_intereses),
    CONSTRAINT id_usuario_iu FOREIGN KEY (id_usuario) REFERENCES usuarios(id),
    CONSTRAINT id_intereses_iu  FOREIGN KEY (id_intereses) REFERENCES intereses(id)
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS likes (
    id INT PRIMARY KEY AUTO_INCREMENT,
    id_emisor INT NOT NULL,
    id_receptor INT NOT NULL,
    es_match BOOLEAN NOT NULL,
    CONSTRAINT fk_id_emisor_likes FOREIGN KEY (id_emisor) REFERENCES usuarios(id),
    CONSTRAINT fk_id_receptor_likes FOREIGN KEY (id_receptor) REFERENCES usuarios(id)
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS dislikes (
    id INT PRIMARY KEY AUTO_INCREMENT,
    id_emisor INT NOT NULL,
    id_receptor INT NOT NULL,
    CONSTRAINT fk_id_emisor_dislikes FOREIGN KEY (id_emisor) REFERENCES usuarios(id),
    CONSTRAINT fk_id_receptor_dislikes FOREIGN KEY (id_receptor) REFERENCES usuarios(id)
) ENGINE=INNODB;

-- Inserts para la tabla 'usuarios'
INSERT INTO usuarios (nombre, apellido, correo, constrasenia, edad, carrera, frase, orientacion, busqueda) VALUES
('Alejandro', 'López', 'alejandro@email.com', 'pass123', 25, 'Ingeniería en Sistemas', 'El código es mi lenguaje.', 'Heterosexual', 'Relación seria'),
('Valentina', 'Gómez', 'valentina@email.com', 'pass123', 23, 'Medicina', 'Sanando el alma y el cuerpo.', 'Bisexual', 'Amistad'),
('Carlos', 'Ramírez', 'carlos@email.com', 'pass123', 28, 'Arquitectura', 'Diseñando sueños en concreto.', 'Homosexual', 'Relación casual'),
('Sofía', 'Fernández', 'sofia@email.com', 'pass123', 22, 'Diseño Gráfico', 'Mi vida es un lienzo en blanco.', 'Heterosexual', 'Relación seria'),
('Diego', 'Sánchez', 'diego@email.com', 'pass123', 26, 'Psicología', 'Explorando las mentes del mundo.', 'Heterosexual', 'Amistad'),
('Camila', 'Torres', 'camila@email.com', 'pass123', 24, 'Periodismo', 'Contando historias, viviendo vidas.', 'Bisexual', 'Relación casual'),
('Daniel', 'Herrera', 'daniel@email.com', 'pass123', 29, 'Derecho', 'La justicia es la base de la sociedad.', 'Heterosexual', 'Relación seria'),
('Laura', 'Díaz', 'laura@email.com', 'pass123', 21, 'Comunicación Audiovisual', 'Creando mundos a través de la cámara.', 'Homosexual', 'Amistad'),
('Javier', 'Pérez', 'javier@email.com', 'pass123', 30, 'Historia', 'El pasado es la clave para el futuro.', 'Heterosexual', 'Relación seria'),
('Isabella', 'Rodríguez', 'isabella@email.com', 'pass123', 27, 'Ingeniería Civil', 'Construyendo un futuro sólido.', 'Heterosexual', 'Amistad'),
('Miguel', 'Castro', 'miguel@email.com', 'pass123', 25, 'Marketing', 'Estrategias para conectar personas.', 'Bisexual', 'Relación casual'),
('Elena', 'Ruiz', 'elena@email.com', 'pass123', 23, 'Nutrición', 'La salud es el mayor tesoro.', 'Heterosexual', 'Relación seria'),
('Sebastián', 'Gutiérrez', 'sebastian@email.com', 'pass123', 28, 'Finanzas', 'El dinero es solo una herramienta.', 'Homosexual', 'Amistad'),
('Marina', 'Vargas', 'marina@email.com', 'pass123', 22, 'Química', 'Descubriendo los secretos de la materia.', 'Heterosexual', 'Relación casual'),
('Jorge', 'Morales', 'jorge@email.com', 'pass123', 26, 'Música', 'Mi vida tiene banda sonora.', 'Heterosexual', 'Relación seria'),
('Paula', 'Navarro', 'paula@email.com', 'pass123', 24, 'Educación', 'Enseñar es aprender dos veces.', 'Bisexual', 'Amistad'),
('Fernando', 'Ortega', 'fernando@email.com', 'pass123', 29, 'Economía', 'Analizando el flujo de la vida.', 'Homosexual', 'Relación seria'),
('Andrea', 'Soto', 'andrea@email.com', 'pass123', 21, 'Literatura', 'Cada libro es un nuevo viaje.', 'Heterosexual', 'Relación casual'),
('Guillermo', 'Luna', 'guillermo@email.com', 'pass123', 30, 'Cine', 'El mundo es un gran guion.', 'Heterosexual', 'Relación seria'),
('Ana', 'Reyes', 'ana@email.com', 'pass123', 27, 'Publicidad', 'Creando ideas que cambian el mundo.', 'Heterosexual', 'Amistad'),
('Héctor', 'Blanco', 'hector@email.com', 'pass123', 25, 'Informática', 'Construyendo el futuro, byte a byte.', 'Heterosexual', 'Relación seria'),
('Gabriela', 'Martínez', 'gabriela@email.com', 'pass123', 23, 'Biología', 'La vida es la mayor de las maravillas.', 'Homosexual', 'Relación casual'),
('Ricardo', 'Flores', 'ricardo@email.com', 'pass123', 28, 'Diseño Industrial', 'La forma sigue a la función.', 'Heterosexual', 'Amistad'),
('Lucía', 'García', 'lucia@email.com', 'pass123', 22, 'Ciencias Políticas', 'El poder está en la gente.', 'Bisexual', 'Relación seria'),
('Marco', 'Escobar', 'marco@email.com', 'pass123', 26, 'Física', 'Desentrañando los secretos del universo.', 'Heterosexual', 'Relación casual'),
('Valeria', 'Paredes', 'valeria@email.com', 'pass123', 24, 'Danza', 'Mi cuerpo habla más que mis palabras.', 'Heterosexual', 'Amistad'),
('Adrián', 'Mendoza', 'adrian@email.com', 'pass123', 29, 'Filosofía', 'Pensar es la esencia del ser.', 'Homosexual', 'Relación seria'),
('Carolina', 'Salazar', 'carolina@email.com', 'pass123', 21, 'Artes Plásticas', 'Coloreando el mundo a mi alrededor.', 'Bisexual', 'Relación casual'),
('Roberto', 'Pinto', 'roberto@email.com', 'pass123', 30, 'Matemáticas', 'Los números nunca mienten.', 'Heterosexual', 'Relación seria'),
('Diana', 'León', 'diana@email.com', 'pass123', 27, 'Ingeniería Química', 'Transformando lo ordinario en extraordinario.', 'Heterosexual', 'Amistad');

-- Inserts para la tabla 'intereses'
INSERT INTO intereses (nombre, descripcion) VALUES
('Música', 'Escuchar, tocar o crear música de cualquier género.'),
('Cine', 'Ver y analizar películas, series y documentales.'),
('Viajes', 'Explorar nuevos lugares, culturas y gastronomías.'),
('Deportes', 'Practicar o seguir cualquier tipo de deporte.'),
('Cocina', 'Preparar recetas, probar nuevos platos y la gastronomía en general.'),
('Lectura', 'Disfrutar de libros, novelas, poesía o artículos.'),
('Videojuegos', 'Jugar en consolas, PC o dispositivos móviles.'),
('Tecnología', 'Interés en gadgets, programación, IA y novedades tecnológicas.'),
('Arte', 'Creación o apreciación de la pintura, escultura, dibujo, etc.'),
('Naturaleza', 'Actividades al aire libre como senderismo, campismo y fotografía.'),
('Fotografía', 'Capturar momentos, paisajes o retratos.'),
('Baile', 'Disfrutar de distintos estilos de baile como salsa, bachata o jazz.'),
('Idiomas', 'Aprender y practicar nuevos idiomas.'),
('Ciencia', 'Interés en la física, biología, astronomía y otros campos científicos.'),
('Voluntariado', 'Participar en causas sociales y comunitarias.');

-- Inserts para la tabla intermedia 'intereses_usuarios'
INSERT INTO intereses_usuarios (id_usuario, id_intereses) VALUES
(1, 4), (1, 7), (1, 8),
(2, 6), (2, 9), (2, 14),
(3, 1), (3, 2), (3, 10),
(4, 3), (4, 11),
(5, 6), (5, 9),
(6, 2), (6, 5), (6, 12),
(7, 13), (7, 15),
(8, 2), (8, 11),
(9, 6), (9, 13),
(10, 8), (10, 14),
(11, 1), (11, 4), (11, 7),
(12, 5), (12, 10),
(13, 1), (13, 2), (13, 3),
(14, 14),
(15, 1), (15, 2), (15, 6),
(16, 12), (16, 15),
(17, 3), (17, 13),
(18, 6), (18, 9), (18, 11),
(19, 2), (19, 5),
(20, 11), (20, 12), (20, 15),
(21, 7), (21, 8),
(22, 10), (22, 14),
(23, 1), (23, 8), (23, 11),
(24, 6), (24, 13),
(25, 14),
(26, 12), (26, 9),
(27, 6), (27, 9), (27, 13),
(28, 9), (28, 11),
(29, 7), (29, 8), (29, 14),
(30, 5), (30, 14);

INSERT INTO likes (id_emisor, id_receptor, es_match) VALUES
(1, 2, FALSE),
(4, 5, FALSE),
(6, 7, FALSE),
(8, 9, FALSE),
(10, 11, FALSE),
(12, 13, FALSE),
(14, 15, FALSE),
(16, 17, FALSE),
(18, 19, FALSE),
(20, 21, FALSE),
(22, 23, FALSE),
(24, 25, FALSE),
(26, 27, FALSE),
(28, 29, FALSE),
(30, 1, FALSE);

-- Likes mutuos (hay match)
INSERT INTO likes (id_emisor, id_receptor, es_match) VALUES
(2, 1, TRUE),
(5, 4, TRUE),
(7, 6, TRUE),
(9, 8, TRUE),
(11, 10, TRUE),
(13, 12, TRUE),
(15, 14, TRUE),
(17, 16, TRUE),
(19, 18, TRUE),
(21, 20, TRUE),
(23, 22, TRUE),
(25, 24, TRUE),
(27, 26, TRUE),
(29, 28, TRUE);

INSERT INTO dislikes (id_emisor, id_receptor) VALUES
(1, 3),
(2, 4),
(3, 5),
(4, 6),
(5, 7),
(6, 8),
(7, 9),
(8, 10),
(9, 11),
(10, 12),
(11, 13),
(12, 14),
(13, 15),
(14, 16),
(15, 17),
(16, 18),
(17, 19),
(18, 20),
(19, 21),
(20, 22),
(21, 23),
(22, 24),
(23, 25),
(24, 26),
(25, 27),
(26, 28),
(27, 29),
(28, 30);