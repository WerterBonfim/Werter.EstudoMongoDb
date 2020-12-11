using System;
using System.IO;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver.Core.Events;

namespace Werter.EstudoMongoDb.ConsoleApp.Suporte
{
    public class SuporteLog
    {
        private static string _diretorioDeLog = "/home/werter/Documents/dev-logs/mongodb";
        private static string _nomeLog = "mongo.json";

        public SuporteLog()
        {
            CriarDiretorioDeLog();
        }

        private void CriarDiretorioDeLog()
        {
            try
            {
                if (Directory.Exists(_diretorioDeLog))
                    return;

                Directory.CreateDirectory(_diretorioDeLog);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao tentar criar o arquivo de log " + e.Message);
                throw;
            }
        }


        public void LogarEvento(CommandStartedEvent commandStartedEvent)
        {
            var fullPath = $"{_diretorioDeLog}/{_nomeLog}";
            var jsonSettings = new JsonWriterSettings {Indent = true};

            File.AppendAllText(
                fullPath,
                $"\n" +
                $"{commandStartedEvent.CommandName} = " +
                $"{commandStartedEvent.Command.ToJson(jsonSettings)}");
        }
    }
}