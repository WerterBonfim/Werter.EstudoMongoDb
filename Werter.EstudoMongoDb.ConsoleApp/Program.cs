using System;
using Werter.EstudoMongoDb.ConsoleApp.Suporte;


namespace Werter.EstudoMongoDb.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Werter Bonfim - Estudos MongoDb");
            
            
            //SuporteBase.DefinirDiretorioDeLog("/home/werter/Documents/dev-logs/mongodb");

            new InserindoDocumento()
                .TestarExemplos();
            
            // new AlterandoDocumentos()
            //     .TestarExemplos();

        }

        

       
    }
}