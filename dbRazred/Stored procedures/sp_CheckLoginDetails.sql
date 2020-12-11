CREATE PROCEDURE [dbo].[sp_CheckLoginDetails]
	@Username nvarchar(32),
	@Password nvarchar(32)
AS
BEGIN
DECLARE @IsLoginCorrect BIT
SET @IsLoginCorrect = 0

IF EXISTS(SELECT '#' FROM tblUsers WHERE Username = @Username AND [Password] = @Password)

BEGIN

SET @IsLoginCorrect = 1

END

SELECT @IsLoginCorrect AS '@IsLoginCorrect'

END
