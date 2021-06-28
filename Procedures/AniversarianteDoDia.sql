USE [GerenciadorAmigoDB]
GO
/****** Object:  StoredProcedure [dbo].[AniversarianteDoDia]    Script Date: 28/06/2021 15:54:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[AniversarianteDoDia]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from dbo.Amigo where DAY(Amigo.DataNascimento) = DAY(GETDATE()) AND MONTH(Amigo.DataNascimento) = MONTH(GETDATE());
END
