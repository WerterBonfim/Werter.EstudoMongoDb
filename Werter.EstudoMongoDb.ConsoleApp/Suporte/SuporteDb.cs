using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;

namespace Werter.EstudoMongoDb.ConsoleApp.Suporte
{
    public abstract class SuporteDb
    {
        private IMongoClient Cliente { get; }
        private readonly SuporteLog _suporteLog;
        protected IMongoDatabase Banco { get; set; }

        protected IMongoCollection<BsonDocument> Pessoas { get; set; }

        protected SuporteDb(bool logarEventos = true)
        {
            _suporteLog = new SuporteLog();

            Cliente = logarEventos ? 
                new MongoClient(MontarStringDeConexao()) : 
                new MongoClient(MontarConexaoComLog());

            DefinirBanco("rascunho-csharp");
            MontarColecoes();
        }

        private void MontarColecoes()
        {
            Pessoas = DefinirColecao<BsonDocument>("pessoas");
        }

        private SuporteDb DefinirBanco(string nome)
        {
            Banco = Cliente.GetDatabase(nome);
            return this;
        }

        protected IMongoCollection<T> DefinirColecao<T>(string nome)
        {
            var colecao = Banco.GetCollection<T>(nome);
            return colecao;
        }

        private string MontarStringDeConexao()
        {
            var stringDeConexao =
                $"mongodb://{ConfiguracaoDb.Usuario}:" +
                $"{ConfiguracaoDb.Senha}@" +
                $"{ConfiguracaoDb.Host}:" +
                $"{ConfiguracaoDb.Porta}/" +
                $"{ConfiguracaoDb.BancoAutenticancao}";

            return stringDeConexao;
        }

        private MongoClientSettings MontarConexaoComLog()
        {
            var configuracoes = new MongoClientSettings
            {
                Server = new MongoServerAddress(ConfiguracaoDb.Host, ConfiguracaoDb.Porta),
                Credential = MongoCredential.CreateCredential(
                    ConfiguracaoDb.Banco,
                    ConfiguracaoDb.Usuario,
                    ConfiguracaoDb.Senha),

                ClusterConfigurator = cb =>
                    cb.Subscribe<CommandStartedEvent>(x =>
                        _suporteLog.LogarEvento(x))
            };

            return configuracoes;
        }
    }
}