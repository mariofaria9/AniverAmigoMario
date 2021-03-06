USE [GerenciadorAmigoDB]
GO
/****** Object:  StoredProcedure [dbo].[InsertAmigo]    Script Date: 28/06/2021 15:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[InsertAmigo]
	@Nome varchar(50),
	@Sobrenome varchar(50),
	@DataNascimento datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.Amigo(Nome, Sobrenome, DataNascimento)
		Values(@Nome, @Sobrenome, @DataNascimento);
END
