using MongoDB.Driver;

namespace Werter.EstudoMongoDb.Infra
{
    public abstract class SuporteDb
    {
        protected IMongoClient Cliente { get; private set; }
        protected IMongoDatabase Banco { get; private set; }
        
        public SuporteDb(string stringDeConexao)
        {
            Cliente = new MongoClient(stringDeConexao);            
        }

        public SuporteDb DefinirBanco(string nome)
        {
            Banco = Cliente.GetDatabase(nome);
            return this;
        }
        
    }
}
