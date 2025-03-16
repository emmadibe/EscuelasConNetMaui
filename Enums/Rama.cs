namespace EscuelaConMaui.Enums
{
    public enum Rama
    {
        HUMANIDADES = 1,
        EXACTAS = 2,
        ECONOMICAS = 3,
        LENGUA = 4,
        ARTE = 5,
        EDUCACIONFISICA = 6,
        IDIOMAS = 7,
        OTRO = 8
    }

    public static class RamaExtensions //Clase estática. Al ser estática, no puede ser instanciaca ni puede heredar (excepto, implícitamente, de Object, obvio). Sus métodos deben ser todos estáticos. 
    {
        public static (string Nombre, int Valor) GetInfo(this Rama rama) //Este método estático retorna una colección TUPLA la cual posee, cada elemento, dos datos: un string y un int). Como parámetro el método recibe una Rama. 
        {
            return rama switch //Según el valor de rama, será la tupla que retorne. Por ejemplo, si el valor de rama es HUMANIDADES, la tupla que retorna será ("Humanidades", 1).
            {
                Rama.HUMANIDADES => ("Humanidades", 1),
                Rama.EXACTAS => ("Ciencias Exactas", 2),
                Rama.ECONOMICAS => ("Ciencias Económicas", 3),
                Rama.LENGUA => ("Prácticas del lenguaje y literatura", 4),
                Rama.ARTE => ("Artística", 5),
                Rama.EDUCACIONFISICA => ("Educación física", 6),
                Rama.IDIOMAS => ("Idioma extranjero", 7),
                Rama.OTRO => ("otro", 8),
                _ => throw new ArgumentException("Rama no reconocida")
            };
        }
    }

}