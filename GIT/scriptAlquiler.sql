SCRIPT DE CREACIÓN - PROYECTO PROGRAMACIÓN CON BASE DE DATOS
 						Sistema: Alquiler de Equipamiento Audiovisual

CREATE DATABASE AlquilerAudiovisual;
GO

USE AlquilerAudiovisual;
GO

-- 1. CLIENTE
CREATE TABLE Cliente (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Tipo VARCHAR(50) NOT NULL,
    Documento VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Telefono VARCHAR(50) NOT NULL,
    Direccion VARCHAR(150) NOT NULL,
    Activo BIT NOT NULL
);

-- 2. DEPOSITO
CREATE TABLE Deposito (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Direccion VARCHAR(150) NOT NULL,
    Responsable VARCHAR(100) NOT NULL
);

-- 3. EQUIPAMIENTO
CREATE TABLE Equipamiento (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Marca VARCHAR(50) NOT NULL,
    Modelo VARCHAR(50) NOT NULL,
    Caracteristicas VARCHAR(200),
    DepositoId INT NOT NULL,
    PrecioBaseAlquiler FLOAT NOT NULL,
    Codigo VARCHAR(50) NOT NULL,
    Categoria VARCHAR(50) NOT NULL,
    Estado VARCHAR(50) NOT NULL,
    Stock INT NOT NULL,
    Activo BIT NOT NULL,
    FOREIGN KEY (DepositoId) REFERENCES Deposito(Id)
);

-- 4. SOLICITUD_ALQUILER
CREATE TABLE SolicitudAlquiler (
    Id INT PRIMARY KEY,
    ClienteId INT NOT NULL,
    TipoEvento VARCHAR(50) NOT NULL,
    NombreEvento VARCHAR(100),
    FechaInicio DATE NOT NULL,
    FechaFin DATE NOT NULL,
    Ubicacion VARCHAR(150) NOT NULL,
    CantidadAsistentes INT NOT NULL,
    Estado VARCHAR(50) NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES Cliente(Id)
);

-- 5. LINEA_SOLICITUD
CREATE TABLE LineaSolicitud (
    Id INT PRIMARY KEY,
    SolicitudId INT NOT NULL,
    EquipamientoId INT NOT NULL,
    Cantidad INT NOT NULL,
    FOREIGN KEY (SolicitudId) REFERENCES SolicitudAlquiler(Id),
    FOREIGN KEY (EquipamientoId) REFERENCES Equipamiento(Id)
);

-- 6. CONTRATACION
CREATE TABLE Contratacion (
    Id INT PRIMARY KEY,
    SolicitudId INT NOT NULL,
    ClienteId INT NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaFin DATE NOT NULL,
    Ubicacion VARCHAR(150) NOT NULL,
    ImporteTotal FLOAT NOT NULL,
    Estado VARCHAR(50) NOT NULL,
    FOREIGN KEY (SolicitudId) REFERENCES SolicitudAlquiler(Id),
    FOREIGN KEY (ClienteId) REFERENCES Cliente(Id)
);

-- 7. LINEA_CONTRATACION
CREATE TABLE LineaContratacion (
    Id INT PRIMARY KEY,
    ContratacionId INT NOT NULL,
    EquipamientoId INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario FLOAT NOT NULL,
    FOREIGN KEY (ContratacionId) REFERENCES Contratacion(Id),
    FOREIGN KEY (EquipamientoId) REFERENCES Equipamiento(Id)
);

-- 8. DEVOLUCION
CREATE TABLE Devolucion (
    Id INT PRIMARY KEY,
    ContratacionId INT NOT NULL,
    FechaDevolucion DATE NOT NULL,
    CargoAdicionalTotal FLOAT NOT NULL,
    Observaciones VARCHAR(200),
    FOREIGN KEY (ContratacionId) REFERENCES Contratacion(Id)
);

-- 9. DETALLE_DEVOLUCION
CREATE TABLE DetalleDevolucion (
    Id INT PRIMARY KEY,
    DevolucionId INT NOT NULL,
    EquipamientoId INT NOT NULL,
    Cantidad INT NOT NULL,
    TipoIncidencia VARCHAR(50) NOT NULL,
    CargoAdicional FLOAT NOT NULL,
    Observacion VARCHAR(200),
    FOREIGN KEY (DevolucionId) REFERENCES Devolucion(Id),
    FOREIGN KEY (EquipamientoId) REFERENCES Equipamiento(Id)
);

-- 10. PAGO
CREATE TABLE Pago (
    Id INT PRIMARY KEY,
    ContratacionId INT NOT NULL,
    FechaPago DATE NOT NULL,
    Monto FLOAT NOT NULL,
    MetodoPago VARCHAR(50) NOT NULL,
    Observacion VARCHAR(200),
    FOREIGN KEY (ContratacionId) REFERENCES Contratacion(Id)
);
GO
