using MongoDB.Driver;

public static class UsuarioRequestHandler{
    public static IResult Registrar(Registro datos){
        if (string.IsNullOrWhiteSpace(datos.Nombre)){
            return Results.BadRequest("El nombre es requerido");
        }
         if (string.IsNullOrWhiteSpace(datos.Correo)){
            return Results.BadRequest("El Correo es requerido");
        }
         if (string.IsNullOrWhiteSpace(datos.Password)){
            return Results.BadRequest("el Password es requerido");
        }
        BaseDatos bd=new BaseDatos ();
        var coleccion=bd.ObternerColeccion<Registro>("Usuarios");
        if (coleccion==null){
            throw new Exception ("No existe la colección usuario");
        }
        FilterDefinitionBuilder <Registro> filterBuilder=new FilterDefinitionBuilder<Registro>();
        var filter=filterBuilder.Eq(x=>x.Correo,datos.Correo);
        Registro? usuarioExistente=coleccion.Find(filter).FirstOrDefault();
        if (usuarioExistente !=null){
            return Results.BadRequest($"Ya existe un usuario con el correo{datos.Correo}");
        }
        coleccion.InsertOne(datos);
        return Results.Ok();
            }
public static IResult Recuperar(recuperar datos) {
      if (string.IsNullOrWhiteSpace(datos.Correo)){
            return Results.BadRequest("El Correo es requerido");
        }
        BaseDatos bada = new BaseDatos();
        var coleccion = bada.ObternerColeccion<Registro>("Usuarios");
        if(coleccion == null){
            throw new Exception("No existe la coleccion Usuarios");
        }
        FilterDefinitionBuilder<Registro> filterBuilder = new FilterDefinitionBuilder<Registro>();
        var filter = filterBuilder.Eq(x =>x.Correo, datos.Correo);
         
        Registro? usuarioExistente = coleccion.Find(filter).FirstOrDefault();
         if(usuarioExistente == null){
            return Results.BadRequest($"El correo es incorrecto {datos.Correo}");
         } else if(usuarioExistente.Correo==datos.Correo){
            Correos c = new Correos();
            c.Destinatario = usuarioExistente.Correo;
            c.Asunto = "Recuperacion de la contraseña";
            c.Mensaje = "Tu contraseña es: "+usuarioExistente.Password;
            c.Enviar();
         }

         return Results.Ok();
    }

    public static IResult Iniciar(IniciarSesion datos) {
        if (string .IsNullOrWhiteSpace(datos.Correo)) {
            return Results.BadRequest("Es necesario tener el correo");
        }
        if (string.IsNullOrWhiteSpace(datos.Password)) {
            return Results.BadRequest("Es necesario tener la contraseña");
        }
        BaseDatos bd = new BaseDatos();
        var coleccion = bd.ObternerColeccion<Registro>("Usuarios");
        if (coleccion == null) {
            throw new Exception("No existe la coleccion Usuario");
        }
        FilterDefinitionBuilder<Registro> filterBuilder = new FilterDefinitionBuilder<Registro>();
        var filter = filterBuilder.Eq(x => x.Correo, datos.Correo);
        var filtro = filterBuilder.Eq(y => y.Password, datos.Password);
        
        Registro? usuarioExistente = coleccion.Find(filter).FirstOrDefault();
        Registro? usuarioExistente1 = coleccion.Find(filtro).FirstOrDefault();
        if (usuarioExistente != null) {
            if (usuarioExistente.Password == datos.Password) {
                return Results.Ok("Cuenta correcta y contraseña correcta");
            } else {
                return Results.BadRequest("Cuenta correcta y contraseña incorrecta");
            }
        } else {
            return Results.BadRequest("No existe correo");
        }

}
}

