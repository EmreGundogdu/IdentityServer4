var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", opt => {
    opt.Authority = "https://localhost:5001"; //Access token yay�mlayan kim?AuthroizationServer jwt verir bu adresten public key al�cak ve daha sonra jwt i�erisinde ki private key'i public key ile do�rulayacak
    opt.Audience = "resource_api2"; //Buraya verice�imiz resource bu program.cs bulundu�u projeye istek atarken gerekli olan alan� g�sterir

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
