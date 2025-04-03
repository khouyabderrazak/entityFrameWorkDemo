CREATE PROCEDURE GetStudentByStudentNumber
    @StudentNumber NVARCHAR(50)
AS
BEGIN
    SELECT 
        *
    FROM Persons
    WHERE StudentNumber = @StudentNumber AND type = 'student';
END;
GO
