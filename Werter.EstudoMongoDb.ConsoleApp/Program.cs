using System;
using Werter.EstudoMongoDb.ConsoleApp.Suporte;


namespace Werter.EstudoMongoDb.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Werter Bonfim - Estudos MongoDb");

            ConfiguracaoDb.Usuario = "mongo";
            ConfiguracaoDb.Senha = "!123Senha";
            ConfiguracaoDb.Host = "localhost";
            ConfiguracaoDb.Porta = 27017;
            ConfiguracaoDb.Banco = "banco-csharp";
            ConfiguracaoDb.BancoAutenticancao = "admin";
            
            
            //SuporteBase.DefinirDiretorioDeLog("/home/werter/Documents/dev-logs/mongodb");

            ICenarioDeEstudo[] cenarios = {
                new InserindoDocumento(),
                new AlterandoDocumentos()
            };

            foreach (var cenario in cenarios)
                cenario.ExecutarExemplos();
            

        }

        

       
    }
}