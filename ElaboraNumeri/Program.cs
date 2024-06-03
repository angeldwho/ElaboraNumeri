using System;
using System.Collections.Generic;

public class Program
{
    public static double ElaboraNumeri(List<double> numeri)
    {
        double sum = numeri.AsParallel().Select(

                 (numero, indice) => ElaboraNumero(numero, indice)).Sum();
        return sum;
    }

    private static double ElaboraNumero(double numero, int indice)
    {
        switch (indice % 3)
        {
            case 0:
                return -numero;
            case 1:
                return Math.Pow(numero, 3);
            case 2:
                return Math.Round(numero);
            default:
                throw new ArgumentException("Indice non valido");
        }
    }

    public static void Main()
    {
        List<double> numeri = new List<double> { 1.5, 2.3, 3.7, 4.1, 5.6, 6.8 };
        double risultato = ElaboraNumeri(numeri);
        Console.WriteLine("La somma dei numeri elaborati è: " + risultato);
    }
}