--Use CTRL+Shit+M (in Management Studio only) hotkey to fill required values
---------------------------------------------------------------------------------------
-- Deploy Info:     <Deploy notes (if any),,N/A>
---------------------------------------------------------------------------------------
SET NOCOUNT ON
DECLARE @app VARCHAR(128) ,
    @Version INT ,
    @Description [NVARCHAR](MAX) ,
    @MinorVersion INT,
    @Sprint VARCHAR(6),
    @Author NVARCHAR(250)
 
--##############################SET THE FOLLOWING VARIABLES FIRST######################################
 
SET @app = N'Wishlist'                   -- Related Application(Sales,Retail,etc)
SET @Version = 103                          -- Script version (101, 102, etc)
SET @Description = N'Create table WishlistItemAttribute'     -- Set version Description
SET @MinorVersion = 0               -- Set the MinorVersion (only for hotfixes)
SET @Sprint = N'1'                          -- Define sprint if any
SET @Author = N'João Neves'                          -- Set script author
 
--#####################################################################################################
 
SET NOCOUNT ON
PRINT 'Begin transaction.'
BEGIN TRANSACTION;
BEGIN TRY
    PRINT 'Verify version.'
    IF NOT EXISTS ( SELECT  1
                    FROM    DBScriptVersions
                    WHERE   [Version] = @Version and [MinorVersion] = @MinorVersion and [AppName] = @app)
        BEGIN
 
            CREATE TABLE [dbo].[WishlistItemAttribute]
			(
			  [Id] INT NOT NULL PRIMARY KEY IDENTITY,
			  [WishlistItemId] INT NOT NULL,
		      [Value] NVARCHAR(MAX) NOT NULL,
			  [Key] NVARCHAR(MAX) NOT NULL,
			  [DateCreated] DATETIME NOT NULL,
			  [DateUpdated] DATETIME NOT NULL,
			  CONSTRAINT [FK_WishlistItemAttribute_WishlistItem] FOREIGN KEY ([WishlistItemId]) REFERENCES [WishlistItem]([Id])
			)
            PRINT 'Created table [WishlistItemAttribute]'
 
            INSERT  INTO [DBScriptVersions]
                    ( [Version] ,
                      [MinorVersion] ,
                      [Description] ,
                      [AppName],
                      [Sprint],
                      [Author]
                    )
            VALUES  ( @Version,
                      @MinorVersion ,
                      @Description ,
                      @app,
                      @Sprint,
                      @Author
                    )
             
            PRINT 'Commit transaction.'
            COMMIT TRANSACTION
        END
    ELSE
        RAISERROR('This script already was executed in this database.',11,1)       
 
END TRY
BEGIN CATCH
    PRINT 'Error: ' + ERROR_MESSAGE()
    PRINT 'Server: ' + @@SERVERNAME
    PRINT 'Database: ' + DB_NAME()
    ROLLBACK TRAN
END CATCH
 
SET NOCOUNT OFF