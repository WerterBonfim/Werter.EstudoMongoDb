using MongoDB.Driver;

namespace Werter.EstudoMongoDb.Infra
{
    public sealed class SuporteColecao<T> : SuporteDb
    {
        public IMongoCollection<T> Colecao { get; private set; }

        public SuporteColecao(string stringDeConexao, string nomeBanco) : base(stringDeConexao)
        {
            DefinirBanco(nomeBanco);            
        }

        public SuporteColecao<T> DefinirColecao(string nome)
        {
            Colecao = Banco.GetCollection<T>(nome);
            return this;
        }
    }
}
