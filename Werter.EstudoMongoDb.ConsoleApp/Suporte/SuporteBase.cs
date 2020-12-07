using System;
using System.IO;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver.Core.Events;
using MongoDB.Driver.Encryption;

namespace Werter.EstudoMongoDb.ConsoleApp.Suporte
{
    public abstract class SuporteBase
    {
        protected IMongoCollection<BsonDocument> Pessoas { get; }
        private static string _diretorioDeLog = "/home/werter/Documents/dev-logs/mongodb";
        private static string _nomeLog = "mongo.log";
        private readonly string _stringDeConexao = "mongodb://mongo:!123Senha@localhost:27017";

        protected SuporteBase(bool logarInformacoes = true)
        {
            CriarDiretorioDeLog();

            if (logarInformacoes)
            {
                var configuracoes = CriarConexaoComLog();
                Pessoas = new SuporteColecao<BsonDocument>(configuracoes, "rascunho")
                    .DefinirColecao("pessoas");
                
                return;
            }

            Pessoas = new SuporteColecao<BsonDocument>(
                    _stringDeConexao,
                    "rascunho")
                .DefinirColecao("pessoas");
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

        private MongoClientSettings CriarConexaoComLog()
        {
            var fullPath = $"{_diretorioDeLog}/{_nomeLog}";

            var configuracoes = new MongoClientSettings
            {
                Server = new MongoServerAddress("localhost", 27017),
                Credential = MongoCredential.CreateCredential("admin", "mongo", "!123Senha"),
                ClusterConfigurator = cb =>
                {
                    var jsonSettings = new JsonWriterSettings {Indent = true};

                    cb.Subscribe<CommandStartedEvent>(x =>
                        File.AppendAllText(
                            fullPath,
                            $"\n{x.CommandName} = {x.Command.ToJson(jsonSettings)}"));
                }
            };

            return configuracoes;
        }

        public abstract void TestarExemplos();
    }
}