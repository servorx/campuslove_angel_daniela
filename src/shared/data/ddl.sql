DROP DATABASE IF EXISTS examen_csharp;
CREATE DATABASE IF NOT EXISTS examen_csharp;
USE examen_csharp;

CREATE TABLE IF NOT EXISTS usuarios (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    genero VARCHAR(15) NOT NULL,
    carrera VARCHAR(40) NOT NULL,
    intereses VARCHAR(200) NOT NULL,
    frase VARCHAR(255) NOT NULL
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS likes (
    id INT PRIMARY KEY AUTO_INCREMENT,
    id_emisor INT NOT NULL,
    id_receptor INT NOT NULL,
    -- si es id_emisor y el id_receptor se han dado like mutuamente el match es mutuo 
    match BOOLEAN NOT NULL,
    CONSTRAINT fk_id_emisor FOREIGN KEY id_emisor REFERENCES usuarios(id),
    CONSTRAINT fk_id_receptor FOREIGN KEY id_receptor REFERENCES usuarios(id)
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS dislikes (
    id INT PRIMARY KEY AUTO_INCREMENT,
) ENGINE=INNODB;






CREATE TABLE IF NOT EXISTS coincidencias (
    id
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS gestor_usuarios (
    id 
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS interacciones (
    id 
) ENGINE=INNODB;

