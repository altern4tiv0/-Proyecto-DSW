CREATE DATABASE EcommersProyect

USE EcommersProyect

CREATE TABLE Categorias(
	IdCategoria INT IDENTITY PRIMARY KEY,
	NombreCategoria VARCHAR(100)
)

INSERT INTO Categorias VALUES ('Teclados')
INSERT INTO Categorias VALUES ('Mouses')
INSERT INTO Categorias VALUES ('Monitores')
INSERT INTO Categorias VALUES ('Audifonos')
INSERT INTO Categorias VALUES ('Componentes')

CREATE TABLE Productos(
	IdProducto char (4) NOT NULL Primary key,
	NombreProducto VARCHAR(100),
	Precio DECIMAL,
	Stock INT,
	Marca VARCHAR(100),
	IdCategoria INT,
	FOREIGN KEY (IdCategoria) REFERENCES Categorias(IdCategoria)
)

-- Inserta productos en la categoría 
INSERT INTO Productos (IdProducto ,NombreProducto, Precio, Stock, Marca, IdCategoria) VALUES
('A001','Monitor Gaming', 250.00, 12, 'HP', 3),
('A002','Mouse Ergonómico', 35.00, 30, 'Redragon', 2),
('A003','Audífonos Inalámbricos', 150.00, 20, 'Logitech', 4),
('A004','Teclado Ergonómico', 110.00, 15, 'Corsair', 1),
('A005','Monitor Portátil', 150.00, 20, 'Asus', 3),
('A006','Mouse de Viaje', 20.00, 60, 'LG', 2),
('A007','Mouse Óptico', 30.00, 40, 'Corsair', 2),
('A008','Tarjeta Gráfica', 500.00, 10, 'Nvidia', 5),
('A009','Disco Duro SSD', 100.00, 20, 'Samsung', 5),
('A010','Mouse Recargable', 40.00, 25, 'HP', 2),
('A011','Audífonos con Micrófono', 80.00, 25, 'Redragon', 4),
('A012','Audífonos Gamer', 120.00, 15, 'HyperX', 4),
('A013','Mouse Compacto', 25.00, 50, 'HyperX', 2),
('A014','Teclado Mecánico', 99.99, 30, 'Logitech', 1),
('A015','Mouse Gamer', 50.00, 25, 'Logitech', 2),
('A016','Teclado Multidispositivo', 130.00, 12, 'Logitech', 1),
('A017','Monitor 4K', 400.00, 5, 'LG', 3),
('A018','Memoria RAM', 150.00, 25, 'Corsair', 5),
('A019','Ventilador de PC', 20.00, 50, 'Noctua', 5),
('A020','Audífonos con Bass Boost', 90.00, 20, 'JBL', 4),
('A021','Monitor Curvo', 300.00, 10, 'Samsung', 3),
('A022','Mouse con Luz RGB', 55.00, 20, 'Logitech', 2),
('A023','Teclado Compacto', 80.50, 20, 'HyperX', 1),
('A024','Teclado de Oficina', 40.00, 40, 'HP', 1),
('A025','Teclado Inalámbrico', 70.00, 20, 'Logitech', 1),
('A026','Teclado RGB', 120.00, 15, 'Corsair', 1),
('A027','Mouse Inalámbrico', 45.00, 20, 'HP', 2),
('A028','Teclado Gaming', 150.00, 10, 'Redragon', 1),
('A029','Monitor Full HD', 200.00, 15, 'LG', 3),
('A030','Monitor con HDR', 450.00, 5, 'Samsung', 3),
('A031','Teclado Estándar', 50.00, 30, 'LG', 1),
('A032','Teclado Membrana', 60.00, 25, 'HP', 1),
('A033','Placa Base', 200.00, 10, 'Asus', 5),
('A034','Monitor de Diseño', 500.00, 4, 'Dell', 3),
('A035','Procesador', 300.00, 15, 'Intel', 5),
('A036','Monitor Ultrawide', 350.00, 8, 'Dell', 3),
('A037','Audífonos Ligeros', 50.00, 50, 'Sony', 4),
('A038','Mouse Silencioso', 28.00, 30, 'Corsair', 2),
('A039','Audífonos con Cancelación de Ruido', 250.00, 12, 'Bose', 4),
('A040','Caja de PC', 70.00, 20, 'NZXT', 5),
('A041','Monitor Compacto', 100.00, 25, 'HP', 3),
('A042','Monitor Táctil', 300.00, 10, 'Acer', 3),
('A043','Audífonos USB', 60.00, 40, 'Corsair', 4),
('A044','Audífonos Deportivos', 70.00, 30, 'Sony', 4),
('A045','Fuente de Poder', 80.00, 30, 'Cooler Master', 5),
('A046','Audífonos Over-Ear', 180.00, 18, 'Bose', 4),
('A047','Tarjeta de Sonido', 120.00, 15, 'Creative', 5),
('A048','Disipador CPU', 50.00, 30, 'Be Quiet', 5),
('A049','Audífonos de Estudio', 200.00, 10, 'Sennheiser', 4);


CREATE TABLE VentaProductos(
	IdVentaProductos INT IDENTITY PRIMARY KEY ,
	NombreProducto VARCHAR(100),
	Cantidad INT,
	Precio DECIMAL
)

CREATE TABLE Usuarios(
   nro_reg	INT IDENTITY PRIMARY KEY,
   login_usu VARCHAR(25) not null,
   clave_usu VARCHAR(25) not null
)
go

----------------------------
--PROCEDIMIENTOS ALMACENADOS
----------------------------
CREATE PROCEDURE ListarProductos
AS
BEGIN
    SELECT IdProducto, NombreProducto, Precio, Stock, Marca, IdCategoria
    FROM Productos;
END;

EXEC ListarProductos;


CREATE PROCEDURE pa_encontrar_usuario
@login_usu varchar(25),
@clave_usu varchar(25)
as
   select count(*) as conta
   from Usuarios
	where login_usu=@login_usu and
		clave_usu=@clave_usu
go

CREATE PROCEDURE InsertarUsuario
    @login_usu VARCHAR(25),
    @clave_usu VARCHAR(25)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Usuarios (login_usu, clave_usu)
    VALUES (@login_usu, @clave_usu);
END;

