USE [Merceria]
GO
/****** Object:  StoredProcedure [dbo].[st_ConsultarProductoPorCodigo]    Script Date: 27/11/2018 1:41:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sanchez Guerrero>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[st_ConsultarProductoPorCodigo]
@codigo varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT codigo,nombre,precioPublico,descripcion FROM Productos WHERE codigo = @codigo
END
------------------------------------------------------------------------------------------------------
USE [Merceria]
GO
/****** Object:  StoredProcedure [dbo].[st_ConsultarProductos]    Script Date: 27/11/2018 1:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<SanchezGuerrero>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[st_ConsultarProductos]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT codigo,nombre,precioPublico,descripcion FROM Productos
END
------------------------------------------------------------------------------------------------------
USE [Merceria]
GO
/****** Object:  StoredProcedure [dbo].[st_ConsultarStock]    Script Date: 27/11/2018 1:41:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[st_ConsultarStock]
@codigo varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select stock from Productos where codigo = @codigo
END
------------------------------------------------------------------------------------
USE [Merceria]
GO
/****** Object:  StoredProcedure [dbo].[st_RegistrarVenta]    Script Date: 27/11/2018 1:42:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sanchez Guerrero>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[st_RegistrarVenta]
	@totalVenta decimal(10,2),
	@fechaVenta datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    INSERT INTO Venta(idUsuario,totalVenta,fechaVenta) VALUES(1,@totalVenta,@fechaVenta)
END