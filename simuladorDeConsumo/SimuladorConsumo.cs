public class SimuladorConsumo{
    public double Importe(TransferenciaDeDatos datos){
 if(datos.MesActual==0|| datos.MesPasado==0){
    throw new ArgumentException("Debe ver algo en los recibos");
 }else{
   if (datos.MesActual<=0|| datos.MesPasado<=0){
          throw new ArgumentException("ninguno de los recibos puede ser negativo----- SI PASO PROFE?????");
   }else{
if (datos.MesActual>datos.MesPasado){
 double Importe=(datos.MesActual-datos.MesPasado)*3.7;
 return Importe;
}else{
   throw new ArgumentException("El recibo del mes actual debe ser superior que el recibo pasado");
}
   }
 }
    }
}