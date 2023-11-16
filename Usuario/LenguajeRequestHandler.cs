using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Driver;

public static class LenguajeRequestHanlder{
public static IResult ListarRegistros (string idCategoria){
     var filterBuilder = new FilterDefinitionBuilder<LenguajeDBMap>();
     var filter = filterBuilder.Eq(x => x.IdCategoria, idCategoria);
     BaseDatos bd = new BaseDatos();
     var coleccion =bd.ObternerColeccion<LenguajeDBMap>("Lenguaje");
     var lista = coleccion.Find (filter).ToList ();
     return Results.Ok(lista. Select(x => new {
     Id = x.Id. ToString(),
    IdCategoria = x.IdCategoria,
    Titulo = x. Titulo,
    Descripcion = x.Descripcion,
    EsVideo = x.EsVideo,
    Url = x.Url
}).ToList());
}
public static IResult CrearRegistro(LenguajeDTO dto) {
     // Validar que el usuario haya capturado todos los registros
       if (string.IsNullOrWhiteSpace(dto.IdCategoria)){
            return Results.BadRequest ("Es necesario la id de la categoria");
        }
             if (string.IsNullOrWhiteSpace(dto.Descripcion)){
            return Results.BadRequest ("Es necesario una descripcion");
        }
                if (string.IsNullOrWhiteSpace(dto.Titulo)){
            return Results.BadRequest ("Es necesario un titulo");
        }
                if (string.IsNullOrWhiteSpace(dto.Url)){
            return Results.BadRequest ("Es necesario un url");
        }
     // Validar que el object id tenga el format válido
    if(!ObjectId. TryParse(dto.IdCategoria, out ObjectId idCategoria)){
         return Results.BadRequest($"El Id de la categoría {dto.IdCategoria} no es válido");
    }
     BaseDatos bd = new BaseDatos();
     // Validar que exista la categoría
     var filterBuilderCategorias = new FilterDefinitionBuilder<CategoriaDBMap>();
     var filterCategoria =filterBuilderCategorias.Eq(x => x.Id, idCategoria);
     var coleccionCategoria=bd.ObternerColeccion<CategoriaDBMap>("Categorias");
     var categoria = coleccionCategoria.Find(filterCategoria).FirstOrDefault();

    if(categoria == null){
         return Results.NotFound($"No existe una categoría con ID - {dto.IdCategoria}");
    }

     LenguajeDBMap registro = new LenguajeDBMap();
     registro. Titulo = dto.Titulo;
    registro.EsVideo = dto.EsVideo;
    registro.Descripcion = dto.Descripcion;
    registro.Url = dto.Url;
     registro. IdCategoria = dto.IdCategoria;

    var coleccionLenguaje = bd.ObternerColeccion<LenguajeDBMap>("Lenguaje");
    coleccionLenguaje!.InsertOne(registro);
     return Results.Ok(registro.Id.ToString());
    }
    public static IResult Eliminar(string id){
    if(!ObjectId. TryParse(id, out ObjectId idLenguaje)){
         return Results.BadRequest($"El Id proporcionad ({id}) no es válido");
    }
     BaseDatos bd = new BaseDatos();
     var filterBuilder = new FilterDefinitionBuilder<LenguajeDBMap>();
     var filter = filterBuilder.Eq(x => x.Id, idLenguaje);
    var coleccion =bd.ObternerColeccion<LenguajeDBMap>("Lenguaje");
     coleccion! .DeleteOne (filter);
     return Results.NoContent();
    }
    public static IResult Buscar(string texto){
var queryExpr = new BsonRegularExpression(new Regex(texto, RegexOptions.IgnoreCase));
var filterBuilder = new FilterDefinitionBuilder<LenguajeDBMap>();
var filter = filterBuilder. Regex("Titulo", queryExpr) |
filterBuilder.Regex ("Descripcion", queryExpr);

BaseDatos bd = new BaseDatos ();
var coleccion = bd. ObternerColeccion<LenguajeDBMap>("Lenguaje");
var lista = coleccion.Find(filter).ToList();

return Results.Ok(lista.Select(x => new {
Id = x.Id.ToString(),
IdCategoria = x. IdCategoria,
Titulo = x.Titulo,
Descripcion = x.Descripcion,
EsVideo = x.EsVideo,
Url = x.Url
}).ToList());
}
}
