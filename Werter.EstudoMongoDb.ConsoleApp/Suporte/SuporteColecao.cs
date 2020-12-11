using MongoDB.Driver;

namespace Werter.EstudoMongoDb.ConsoleApp.Suporte
{
    public sealed class SuporteColecao<T> 
    {
        public SuporteColecao Definir(string nomeBanco) : base()
        {
            DefinirBanco(nomeBanco);      
            return this
        }


        public IMongoCollection<T> DefinirColecao(string nome)
        {
            Colecao = Banco.GetCollection<T>(nome);
            return Colecao;
        }
    }
}