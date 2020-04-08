using System;


namespace Werter.EstudoMongoDb.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Werter Bonfim - Estudos MongoDb");

            // new InserindoDocumento()
            //     .TestarExemplos();
            
            new AlterandoDocumentos()
                .TestarExemplos();

        }

        

       
    }
}