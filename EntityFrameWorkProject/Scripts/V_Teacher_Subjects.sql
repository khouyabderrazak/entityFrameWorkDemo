CREATE VIEW V_Teacher_Subjects AS
SELECT 
    dbo.Persons.SubjectId,
    dbo.Persons.LastName,   
    dbo.Persons.FirstName,       
    dbo.Persons.HireDate, 
    dbo.Subjects.Description,
    dbo.Subjects.Name,        
    dbo.Subjects.Id               
FROM 
    dbo.Persons
INNER JOIN
    dbo.Subjects ON dbo.Persons.SubjectId = dbo.Subjects.Id;
