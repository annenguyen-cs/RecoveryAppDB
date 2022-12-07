CREATE PROCEDURE [dbo].[sp_TenantById]
	@Id int
AS
BEGIN

	SET NOCOUNT ON;

	SELECT t.Id, t.FirstName, t.LastName, t.Phone, t.Email, t.ManagerId, 
	ec.FirstName as Em_FirstName, ec.LastName as Em_LastName, ec.Email as Em_Email, ec.Phone as Em_Phone,
	ec.Relationship as Em_Relationship, ec.Id as Em_Id, ph.HospitalName as Ph_Hospital, ph.Street as Ph_Street, ph.City as Ph_City, ph.ZipCode as Ph_ZipCode, ph.Phone as Ph_Phone, ph.Id as Ph_Id,
	(m.FirstName + m.LastName) AS Recovery_Manager, o.Title AS Organization
	FROM Tenant t
	LEFT JOIN EmergencyContact ec
	ON t.Id = ec.TenantId
	LEFT JOIN PreferredHospital ph
	ON t.Id = ph.TenantId
	Left Join Manager m
	ON t.[ManagerId] = m.[Id]
	Left Join Organization o
	ON m.[OrganizationId] = o.[Id]
	WHERE t.Id = @Id;

END
