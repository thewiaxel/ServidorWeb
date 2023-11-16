public class SimuladorConsumoRequestHandelr{
public static IResult VerConsumo(TransferenciaDeDatos datos){
try{
    SimuladorConsumo SC=new SimuladorConsumo();
    double Importe=SC.Importe(datos);
    return Results.Ok($"La cantidad a pagar es: $ {Importe}");
    }
catch (ArgumentException ex){
    return Results.BadRequest(ex.Message);
        }
    }
}