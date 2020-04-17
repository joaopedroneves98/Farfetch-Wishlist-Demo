-- Use Ctrl + Shift + M hotkey (in Management Studio only) fill the following values
---------------------------------------------------------------------------------------
-- Deploy Info:            N/A
---------------------------------------------------------------------------------------
SET NOCOUNT ON
DECLARE @app VARCHAR(128) ,
    @Version INT,@Description [NVARCHAR](MAX),@author NVARCHAR(250)
  
--##############################SET THE FOLLOWING VARIABLES FIRST##########################################
SET @app = N'Wishlist'                               -- Related Application(Sales,Retail,etc)
SET @Version = 100                                      -- First version (10, 100, 101, etc)
SET @Description=N'Create DBScriptVersions table.'      -- Set version Description
SET @author = N'João Neves'                          -- Fill with author name
--#########################################################################################################
BEGIN TRANSACTION
BEGIN TRY
    PRINT 'Check if DBScriptVersions exists'
    IF OBJECT_ID(N'[DBScriptVersions]', 'U') IS NULL
        BEGIN
            PRINT 'Create table DBScriptVersions'
            CREATE TABLE [DBScriptVersions]
                (
                  [Id] [INT]
                    IDENTITY(1, 1) NOT FOR REPLICATION
                    CONSTRAINT [CK_DBScriptVersions_Id] CHECK ( id > 0 )
                    NOT NULL ,
                  [Version] [INT] NOT NULL ,
                  [MinorVersion] [INT]
                    NOT NULL
                    CONSTRAINT [DF_DBScriptVersions_MinorVersion] DEFAULT 0 ,
                  [Description] [NVARCHAR](MAX) NOT NULL ,
                  [ExecutionDate] [DATETIME2](7)
                    NULL
                    CONSTRAINT [DF_DBScriptVersions_ExecutionDate]
                    DEFAULT ( GETUTCDATE() ) ,
                  [UserLogin] [VARCHAR](128)
                    NULL
                    CONSTRAINT [DF_DBScriptVersions_UserLogin]
                    DEFAULT ( SUSER_SNAME() ) ,
                  [Hostname] [VARCHAR](128)
                    NULL
                    CONSTRAINT [DF_DBScriptVersions_HostName]
                    DEFAULT ( HOST_NAME() ) ,
                  [AppName] [VARCHAR](128) NOT NULL ,
                  [Author] [NVARCHAR](250) CONSTRAINT [CK_DBScriptVersions_Author] CHECK([Author]<>N'') NOT NULL,
                  [Sprint] VARCHAR(6)
                    NULL
                    CONSTRAINT [PK_DBScriptVersions]
                    PRIMARY KEY CLUSTERED ( [id] ASC )
                    WITH ( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,
                          IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,
                           ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
                )
            ON  [PRIMARY]
            PRINT 'Table DBScriptVersions created.'
        END
    ELSE
        BEGIN
            IF EXISTS ( SELECT  1
                        FROM    [DBScriptVersions] WHERE AppName=@app AND Version=@Version)
                BEGIN
                    DECLARE @exception NVARCHAR(MAX)= N'Versionning was already setup for application "' + @app+ N'" on database '
                        + DB_NAME() + ' and server ' + @@SERVERNAME
                    RAISERROR(@exception,11,1)
                END
        END
       IF @Version IS NULL OR @version=0
             RAISERROR('Version is invalid or not defined',11,1)
  
       IF @Description IS NULL OR @Description=''
             RAISERROR('Description is invalid or not defined',11,1)
  
       IF @app IS NULL OR @app=''
             RAISERROR('Application Name is invalid or not defined',11,1)
  
       IF @author IS NULL OR @author=''
             RAISERROR('Author is invalid or not defined',11,1)
  
    INSERT  INTO [DBScriptVersions]
            ( [Version] ,
              [Description] ,
              [AppName],
              [Author]
            )
    VALUES  ( @Version ,
              @Description ,
              @app,
              @author
            )
       IF NOT EXISTS (SELECT 1 FROM sys.indexes i WHERE i.name='UX_DBScriptVersions_Version_MinorVersion_AppName' AND i.object_id=OBJECT_ID('DBScriptVersions','U'))
       CREATE UNIQUE NONCLUSTERED INDEX [UX_DBScriptVersions_Version_MinorVersion_AppName] ON [DBScriptVersions]
       (
             [Version] ASC,
             [MinorVersion] ASC,
             [AppName] ASC
       ) ON [PRIMARY]
  
    PRINT 'Commit transaction.'
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    PRINT 'Error: ' + ERROR_MESSAGE()
    ROLLBACK TRAN
END CATCH
SET NOCOUNT OFF