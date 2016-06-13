USE [EJPARSE];
GO

IF OBJECT_ID('[dbo].[usp_LogSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_LogSelect] 
END 
GO
CREATE PROC [dbo].[usp_LogSelect] 
    @Id int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [Id], [Error], [Message], [Detail], [Type], [Guid], [CreatedOn], [UpdatedOn], [IsDeleted], [SiteId], [ImageSrc], [Exception], [DateTime], [MethodName], [SourceIP], [ConnectionType], [Content], [Users], [ComputerName], [OsVersion], [NumberProcessor], [Is64BitOS], [MemoryInContext] 
	FROM   [dbo].[Log] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_LogInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_LogInsert] 
END 
GO
CREATE PROC [dbo].[usp_LogInsert] 
    @Error varbinary(MAX) = NULL,
    @Message nvarchar(MAX) = NULL,
    @Detail nvarchar(MAX) = NULL,
    @Type nvarchar(255) = NULL,
    @Guid uniqueidentifier,
    @CreatedOn datetime = NULL,
    @UpdatedOn datetime = NULL,
    @IsDeleted bit = NULL,
    @SiteId int = NULL,
    @ImageSrc nvarchar(MAX) = NULL,
    @Exception varbinary(MAX) = NULL,
    @DateTime datetime = NULL,
    @MethodName nvarchar(MAX) = NULL,
    @SourceIP nvarchar(MAX) = NULL,
    @ConnectionType nvarchar(MAX) = NULL,
    @Content nvarchar(MAX) = NULL,
    @Users nvarchar(MAX) = NULL,
    @ComputerName nvarchar(MAX) = NULL,
    @OsVersion nvarchar(MAX) = NULL,
    @NumberProcessor int = NULL,
    @Is64BitOS bit = NULL,
    @MemoryInContext nvarchar(MAX) = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[Log] ([Error], [Message], [Detail], [Type], [Guid], [CreatedOn], [UpdatedOn], [IsDeleted], [SiteId], [ImageSrc], [Exception], [DateTime], [MethodName], [SourceIP], [ConnectionType], [Content], [Users], [ComputerName], [OsVersion], [NumberProcessor], [Is64BitOS], [MemoryInContext])
	SELECT @Error, @Message, @Detail, @Type, @Guid, @CreatedOn, @UpdatedOn, @IsDeleted, @SiteId, @ImageSrc, @Exception, @DateTime, @MethodName, @SourceIP, @ConnectionType, @Content, @Users, @ComputerName, @OsVersion, @NumberProcessor, @Is64BitOS, @MemoryInContext
	
	-- Begin Return Select <- do not remove
	SELECT [Id], [Error], [Message], [Detail], [Type], [Guid], [CreatedOn], [UpdatedOn], [IsDeleted], [SiteId], [ImageSrc], [Exception], [DateTime], [MethodName], [SourceIP], [ConnectionType], [Content], [Users], [ComputerName], [OsVersion], [NumberProcessor], [Is64BitOS], [MemoryInContext]
	FROM   [dbo].[Log]
	WHERE  [Id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_LogUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_LogUpdate] 
END 
GO
CREATE PROC [dbo].[usp_LogUpdate] 
    @Id int,
    @Error varbinary(MAX) = NULL,
    @Message nvarchar(MAX) = NULL,
    @Detail nvarchar(MAX) = NULL,
    @Type nvarchar(255) = NULL,
    @Guid uniqueidentifier,
    @CreatedOn datetime = NULL,
    @UpdatedOn datetime = NULL,
    @IsDeleted bit = NULL,
    @SiteId int = NULL,
    @ImageSrc nvarchar(MAX) = NULL,
    @Exception varbinary(MAX) = NULL,
    @DateTime datetime = NULL,
    @MethodName nvarchar(MAX) = NULL,
    @SourceIP nvarchar(MAX) = NULL,
    @ConnectionType nvarchar(MAX) = NULL,
    @Content nvarchar(MAX) = NULL,
    @Users nvarchar(MAX) = NULL,
    @ComputerName nvarchar(MAX) = NULL,
    @OsVersion nvarchar(MAX) = NULL,
    @NumberProcessor int = NULL,
    @Is64BitOS bit = NULL,
    @MemoryInContext nvarchar(MAX) = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[Log]
	SET    [Error] = @Error, [Message] = @Message, [Detail] = @Detail, [Type] = @Type, [Guid] = @Guid, [CreatedOn] = @CreatedOn, [UpdatedOn] = @UpdatedOn, [IsDeleted] = @IsDeleted, [SiteId] = @SiteId, [ImageSrc] = @ImageSrc, [Exception] = @Exception, [DateTime] = @DateTime, [MethodName] = @MethodName, [SourceIP] = @SourceIP, [ConnectionType] = @ConnectionType, [Content] = @Content, [Users] = @Users, [ComputerName] = @ComputerName, [OsVersion] = @OsVersion, [NumberProcessor] = @NumberProcessor, [Is64BitOS] = @Is64BitOS, [MemoryInContext] = @MemoryInContext
	WHERE  [Id] = @Id
	
	-- Begin Return Select <- do not remove
	SELECT [Id], [Error], [Message], [Detail], [Type], [Guid], [CreatedOn], [UpdatedOn], [IsDeleted], [SiteId], [ImageSrc], [Exception], [DateTime], [MethodName], [SourceIP], [ConnectionType], [Content], [Users], [ComputerName], [OsVersion], [NumberProcessor], [Is64BitOS], [MemoryInContext]
	FROM   [dbo].[Log]
	WHERE  [Id] = @Id	
	-- End Return Select <- do not remove

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_LogDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_LogDelete] 
END 
GO
CREATE PROC [dbo].[usp_LogDelete] 
    @Id int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[Log]
	WHERE  [Id] = @Id

	COMMIT
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

