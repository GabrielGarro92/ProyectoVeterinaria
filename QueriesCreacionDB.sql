CREATE TABLE Enfermedades (
	idEnfermedad int,
	nombreEnfermedad varchar(50),
	descEnfermedad varchar(150),
	CONSTRAINT pk_enfermedades PRIMARY KEY(idEnfermedad)
)

INSERT INTO Enfermedades VALUES (1, 'Moquillo', 'Virus que es inhalado')
INSERT INTO Enfermedades VALUES (2, 'Parvovirosis', 'Mas frecuente en cachorros')
INSERT INTO Enfermedades VALUES (3, 'Hongos', 'Transmicion a humanos')

CREATE TABLE TipoCitas (
	idTipo int,
	descTipo varchar(50),
	CONSTRAINT pk_tipoCitas PRIMARY KEY(idTipo)
)

INSERT INTO TipoCitas VALUES (1, 'Consulta semanal')
INSERT INTO TipoCitas VALUES (2, 'Urgencia')
INSERT INTO TipoCitas VALUES (3, 'Revision dental')

CREATE TABLE Veterinarios (
	idVeterinario int,
	nombre varchar(50),
	apellido varchar(50),
	cedula varchar(15),
	correo varchar(50)
	CONSTRAINT pk_veterinarios PRIMARY KEY(idVeterinario)
)

INSERT INTO Veterinarios VALUES (1, 'Manuel', 'Garro', '1-1111-1111', 'manuel@test.com')
INSERT INTO Veterinarios VALUES (2, 'Gianina', 'Herrera', '2-1111-1111', 'gia@test.com')
INSERT INTO Veterinarios VALUES (3, 'Marcela', 'Arias', '3-1111-1111', 'marce@test.com')

CREATE TABLE Provincias (
	idProvincia int,
	descProvincia varchar(50),
	CONSTRAINT pk_provincias PRIMARY KEY(idProvincia)
)

INSERT INTO Provincias VALUES (1, 'San Jose')
INSERT INTO Provincias VALUES (2, 'Heredia')
INSERT INTO Provincias VALUES (3, 'Alajuela')

CREATE TABLE Clinicas (
	idClinica int,
	telefono int,
	direccion varchar(50),
	idProvincia int,
	CONSTRAINT pk_clinicas PRIMARY KEY(idClinica),
	CONSTRAINT clinicas_fk_provincias FOREIGN KEY(idProvincia) REFERENCES Provincias(idProvincia)
)

INSERT INTO Clinicas VALUES (1, 90908000, 'Lagunilla', 2)
INSERT INTO Clinicas VALUES (2, 55558000, 'San Pedro', 1)
INSERT INTO Clinicas VALUES (3, 22228000, 'Grecia', 3)

CREATE TABLE Historiales (
	idHistorial int,
	fecha date,
	motivoConsulta varchar(50),
	dignostico varchar(50),
	idEnfermedad int,
	idVeterinario int,
	CONSTRAINT pk_historiales PRIMARY KEY(idHistorial),
	CONSTRAINT historiales_fk_enfermedades FOREIGN KEY(idEnfermedad) REFERENCES Enfermedades(idEnfermedad),
	CONSTRAINT historiales_fk_veterinarios FOREIGN KEY(idVeterinario) REFERENCES Veterinarios(idVeterinario)
)

INSERT INTO Historiales VALUES (1, '2021-10-10', 'Falta de aire', 'Esta enfermo de los pulmones', 1, 1)
INSERT INTO Historiales VALUES (2, '2021-09-09', 'Sangrado', 'Tiene infeccion', 2, 2)
INSERT INTO Historiales VALUES (3, '2021-03-03', 'Alergia de piel', 'Tiene hongos', 3, 3)

CREATE TABLE Razas (
	idRaza int,
	descRaza varchar(50),
	CONSTRAINT pk_razas PRIMARY KEY(idRaza),
)

INSERT INTO Razas VALUES (1, 'Bulldog')
INSERT INTO Razas VALUES (2, 'Golden')
INSERT INTO Razas VALUES (3, 'Boxer')

CREATE TABLE Duenos (
	idDueno int,
	nombreDueno varchar(50),
	primerApellido varchar(50),
	segundoApellido varchar(50),
	cedula varchar(15),
	telefono varchar(10),
	correo varchar(50),
	CONSTRAINT pk_duenos PRIMARY KEY(idDueno)
)

INSERT INTO Duenos VALUES (1, 'Josue', 'Rojas', 'Mora', '1-2222-2222', 'josue@test.com', 20202020)
INSERT INTO Duenos VALUES (2, 'Maria', 'Solano', 'Mora', '2-2222-2222', 'maria@test.com', 66662020)
INSERT INTO Duenos VALUES (3, 'Valeria', 'Salazar', 'Espinoza', '5-2222-2222', 'valeria@test.com', 80902020)

CREATE TABLE Mascotas (
	idMascotas int,
	nombreMascota varchar(50),
	idRaza int,
	edad int,
	idHistorial int,
	idDueno int,
	CONSTRAINT pk_mascotas PRIMARY KEY(idMascotas),
	CONSTRAINT mascotas_fk_raza FOREIGN KEY(idRaza) REFERENCES Razas(idRaza),
	CONSTRAINT mascotas_fk_hisoriales FOREIGN KEY(idHistorial) REFERENCES Historiales(idHistorial),
	CONSTRAINT mascotas_fk_duenos FOREIGN KEY(idDueno) REFERENCES Duenos(idDueno)
)

INSERT INTO Mascotas VALUES (1, 'Pepe', 1, 9, 1, 1)
INSERT INTO Mascotas VALUES (2, 'Palito', 2, 3, 2, 2)
INSERT INTO Mascotas VALUES (3, 'Fincho', 3, 6, 3, 3)

CREATE TABLE Citas (
	idCita int,
	fecha date,
	idClinica int,
	idDueno int,
	idTipo int,
	idVeterinario int,
	CONSTRAINT pk_citas PRIMARY KEY(idCita),
	CONSTRAINT citas_fk_clinica FOREIGN KEY(idClinica) REFERENCES Clinicas(idClinica),
	CONSTRAINT citas_fk_duenos FOREIGN KEY(idDueno) REFERENCES Duenos(idDueno),
	CONSTRAINT citas_fk_tipo FOREIGN KEY(idTipo) REFERENCES TipoCitas(idTipo),
	CONSTRAINT citas_fk_veterinario FOREIGN KEY(idTipo) REFERENCES Veterinarios(idVeterinario)
)

INSERT INTO Citas VALUES (1, '2021-10-10', 1, 1, 1, 1)