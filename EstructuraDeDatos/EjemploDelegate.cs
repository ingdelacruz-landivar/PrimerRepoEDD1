using System;
using System.Collections.Generic;

// Delegado para representar funciones de transformación de datos
public delegate List<int> DataTransformer(List<int> data);

// Clase para manejar las transformaciones de datos
public class DataProcessor
{
    // Método para aplicar una transformación de datos
    public List<int> ProcessData(DataTransformer transformer, List<int> data)
    {
        return transformer(data);
    }
}

class EjemploDelegate
{
    static void Main(string[] args)
    {
        // Crear instancia de DataProcessor
        DataProcessor processor = new DataProcessor();

        // Datos de ejemplo
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        // Función para duplicar los datos
        DataTransformer duplicator = delegate (List<int> data)
        {
            List<int> result = new List<int>();
            foreach (int number in data)
            {
                result.Add(number * 2);
            }
            return result;
        };

        // Función para triplicar los datos
        DataTransformer triplicator = delegate (List<int> data)
        {
            List<int> result = new List<int>();
            foreach (int number in data)
            {
                result.Add(number * 3);
            }
            return result;
        };

        // Aplicar transformaciones a los datos
        List<int> doubledData = processor.ProcessData(duplicator, numbers);
        List<int> tripledData = processor.ProcessData(triplicator, numbers);

        // Imprimir resultados
        Console.WriteLine("Datos originales: " + string.Join(", ", numbers));
        Console.WriteLine("Datos duplicados: " + string.Join(", ", doubledData));
        Console.WriteLine("Datos triplicados: " + string.Join(", ", tripledData));
    }
}


//En este ejemplo, creamos un delegado DataTransformer que representa funciones de transformación de datos.
//Luego, definimos dos funciones anónimas utilizando delegados delegate que duplican y triplican los datos.
//Estas funciones se pasan como parámetros a un método ProcessData en la clase DataProcessor, que aplica la transformación a una lista de datos.
//Finalmente, mostramos los datos originales, duplicados y triplicados en la consola.