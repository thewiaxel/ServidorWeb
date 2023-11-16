using Microsoft.AspNetCore.Http.Json;
var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<JsonOptions>(options=>options.SerializerOptions.PropertyNamingPolicy=null);
builder.Services.AddCors();
var app = builder.Build();

app.UseCors(policy=>policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.MapGet("/", () => "Hello World!");

app.MapGet("/calificaciones",CalificacionesRequestHandlers.MostrarCalificaciones);
app.MapGet("/calificaciones/{numControl:long}",CalificacionesRequestHandlers.MostrarCalificacionesAlumno);

app.MapPost("/ver-consumo",SimuladorConsumoRequestHandelr.VerConsumo);

app.MapGet ("/categorias",CategoriaRequestHanlder.Listar);
app.MapPost("/categorias/crear",CategoriaRequestHanlder.Crear);
app.MapPost("/usuarios/registrar",UsuarioRequestHandler.Registrar);
app.MapPost("/usuarios/recuperar-password",UsuarioRequestHandler.Recuperar);
app.MapPost("/usuarios/inicio-sesion",UsuarioRequestHandler.Iniciar);

app.MapGet("/lenguaje/{idCategoria}",LenguajeRequestHanlder.ListarRegistros);
app.MapPost("/lenguaje",LenguajeRequestHanlder.CrearRegistro);
app.MapDelete("/lenguaje/{id}",LenguajeRequestHanlder.Eliminar);
app.MapGet("lenguaje/buscar",LenguajeRequestHanlder.Buscar);
app.Run();