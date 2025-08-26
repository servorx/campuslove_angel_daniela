DROP DATABASE IF EXISTS examen_csharp;
CREATE DATABASE IF NOT EXISTS examen_csharp;
USE examen_csharp;

-- esta seria la tabla principal de la base de datos
CREATE TABLE IF NOT EXISTS usuarios(
    id INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(80) NOT NULL,
    apellido VARCHAR(80) NOT NULL,
    edad INT NOT NULL,
    genero VARCHAR(10) NOT NULL,
    carrera VARCHAR(100),
    frase VARCHAR (255),
    orientacion VARCHAR(70) NOT NULL, 
    busqueda VARCHAR(40) NOT NULL,
    correo VARCHAR(80) NOT NULL,
    contrasenia VARCHAR(150) NOT NULL
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
    id_interes INT NOT NULL,
    PRIMARY KEY (id_usuario, id_interes),
    CONSTRAINT id_usuario_iu FOREIGN KEY (id_usuario) REFERENCES usuarios(id),
    CONSTRAINT id_intereses_iu  FOREIGN KEY (id_interes) REFERENCES intereses(id)
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

INSERT INTO usuarios (nombre, apellido, edad, genero, carrera, frase, orientacion, busqueda, correo, contrasenia) VALUES
('Alejandro', 'López', 25, 'Masculino', 'Ingeniería en Sistemas', 'El código es mi lenguaje.', 'Heterosexual', 'Relación seria', 'alejandro@email.com', 'pass123'),
('Valentina', 'Gómez', 23, 'Femenino', 'Medicina', 'Sanando el alma y el cuerpo.', 'Bisexual', 'Amistad', 'valentina@email.com', 'pass123'),
('Carlos', 'Ramírez', 28, 'Masculino', 'Arquitectura', 'Diseñando sueños en concreto.', 'Homosexual', 'Relación casual', 'carlos@email.com', 'pass123'),
('Sofía', 'Fernández', 22, 'Femenino', 'Diseño Gráfico', 'Mi vida es un lienzo en blanco.', 'Heterosexual', 'Relación seria', 'sofia@email.com', 'pass123'),
('Diego', 'Sánchez', 26, 'Masculino', 'Psicología', 'Explorando las mentes del mundo.', 'Heterosexual', 'Amistad', 'diego@email.com', 'pass123'),
('Camila', 'Torres', 24, 'Femenino', 'Periodismo', 'Contando historias, viviendo vidas.', 'Bisexual', 'Relación casual', 'camila@email.com', 'pass123'),
('Daniel', 'Herrera', 29, 'Masculino', 'Derecho', 'La justicia es la base de la sociedad.', 'Heterosexual', 'Relación seria', 'daniel@email.com', 'pass123'),
('Laura', 'Díaz', 21, 'Femenino', 'Comunicación Audiovisual', 'Creando mundos a través de la cámara.', 'Homosexual', 'Amistad', 'laura@email.com', 'pass123'),
('Javier', 'Pérez', 30, 'Masculino', 'Historia', 'El pasado es la clave para el futuro.', 'Heterosexual', 'Relación seria', 'javier@email.com', 'pass123'),
('Isabella', 'Rodríguez', 27, 'Femenino', 'Ingeniería Civil', 'Construyendo un futuro sólido.', 'Heterosexual', 'Amistad', 'isabella@email.com', 'pass123');

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

INSERT INTO intereses_usuarios (id_usuario, id_interes) VALUES
(1, 4), (1, 7), (1, 8),
(2, 6), (2, 9), (2, 14),
(3, 1), (3, 2), (3, 10),
(4, 3), (4, 11),
(5, 6), (5, 9),
(6, 2), (6, 5), (6, 12),
(7, 13), (7, 15),
(8, 2), (8, 11),
(9, 6), (9, 13),
(10, 8), (10, 14);

INSERT INTO likes (id_emisor, id_receptor, es_match) VALUES
(1, 2, FALSE),
(2, 3, FALSE),
(3, 4, FALSE),
(4, 5, FALSE),
(5, 6, FALSE),
(6, 7, FALSE),
(7, 8, FALSE),
(8, 9, FALSE),
(9, 10, FALSE);

INSERT INTO likes (id_emisor, id_receptor, es_match) VALUES
(2, 1, TRUE),
(4, 3, TRUE),
(6, 5, TRUE),
(8, 7, TRUE),
(10, 9, TRUE);

INSERT INTO dislikes (id_emisor, id_receptor) VALUES
(1, 3),
(2, 4),
(3, 5),
(4, 6),
(5, 7),
(6, 8),
(7, 9),
(8, 10);