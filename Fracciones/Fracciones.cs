public class Fraccion{
    public double Entero{get;set;}
    public double Denominador{get;set;}
    public double Numerador{get;set;}

public Fraccion(double numerador, double denominador){
 this.Denominador=denominador;
 this.Numerador=numerador;
}
public Fraccion(double numerador, double denominador, double entero){
 this.Entero=entero;
 this.Denominador=denominador;
 this.Numerador=numerador;
}
public double ObtenerNumDecimal(){
    double resultado =Entero+(Numerador/(double)Denominador);
    return resultado;
}
public string ObtenerFraccion(){
    string num=Numerador.ToString();
    string dem=Denominador.ToString();
if (this.Entero==0){
    string contatenar=(num.Trim()+"/"+dem.Trim());
    return contatenar;
}else{
    string ent=this.Entero.ToString();
    string contatenar=(ent.Trim()+" "+num.Trim()+"/"+dem.Trim());
    return contatenar;
}
}
public string IdentificadorDeFracciones(){
    if (Numerador<Denominador){
        return "la fraccion es propia";
    }else{
        if (Numerador>Denominador){
            return "la fracciones es impropia";
        }else{
            if (Numerador<Denominador&& Entero>0){
                return "la fraccion es mixta";
            }else{
                if (Numerador>Denominador&& Entero>0){
                    return "la fraccion es mixta impropia";
                }else{
                    return "el valor que ingreso no existe";
                }
            }
        }
}
}
public Fraccion ConvertirFraccionAImpropia(){
    if (Numerador>Denominador){
        double resultado=(Denominador*Entero)+Numerador;
         return new Fraccion(resultado,this.Denominador);
    }else{
return new Fraccion(this.Entero,this.Numerador,this.Denominador);
    }
}
public Fraccion ConvertirFraccionAMixta(){
    if (Numerador<Denominador){
        double resultado=(Denominador*Entero)+Numerador;
        double ent=Numerador%Denominador;
         return new Fraccion(ent,resultado,this.Denominador);
    }else{
return new Fraccion(this.Entero,this.Numerador,this.Denominador);
    }
}
}