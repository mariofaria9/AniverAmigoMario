USE [GerenciadorAmigoDB]
GO
/****** Object:  StoredProcedure [dbo].[SelectAmigoByName]    Script Date: 28/06/2021 15:57:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SelectAmigoByName]
	@NomeAmigo varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * from dbo.Amigo
	where Nome LIKE @NomeAmigo + '%'
END
