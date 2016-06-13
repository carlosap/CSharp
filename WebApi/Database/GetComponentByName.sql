USE EJPARSE
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.usp_GetComponentByName') AND type in (N'P', N'PC'))
DROP PROCEDURE dbo.usp_GetComponentByName
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  PROCEDURE dbo.usp_GetComponentByName
        @Name as NVARCHAR(20),
		@TableName as NVARCHAR(20)
AS
DECLARE @Id INT
DECLARE @MediaId INT
DECLARE @MediaLocalFileUrl NVARCHAR(255)
DECLARE @Type NVARCHAR(255)
DECLARE @Content NVARCHAR(MAX)
DECLARE @ROWNUM INT
DECLARE @TOTAL_ROW INT
DECLARE @TableID INT
DECLARE @RESULT_TABLE TABLE
(
               TABLE_ID INT IDENTITY( 1, 1 ),
               DOCUMENT_ID INT,
               DOCUMENT_TYPE NVARCHAR(255),
               DOCUMENT_BODY_CONTENT NVARCHAR(MAX)
)
DECLARE @JSON_TABLE TABLE
(
               JSON_ID INT IDENTITY( 1, 1 ),
               JSON_NAME NVARCHAR(255),
               JSON_VALUE NVARCHAR(MAX)
)
INSERT @RESULT_TABLE 
SELECT Document.Id,Document.DocumentType, Document.BodyContent FROM Document
WHERE  Document.Name = @Name COLLATE Latin1_General_CS_AS 
	   AND Document.DocumentType = 'MrCMS.Web.Apps.Jsons.Pages.ShowJsons'
	   AND IsDeleted = 0
	   AND SiteId = 1
	   Order By Document.Id

SET @MediaId = (SELECT TOP 1 Document.Id FROM Document
					WHERE Document.Name = @Name COLLATE Latin1_General_CS_AS 
					AND Document.DocumentType = 'MrCMS.Entities.Documents.Media.MediaCategory'
					AND IsDeleted = 0
					AND SiteId = 1   
					Order By Document.Id)
		
SELECT @TOTAL_ROW = (SELECT COUNT(*) FROM @RESULT_TABLE )
SET @TableID = 0
SET @ROWNUM = 0
WHILE @ROWNUM < @TOTAL_ROW
BEGIN
        SET @ROWNUM = @ROWNUM + 1
        SELECT TOP 1 @TableID= TABLE_ID FROM @RESULT_TABLE WHERE TABLE_ID > @TableID
        SELECT @Id = DOCUMENT_ID, @Type = DOCUMENT_TYPE, @Content = DOCUMENT_BODY_CONTENT FROM @RESULT_TABLE WHERE TABLE_ID = @TableID
		INSERT @JSON_TABLE 
        SELECT Label,JsonText FROM EJPARSE.dbo.Json WHERE ShowJsonsId = @Id AND IsDeleted = 0 AND SiteId = 1 ORDER BY Id
END

--RESULTS-----------------
If @TableName = 'documents'
    Begin
		--SELECT DOCUMENT_BODY_CONTENT AS BodyContent  FROM @RESULT_TABLE
		SELECT TOP 1 
		   Id
		  ,Convert(nvarchar(50), Guid)AS GUID
		  ,REPLACE(DocumentType,'MrCMS.Web.Apps.Jsons.Pages.','') AS DocumentType
		  ,Name
		  ,DisplayOrder
		  ,UrlSegment
		  ,Hidden
		  ,MetaTitle
		  ,MetaDescription
		  ,IsGallery
		  ,SEOTargetPhrase
		  ,RevealInNavigation
		  ,RequiresSSL
		  ,PublishOn
		  ,BlockAnonymousAccess
		  ,FormRedirectUrl
		  ,FormEmailTitle
		  ,BodyContent
		  ,MetaKeywords
		  ,Published
		  ,IncludeInSitemap
		  ,CustomFooterScripts
		  ,CustomHeaderScripts
		  ,SendFormTo
		  ,FormMessage
		  ,FormSubmittedMessage
		  ,FormDesign
		  ,SubmitButtonCssClass
		  ,SubmitButtonText
		  ,PageTemplateId
		  ,RedirectUrl
		  ,Permanent
		  ,FeatureImage
		  ,Abstract
		  ,PageSize
		  ,AllowPaging
		  ,ThumbnailImage
		FROM Document
		WHERE Document.Name = @Name COLLATE Latin1_General_CS_AS 
		AND Document.DocumentType IN ('MrCMS.Web.Apps.Jsons.Pages.ShowJsons')
		AND IsDeleted = 0
		AND SiteId = 1
		Order By Document.Id
	   
    End
Else If @TableName = 'jsons'
    Begin
		SELECT JSON_NAME AS [Key], JSON_VALUE as [Value] FROM @JSON_TABLE
    End
Else If @TableName = 'medias'
    Begin
		SELECT 
		Id
		,Description
		,Title
		,FileUrl
		,FileExtension
		,ContentType
		,ContentLength
		,FileName
		,DisplayOrder
		,Width
		,Height
		FROM MediaFile WHERE MediaCategoryId = @MediaId 
		AND IsDeleted = 0
		AND SiteId = 1
		ORDER BY DisplayOrder
    END
		
ELSE If @TableName = 'form'
	Begin
		SELECT
			  DisplayOrder
			  ,REPLACE(PropertyType,'MrCMS.Entities.Documents.Web.FormProperties.','') AS ElementType
			  ,Name
			  ,LabelText
			  ,Required
			  ,CssClass
			  ,HtmlId
			  ,PlaceHolder
			  ,Icon
			  ,Disabled
			  ,Value
			  ,ImageUrl
			  ,SpriteCssClass
			  ,DataSource
		  FROM EJPARSE.dbo.FormProperty
		  WHERE WebpageId = @Id
		  AND IsDeleted = 0 
		  AND SiteId = 1 
		  ORDER BY DisplayOrder
	End






