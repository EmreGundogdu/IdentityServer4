using IdentityServer.AuthenticationServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer().AddInMemoryApiResources(Config.GetApiResources()).AddInMemoryApiScopes(Config.GetApiScopes()).AddInMemoryClients(Config.GetClients()).AddDeveloperSigningCredential();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
