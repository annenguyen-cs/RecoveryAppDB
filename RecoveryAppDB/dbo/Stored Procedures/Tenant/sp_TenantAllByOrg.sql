CREATE PROCEDURE [dbo].[sp_TenantAllByOrg]
	@Id int
AS

BEGIN

	SELECT t.[Id], t.[FirstName], t.[LastName], t.[Phone], t.[Email], t.[ManagerId], (m.FirstName + m.LastName) AS Manager, o.Title AS Organiztion
	FROM Tenant t
	Left Join Manager m
	ON t.[ManagerId] = m.[Id]
	Left Join Organization o
	ON m.[OrganizationId] = o.[Id]
	WHERE o.[Id] = @Id;

END