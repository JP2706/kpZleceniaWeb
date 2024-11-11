USE [kpZleceniaWeb]
GO

/****** Object:  StoredProcedure [dbo].[pAppCombo]    Script Date: 02.11.2024 02:32:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[pAppCombo]
@forms varchar(30)	= '',
@combo varchar(30)	= ''
AS
DECLARE @zrodlo varchar(2000)	= ''
BEGIN
SET NOCOUNT ON;

    SELECT TOP 1 @zrodlo = Zrodlo FROM dbo.AppCombo WHERE (Forms=@forms) AND (Combo=@combo)
END
GO


