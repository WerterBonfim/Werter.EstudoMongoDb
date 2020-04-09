using System.IO;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;

namespace Werter.EstudoMongoDb.ConsoleApp.Suporte
{
    public abstract class SuporteBase
    {
        protected IMongoCollection<BsonDocument> Pessoas { get; }

        public SuporteBase(bool logarInformacoes = true)
        {
            if (logarInformacoes)
            {
                var configuracoes = CriarConexaoComLog();
                Pessoas = new SuporteColecao<BsonDocument>(configuracoes, "rascunho")
                    .DefinirColecao("pessoas");
                return;
            }

            Pessoas = new SuporteColecao<BsonDocument>(
                    "mongodb://localhost:27017",
                    "rascunho")
                .DefinirColecao("pessoas");
        }
        
       

        private MongoClientSettings CriarConexaoComLog()
        {
            var configuracoes = new MongoClientSettings
            {
                Server = new MongoServerAddress("localhost", 27017),

                ClusterConfigurator = cb =>
                {
                    var jsonSettings = new JsonWriterSettings {Indent = true};

                    cb.Subscribe<CommandStartedEvent>(x =>
                        File.AppendAllText(
                            "log-mongodb.txt",
                            $"\n{x.CommandName} = {x.Command.ToJson(jsonSettings)}"));
                }
            };

            return configuracoes;
        }

        public abstract void TestarExemplos();
    }
}