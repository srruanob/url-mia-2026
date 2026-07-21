using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        List<Estudiante> lista = LeerCsv("estudiantes.csv");
        MostrarLista(lista);
        GuardarJson(lista, "estudiantes.json");
    }

    // Lee el CSV y devuelve la lista de estudiantes
    static List<Estudiante> LeerCsv(string ruta)
    {
        List<Estudiante> lista = new List<Estudiante>();
        string[] todo = File.ReadAllLines(ruta);
        bool esEncabezado = true;

        foreach (string linea in todo)
        {
            if (esEncabezado)
            {
                esEncabezado = false;
                continue; // saltamos la primera fila
            }

            string[] p = linea.Split(',');

            Estudiante e = new Estudiante();
            e.Id = int.Parse(p[0]);
            e.Nombre = p[1];
            e.Carrera = p[2].Trim();

            lista.Add(e);
        }

        return lista;
    }

    // Muestra la lista en consola
    static void MostrarLista(List<Estudiante> lista)
    {
        foreach (Estudiante e in lista)
        {
            Console.WriteLine(e.Id + " - " + e.Nombre + " - " + e.Carrera);
        }
    }

    // Convierte la lista a JSON y la guarda en un archivo
    static void GuardarJson(List<Estudiante> lista, string ruta)
    {
        var opciones = new JsonSerializerOptions { WriteIndented = true };
        string texto = JsonSerializer.Serialize(lista, opciones);

        File.WriteAllText(ruta, texto);

        Console.WriteLine("Archivo " + ruta + " creado correctamente.");
    }
}