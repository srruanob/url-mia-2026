using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Usuario: ");
        string nombre = Console.ReadLine();

        Console.Write("Archivo: ");
        string ruta = Console.ReadLine();

        string texto = File.ReadAllText(ruta);
        string[] lineas = File.ReadAllLines(ruta);

        int vocales = 0;
        int caracteres = texto.Length;

        foreach (char letra in texto.ToLower())
        {
            if (letra == 'a' || letra == 'e' || letra == 'i' || letra == 'o' || letra == 'u')
            {
                vocales++;
            }
        }

  
        Console.WriteLine("\n----- RESULTADOS -----");
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Número de líneas: " + lineas.Length);
        Console.WriteLine("Número de vocales: " + vocales);
        Console.WriteLine("Número de caracteres: " + caracteres);

        Directory.CreateDirectory(@"C:\MIA_parcial1");

  
        string archivoCSV = @"C:\MIA_parcial1\Resultados_Stephanie_Ruano.csv";

        File.WriteAllText(archivoCSV,
            "Nombre,Lineas,Vocales,Caracteres\n" +
            nombre + "," +
            lineas.Length + "," +
            vocales + "," +
            caracteres);

        Console.WriteLine("\nLos resultados fueron guardados en:");
        Console.WriteLine(archivoCSV);

        Console.WriteLine("\nPresione una tecla para finalizar...");
        Console.ReadKey();
    }
}
