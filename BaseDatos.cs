using MongoDB.Driver;

public class BaseDatos{
    private string conexion= "mongodb+srv://axel:CBTIS105@cluster0.qhtxgkt.mongodb.net/?retryWrites=true&w=majority";
    private string baseDatos="Proyecto";
    public IMongoCollection<T>? ObternerColeccion<T>(string coleccion){
        MongoClient client = new MongoClient(this.conexion);
        IMongoCollection<T>? collection=client.GetDatabase(this.baseDatos).GetCollection<T>(coleccion);
        return collection;
    }
}