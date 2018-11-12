USE [Merceria]
GO
/****** Object:  StoredProcedure [dbo].[st_ConsultarClientePorApellidos]    Script Date: 12/11/2018 1:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<SancheGuerrero>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[st_ConsultarClientePorApellidos]
	@apellidos varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT * FROM Cliente WHERE apellidos = @apellidos
END


GO
/****** Object:  StoredProcedure [dbo].[st_ConsultarClientes]    Script Date: 12/11/2018 1:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<SanchezGuerrero,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[st_ConsultarClientes]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT * FROM Cliente
END

GO
/****** Object:  StoredProcedure [dbo].[st_ConsultarProductoPorCodigo]    Script Date: 12/11/2018 1:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sanchez Guerrero>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[st_ConsultarProductoPorCodigo]
@codigo varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT codigo,nombre,precioPublico,descripcion FROM Productos WHERE codigo = @codigo
END

GO
/****** Object:  StoredProcedure [dbo].[st_ConsultarProductos]    Script Date: 12/11/2018 1:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<SanchezGuerrero>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[st_ConsultarProductos]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT codigo,nombre,precioPublico,descripcion FROM Productos
END

GO
/****** Object:  StoredProcedure [dbo].[st_RegistrarCliente]    Script Date: 12/11/2018 1:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<SánchezGuerrero>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[st_RegistrarCliente] 
	@nombre varchar(50),
	@apellidos varchar(50),
	@direccion varchar(50),
	@telefono varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO Cliente(nombre,apellidos,direccion,telefono) VALUES(@nombre,@apellidos,@direccion,@telefono)
END


GO
/****** Object:  StoredProcedure [dbo].[st_RegistrarVenta]    Script Date: 12/11/2018 1:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sanchez Guerrero>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[st_RegistrarVenta]
	@idCliente int,
	@totalVenta decimal(10,2),
	@fechaVenta datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    INSERT INTO Venta(idUsuario,idCliente,totalVenta,fechaVenta) VALUES(1,@idCliente,@totalVenta,@fechaVenta)
END
GO
