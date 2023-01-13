using System;
using System.ServiceModel;

namespace Contratos
{
    public static class Program
    {
        static void Main(string[] args)
        {
            ServiceHost servicioAnfitrion = new ServiceHost(typeof(BuscaminasServicio));
            servicioAnfitrion.Open();
            Console.WriteLine("El servicio se esta ejecutando, puede presionar la tecla [enter] para su detencion");
            Console.ReadLine();
            servicioAnfitrion.Close();
        }
    }
}
