var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", opt =>{
    opt.Authority = "https://localhost:5001"; //Access token yayýmlayan kim?AuthroizationServer jwt verir bu adresten public key alýcak ve daha sonra jwt içerisinde ki private key'i public key ile doðrulayacak
    opt.Audience = "resource_api1"; //Buraya vericeðimiz resource bu program.cs bulunduðu projeye istek atarken gerekli olan alaný gösterir
});
builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("ReadProduct", policy =>
    {
        policy.RequireClaim("scope", "api1.read");//scope keyine sahip ve valuesinde alacaðý deðer bu olmalý demiþ olduk

    });
    opt.AddPolicy("UpdateOrCreate", policy =>
    {
        policy.RequireClaim("scope", new[] { "api1.update", "api1.write" }); //scope keyine sahip ve valuesinde bu scope alanlarý olmalý
    });
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
