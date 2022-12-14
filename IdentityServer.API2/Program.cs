var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", opt => {
    opt.Authority = "https://localhost:5001"; //Access token yayýmlayan kim?AuthroizationServer jwt verir bu adresten public key alýcak ve daha sonra jwt içerisinde ki private key'i public key ile doðrulayacak
    opt.Audience = "resource_api2"; //Buraya vericeðimiz resource bu program.cs bulunduðu projeye istek atarken gerekli olan alaný gösterir

});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
