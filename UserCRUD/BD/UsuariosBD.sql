CREATE DATABASE Usuarios;
USE Usuarios;

CREATE TABLE Usuarios (
	Id INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	Senha VARCHAR(10) NOT NULL,
	ConfirmaSenha VARCHAR(10) NOT NULL
);

-- INSERÇÃO TESTE
INSERT INTO Usuarios VALUES('Joelyson','Joe@email', '123', '123');
INSERT INTO Usuarios VALUES('Joe','dav@gmail', '123', '123');
SELECT * FROM Usuarios ORDER BY Nome;