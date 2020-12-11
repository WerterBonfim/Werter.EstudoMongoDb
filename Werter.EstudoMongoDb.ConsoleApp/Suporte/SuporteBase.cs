using System;
using System.IO;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;

namespace Werter.EstudoMongoDb.ConsoleApp.Suporte
{
    public abstract class SuporteBase
    {
        //TODO: Criar uma classe RepositorioDeClientes
        protected IMongoCollection<BsonDocument> Pessoas { get; }


        protected SuporteBase(bool logarInformacoes = true)
        {
            if (logarInformacoes)
            {
                var configuracoes = CriarConexaoComLog();
                Pessoas = new SuporteColecao<BsonDocument>(configuracoes, "from-csharp")
                    .DefinirColecao("pessoas");

                return;
            }

            var stringDeConexao = MontarStringDeConexao();
            Pessoas = new SuporteColecao<BsonDocument>(
                    stringDeConexao,
                    "rascunho")
                .DefinirColecao("pessoas");
        }

        

        public abstract void TestarExemplos();
    }
}