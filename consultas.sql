CREATE TABLE tipos_componente (
  id INT NOT NULL AUTO_INCREMENT,
  nombre VARCHAR(255) NOT NULL UNIQUE,
  PRIMARY KEY (id)
) AUTO_INCREMENT=1;

INSERT INTO tipos_componente (nombre) VALUES
('CPU'),
('RAM'),
('Almacenamiento'),
('Fuente'),
('Monitor'),
('Teclado'),
('Raton'),
('Tarjeta grafica'),
('Tarjeta de sonido'),
('Unidad optica'),
('Tarjeta de red');

CREATE TABLE componentes (
  id INT NOT NULL AUTO_INCREMENT,
  nombre VARCHAR(255) NOT NULL,
  modelo VARCHAR(255) NOT NULL,
  especificaciones VARCHAR(255),
  tipo_componente VARCHAR(255) NOT NULL,
  precio DECIMAL(10,2) NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (tipo_componente) REFERENCES tipos_componente (nombre)
) AUTO_INCREMENT=1;

INSERT INTO componentes (nombre, modelo, especificaciones, tipo_componente, precio) VALUES
('Intel Core i7-12700K', '12ª generación', '16 núcleos, 24 hilos', 'CPU', 599.99),
('DDR5-5600', '16 GB', 'CL36', 'RAM', 149.99),
('Disco duro SSD Samsung 980 Pro', '1 TB', 'NVMe PCIe Gen4', 'Almacenamiento', 199.99),
('Fuente Corsair RM850x', '850 W', '80+ Gold', 'Fuente', 179.99),
('Monitor LG UltraGear 27GP950-B', '4K UHD', '144 Hz', 'Monitor', 1299.99),
('Teclado mecánico Logitech G512 Carbon', 'RGB', 'Mecánico', 'Teclado', 129.99),
('Ratón inalámbrico Logitech G502 Hero', 'RGB', '16.000 DPI', 'Ratón', 99.99),
('Tarjeta gráfica NVIDIA GeForce RTX 3080 Ti', '12 GB GDDR6X', '10 752 CUDA cores', 'Tarjeta grafica', 1499.99),
('Tarjeta de sonido Creative Sound Blaster X3', 'DAC/AMP', 'Dolby Atmos', 'Tarjeta de sonido', 129.99),
('Unidad óptica LG WH16NS40', '4K UHD Blu-ray', 'DVD', 'Unidad optica', 69.99),
('Tarjeta de red Intel I219V', '10/100/1000 Mbps', 'Gigabit Ethernet', 'Tarjeta de red', 19.99);

INSERT INTO componentes (nombre, modelo, especificaciones, tipo_componente, precio) VALUES
('AMD Ryzen 7 7800X', '7ª generación', '8 núcleos, 16 hilos', 'CPU', 649.99),
('DDR5-6000', '32 GB', 'CL36', 'RAM', 349.99),
('Disco duro SSD Samsung 980 Pro Plus', '4 TB', 'NVMe PCIe Gen5', 'Almacenamiento', 599.99),
('Fuente de alimentación Corsair RM1200x', '1200 W', '80+ Platinum', 'Fuente', 299.99),
('Monitor ASUS ROG Swift PG32UQX', '32 pulgadas', '4K UHD, 240 Hz', 'Monitor', 1999.99),
('Teclado mecánico Razer BlackWidow V3 Pro', 'Switches Cherry MX Brown', 'RGB', 'Teclado', 229.99),
('Ratón inalámbrico Logitech G903 Hero', 'RGB', '25.600 DPI', 'Raton', 149.99),
('Tarjeta gráfica NVIDIA GeForce RTX 4070 Ti', '16 GB GDDR7X', '16.384 CUDA cores', 'Tarjeta grafica', 1199.99),
('Tarjeta de sonido Creative Sound Blaster Z SE', 'DAC/AMP', 'Dolby Atmos', 'Tarjeta de sonido', 129.99),
('Unidad óptica LG WH16NS50', '4K UHD Blu-ray', 'Blu-ray, DVD, CD', 'Unidad optica', 79.99);

CREATE TABLE tipos_usuario (
  id INT NOT NULL AUTO_INCREMENT,
  nombre VARCHAR(255) NOT NULL UNIQUE,
  PRIMARY KEY (id)
) AUTO_INCREMENT=1;

INSERT INTO tipos_usuario (nombre) VALUES 
('cliente'),('admin');

CREATE TABLE usuarios (
  id INT NOT NULL AUTO_INCREMENT,
  nombre VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL UNIQUE,
  tipo_usuario VARCHAR(255) NOT NULL,
  contrasena VARCHAR(255) NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (tipo_usuario) REFERENCES tipos_usuario (nombre)
) AUTO_INCREMENT=1;

INSERT INTO usuarios (nombre, email, tipo_usuario, contrasena) VALUES
('Primer Cliente', 'cliente@email', 'cliente', '1234'),
('Administrador', 'admin@email', 'admin', '1234');
