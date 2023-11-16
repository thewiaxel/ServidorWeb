using MongoDB.Bson;

public class Registro{
    public string? Correo{get; set;}
    public string? Nombre{get; set;}
    public string? Password{get; set;}
    public ObjectId Id{get;set;}
}     
public class recuperar{
    public string? Correo{get; set;}
}     
public class IniciarSesion{
    public string? Correo {get; set;}
    public string? Password {get; set;}
}
public class CategoriaDTO{
    public string? Nombre {get; set;}
    public string? UrlIcono {get;set;}
}
public class CategoriaDBMap{
    public ObjectId Id {get; set;}
    public string? Nombre {get; set;}
    public string? UrlIcono {get; set;}
}
public class LenguajeDTO{
public string? IdCategoria{get;set;}

public string? Descripcion {get;set;}

public string? Titulo {get;set;}

public bool? EsVideo {get;set;}

public string? Url {get;set;}
}
public class LenguajeDBMap{
 public string? IdCategoria{get;set;}
public ObjectId Id {get;set;}
public string? Descripcion {get;set;}

public string? Titulo {get;set;}

public bool? EsVideo {get;set;}

public string? Url {get;set;}
}