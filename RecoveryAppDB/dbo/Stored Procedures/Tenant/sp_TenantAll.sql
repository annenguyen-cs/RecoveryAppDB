CREATE PROCEDURE [dbo].[sp_TenantAll]

AS

BEGIN

	SELECT t.[Id], t.[FirstName], t.[LastName], t.[Phone], t.[Email], t.[ManagerId], (m.FirstName + m.LastName) AS Recovery_Manager, o.Title AS Organization
	FROM Tenant t
	Left Join Manager m
	ON t.[ManagerId] = m.[Id]
	Left Join Organization o
	ON m.[OrganizationId] = o.[Id]


END
