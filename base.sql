use FundaVida
-- -----------------------------------------------------
-- Table Genero
-- -----------------------------------------------------
CREATE TABLE  Genero (
  idGenero INT NOT NULL,
  Descripcion VARCHAR(45) NOT NULL,
  Activo BIT NOT NULL,
  PRIMARY KEY (idGenero))

-- -----------------------------------------------------
-- Table Persona
-- -----------------------------------------------------
CREATE TABLE Persona (
  idPersona INT NOT NULL,
  Nombre VARCHAR(45) NOT NULL,
  Apellido1 VARCHAR(45) NOT NULL,
  Apellido2 VARCHAR(45) NOT NULL,
  Fecha_nacimiento DATE NOT NULL,
  Genero_idGenero INT NOT NULL,
  PRIMARY KEY (idPersona),
    FOREIGN KEY (Genero_idGenero)
    REFERENCES Genero (idGenero)

	)

-- -----------------------------------------------------
-- Table Modulos
-- -----------------------------------------------------
CREATE TABLE Modulos (
  idModulos INT NOT NULL,
  Descripcion VARCHAR(45) NOT NULL,
  Activo BIT NOT NULL,
  PRIMARY KEY (idModulos))



-- -----------------------------------------------------
-- Table Rol
-- -----------------------------------------------------
CREATE TABLE Rol (
  idRol INT NOT NULL,
  Descripcion VARCHAR(45) NOT NULL,
  Activo BIT NOT NULL,
  Modulos_idModulos INT NOT NULL,
  PRIMARY KEY (idRol),
    FOREIGN KEY (Modulos_idModulos)
    REFERENCES Modulos (idModulos)

	)

-- -----------------------------------------------------
-- Table Usuario
-- -----------------------------------------------------
CREATE TABLE Usuario (
  Nombre_usuario VARCHAR(45) NOT NULL,
  Contraseña VARCHAR(45) NOT NULL,
  Rol_idRol INT NOT NULL,
  Persona_idPersona INT NOT NULL,

  PRIMARY KEY (Nombre_usuario),

    FOREIGN KEY (Rol_idRol)
    REFERENCES Rol (idRol),
	
    FOREIGN KEY (Persona_idPersona)
    REFERENCES Persona (idPersona)

	)

-- -----------------------------------------------------
-- Table Personal
-- -----------------------------------------------------
CREATE TABLE Personal (
  Persona_idPersona INT NOT NULL,
  Fecha_ingreso DATE NOT NULL,
  Activo BIT NOT NULL,

  PRIMARY KEY (Persona_idPersona),

    FOREIGN KEY (Persona_idPersona)
    REFERENCES Persona (idPersona)

	)

-- -----------------------------------------------------
-- Table Voluntario
-- -----------------------------------------------------
CREATE TABLE Voluntario (
  Persona_idPersona INT NOT NULL,
  Fecha_ingreso DATE NOT NULL,
  Activo BIT NOT NULL,
  PRIMARY KEY (Persona_idPersona),

    FOREIGN KEY (Persona_idPersona)
    REFERENCES Persona (idPersona)
)


-- -----------------------------------------------------
-- Table Niño
-- -----------------------------------------------------
CREATE TABLE Niño (
  Persona_idPersona INT NOT NULL,
  Fecha_ingreso DATE NOT NULL,
  Activo BIT NOT NULL,
  PRIMARY KEY (Persona_idPersona),

    FOREIGN KEY (Persona_idPersona)
    REFERENCES Persona (idPersona)

	)



-- -----------------------------------------------------
-- Table Reporte
-- -----------------------------------------------------
CREATE TABLE Reporte (
  idReporte INT NOT NULL,
  Usuario_Nombre_usuario VARCHAR(45) NOT NULL,
  Estudiante_TCU_Persona_idPersona INT NOT NULL,
  Fecha DATETIME NOT NULL,
  Niño_Persona_idPersona INT NOT NULL,
  PRIMARY KEY (idReporte),
  
    FOREIGN KEY (Usuario_Nombre_usuario)
    REFERENCES Usuario (Nombre_usuario),

    FOREIGN KEY (Estudiante_TCU_Persona_idPersona)
    REFERENCES Voluntario (Persona_idPersona),
 
    FOREIGN KEY (Niño_Persona_idPersona)
    REFERENCES Niño (Persona_idPersona)

	)


-- -----------------------------------------------------
-- Table Asignacion_Horario
-- -----------------------------------------------------
CREATE TABLE Asignacion_Horario (
  idAsignacion_Horario INT NOT NULL,
  Niño_Persona_idPersona INT NOT NULL,
  Estudiante_TCU_Persona_idPersona INT NOT NULL,
  Hora TIME NOT NULL,
  Dia VARCHAR(20) NOT NULL,
  Cantidad_horas INT NOT NULL,
  PRIMARY KEY (idAsignacion_Horario, Niño_Persona_idPersona),

    FOREIGN KEY (Estudiante_TCU_Persona_idPersona)
    REFERENCES Voluntario (Persona_idPersona),

  
    FOREIGN KEY (Niño_Persona_idPersona)
    REFERENCES Niño (Persona_idPersona)
  )