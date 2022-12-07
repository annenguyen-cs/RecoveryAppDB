CREATE PROCEDURE [dbo].[sp_TenantByManager]
	@Id int

AS

BEGIN

	SET NOCOUNT ON;

	SELECT t.[Id], t.[FirstName], t.[LastName], t.[Phone], t.[Email], t.[ManagerId], (m.FirstName + m.LastName) AS Manager, o.Title AS Organization
	FROM Tenant t
	Left Join Manager m
	ON t.[ManagerId] = m.[Id]
	Left Join Organization o
	ON m.[OrganizationId] = o.[Id]
	WHERE t.[ManagerId] = @Id;

END