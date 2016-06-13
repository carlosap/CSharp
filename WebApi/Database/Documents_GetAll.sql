/*============================================================================
aman:Documents_GetAll
Originator: cperez
Date: 1/27/16
Description:  returns all pages
=============================================================================*/
USE [Test]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Documents_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Documents_GetAll]
GO
USE [Test]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  PROCEDURE [dbo].[Documents_GetAll]
AS
SELECT * FROM Document Order By Document.Id
GO
