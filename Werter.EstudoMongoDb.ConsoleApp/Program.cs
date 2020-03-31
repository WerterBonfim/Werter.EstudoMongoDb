using MongoDB.Bson;
using System;
using Werter.EstudoMongoDb.Infra;

namespace Werter.EstudoMongoDb.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var pessoaColecao = new SuporteColecao<BsonDocument>("mongodb://localhost:27017", "rascunho")
                .DefinirColecao("pessoas")
                .Colecao;


            #region [ Insert One ]            

            /*
             * Via Mongo Shell
                 *db.pessoas.insert({
                    "nome": "Marta de Melo de Souza",
                    "idade": 26,
                    "filiacao": {
                        "pai": "Mario de souza",
                        "mae": "Isabel Melo de Souza"
                    }
                })
             
             */

            pessoaColecao.InsertOne(new BsonDocument
            {
                { "nome", "Marta Melo Souza" },
                { "idade", 26 },
                { "filiacao",  new BsonDocument
                    {
                        { "pai", "Mario de Souza" },
                        { "mae", "Isabela Melo de Souza" },
                    }
                }
            });

            #endregion

            #region [ Save ]

            /*
             * Faz um update caso não exista
             */


            #endregion

        }
    }
}
