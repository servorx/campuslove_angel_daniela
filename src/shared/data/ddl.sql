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

CREATE TABLE IF NOT EXISTS usuario_likes (
    id_usuario INT NOT NULL,
    id_like INT NOT NULL.
    PRIMARY KEY(id_usuario)
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS likes (
    id_like INT NOT NULL,

) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS dislikes (
    id_usuario
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS coincidencias (
    id_usuario
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS gestor_usuarios (
    id 
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS interacciones (
    id 
) ENGINE=INNODB;



CREATE TABLE IF NOT EXISTS personas (
    id 
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS personas (
    id 
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS personas (
    id 
) ENGINE=INNODB;