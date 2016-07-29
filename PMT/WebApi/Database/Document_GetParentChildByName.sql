/*============================================================================
aman:Document_GetParentChildRelations
Originator: cperez
Date: 1/26/16
Description:  returns parent/child relations from Document table
=============================================================================*/
USE [Test]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Document_GetParentChildByName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Document_GetParentChildByName]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  PROCEDURE [dbo].[Document_GetParentChildByName]
        @DocumentName as nvarchar(15)
AS
SELECT *
FROM   Document a, Document b
WHERE a.Name = @DocumentName
And a.Id = b.ParentId
Order By a.Id,b.Id
GO


