using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using Werter.EstudoMongoDb.ConsoleApp.Suporte;

namespace Werter.EstudoMongoDb.ConsoleApp
{
    public sealed class CriandoCollecoes : SuporteDb, ICenarioDeEstudo
    {
        public void CriarColecao()
        {
            // https://docs.mongodb.com/manual/reference/operator/query/jsonSchema/#available-keywords
            Banco.CreateCollection("cars", new CreateCollectionOptions
            {
                StorageEngine = new BsonDocument(new Dictionary<string, object>
                {
                    {
                        "model", new
                        {
                            bsonType = "string",
                            descripton = "O modelo é necessário e deve ser uma string"
                        }
                    },
                    {
                        "madeBy", new
                        {
                            bsonType = "string",
                            minLength = 3
                        }
                    },
                    {
                        "year", new
                        {
                            bsonType = "int",
                            minimum = 1980,
                            maximum = 2025
                        }
                    }
                })
            });
        }

        public void ExecutarExemplos()
        {
            CriarColecao();
        }
    }
}