use flotilla;

CREATE TABLE Conductores (
  id_conductor INT PRIMARY KEY,
  nombre VARCHAR(255),
  identificacion VARCHAR(20),
  direccion VARCHAR(255),
  telefono VARCHAR(20),
  correo_electronico VARCHAR(255),
  licencia_conducir VARCHAR(20),Camiones
  fecha_vencimiento DATE
);

CREATE TABLE Camiones (
  id_camion INT PRIMARY KEY,
  marca_modelo VARCHAR(255),
  anio_fabricacion INT,
  capacidad_carga DECIMAL(10,2),
  fecha_compra DATE,
  estado VARCHAR(20)
);

CREATE TABLE Rutas (
  id_ruta INT PRIMARY KEY,
  origen VARCHAR(255),
  destino VARCHAR(255),
  distancia DECIMAL(10,2),
  tiempo_estimado_llegada TIME,
  restricciones_horario VARCHAR(255)
);

CREATE TABLE Pedidos (
  id_pedido INT PRIMARY KEY,
  fecha_pedido DATE,
  cliente VARCHAR(255),
  tipo_carga VARCHAR(255),
  cantidad DECIMAL(10,2),
  peso DECIMAL(10,2)
);

CREATE TABLE Viajes (
  id_viaje INT PRIMARY KEY,
  fecha DATE,
  id_conductor INT,
  id_camion INT,
  id_ruta INT,
  pedidos_entregados VARCHAR(255),
  tiempo_salida TIME,
  tiempo_llegada TIME,
  FOREIGN KEY (id_conductor) REFERENCES Conductores(id_conductor),
  FOREIGN KEY (id_camion) REFERENCES Camiones(id_camion),
  FOREIGN KEY (id_ruta) REFERENCES Rutas(id_ruta)
);

CREATE TABLE Mantenimiento (
  id_mantenimiento INT PRIMARY KEY,
  fecha_servicio DATE,
  tipo_servicio VARCHAR(255),
  costo DECIMAL(10,2),
  kilometraje INT,
  id_camion INT,
  FOREIGN KEY (id_camion) REFERENCES Camiones(id_camion)
);

CREATE TABLE Combustible (
  id_combustible INT PRIMARY KEY,
  fecha DATE,
  id_conductor INT,
  id_camion INT,
  cantidad DECIMAL(10,2),
  costo DECIMAL(10,2),
  FOREIGN KEY (id_conductor) REFERENCES Conductores(id_conductor),
  FOREIGN KEY (id_camion) REFERENCES Camiones(id_camion)
);

CREATE TABLE Seguros (
  id_seguro INT PRIMARY KEY,
  poliza VARCHAR(20),
  fecha_inicio DATE,
  fecha_fin DATE,
  monto_asegurado DECIMAL(10,2),
  tipo_cobertura VARCHAR(255),
  id_camion INT,
  FOREIGN KEY (id_camion) REFERENCES Camiones(id_camion)
);
