USE [GerenciadorAmigoDB]
GO
/****** Object:  StoredProcedure [dbo].[UpdateAmigo]    Script Date: 28/06/2021 15:57:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[UpdateAmigo]
	@Nome varchar(50),
	@Sobrenome varchar(50),
	@DataNascimento datetime,
	@IdAmigo int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update dbo.Amigo
		Set Nome = @Nome,
			Sobrenome = @Sobrenome,
			DataNascimento = @DataNascimento
	Where Id = @IdAmigo;

END