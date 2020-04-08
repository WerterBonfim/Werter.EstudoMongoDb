using MongoDB.Bson;
using MongoDB.Driver;

namespace Werter.EstudoMongoDb.ConsoleApp.Suporte
{
    public abstract class SuporteBase
    {
        protected IMongoCollection<BsonDocument> Pessoas { get; }

        public SuporteBase()
        {
            Pessoas = new SuporteColecao<BsonDocument>("mongodb://localhost:27017", "rascunho")
                .DefinirColecao("pessoas");
        }

        public abstract void TestarExemplos();
    }
}