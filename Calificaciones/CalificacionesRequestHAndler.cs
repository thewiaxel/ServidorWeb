public static class CalificacionesRequestHandlers{
    public static IResult MostrarCalificaciones(){
        List<CalificacionMateria>list = new List<CalificacionMateria>();

        CalificacionMateria m1 = new CalificacionMateria();
        m1.Calificacion=10;
        m1.Materia= "programacion Orientada a Objectos ";
        m1.Parcial=1;
        m1.NumControl=22328051051234;

        CalificacionMateria m2 =new CalificacionMateria();
        m2.Calificacion= 9;
        m2.Materia="Programacion Orientada a Eventos";
        m2.Parcial =1;
        m2.NumControl=22328051051234;
        
        CalificacionMateria m3 = new CalificacionMateria();
        m3.Calificacion=7.2;
        m3.Materia ="Trigonometria analitica";
        m3.Parcial = 1;
        m3.NumControl= 22328051051234;

        CalificacionMateria m4 = new CalificacionMateria();
        m3.Calificacion=7.8;
        m3.Materia ="Ingles";
        m3.Parcial = 1;
        m3.NumControl= 22328051051234;

        CalificacionMateria m5 = new CalificacionMateria();
        m3.Calificacion=8.2;
        m3.Materia ="Etica";
        m3.Parcial = 1;
        m3.NumControl= 22328051051234;

        CalificacionMateria m6 = new CalificacionMateria();
        m3.Calificacion=6.2;
        m3.Materia ="Biologia";
        m3.Parcial = 1;
        m3.NumControl= 22328051051234;

        list.Add(m1);
        list.Add(m2);
        list.Add(m3);
        list.Add(m4);
        list.Add(m5);
        list.Add(m6);
        return Results.Ok(list);
    
    }
public static IResult MostrarCalificacionesAlumno(long NumControl){
if (NumControl==22328051051234){
    List<CalificacionMateria> list=new List<CalificacionMateria>();

    CalificacionMateria m1=new CalificacionMateria();
    m1.Calificacion=10;
    m1.Materia="Programacion Orientada a Objetos";
    m1.Parcial=1;
    m1.NumControl=22328051051234;

    list.Add(m1);

    return Results.Ok(list);
}else{
    return Results.NotFound($"No existe un alumno con numero de control{NumControl}");
}
}
}