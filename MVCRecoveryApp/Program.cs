using RecoveryAppLibrary.Data;
using RecoveryAppLibrary.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Add default connection string
builder.Services.AddSingleton(new ConnectionStringData
{
    SqlConnectionName = "Default"
});
//wired up dependencies
builder.Services.AddSingleton<IDataAccess, SqlDb>();
builder.Services.AddSingleton<IEmergencyContactData, EmergencyContactData>();
builder.Services.AddSingleton<IFinesHistoryData, FinesHistoryData>();
builder.Services.AddSingleton<IIncidentFollowUpData, IncidentFollowUpData>();
builder.Services.AddSingleton<IncidentReportData, IncidentReportData>();
builder.Services.AddSingleton<IManagerData, ManagerData>();
builder.Services.AddSingleton<IOrganizationData, OrganizationData>();
builder.Services.AddSingleton<IPaymentHistoryData, PaymentHistoryData>();
builder.Services.AddSingleton<IPreferredHospitalData, PreferredHospitalData>();
builder.Services.AddSingleton<IRentAdjustmentData, RentAdjustmentData>();
builder.Services.AddSingleton<ITenantData,TenantData>();
builder.Services.AddSingleton<ITenantDetailsData,TenantDetailsData>();
builder.Services.AddSingleton<IUAFollowUpData, UAFollowUpData>();
builder.Services.AddSingleton<IUAResultData, UAResultData>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
