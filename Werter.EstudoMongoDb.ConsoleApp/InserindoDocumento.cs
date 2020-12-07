using MongoDB.Bson;
using Werter.EstudoMongoDb.ConsoleApp.Suporte;

namespace Werter.EstudoMongoDb.ConsoleApp
{
    public sealed class InserindoDocumento : SuporteBase
    {
        
        
        private void Insert()
        {
            

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
                                                
                Ocorre um erro ao tentar inserir um registro com o mesmo id 
                E11000 duplicate key error collection: werter-teste.pessoas index: _id_ dup key: { _id: 1.0 }
             
             */

            Pessoas.InsertOne(new BsonDocument
            {
                {"nome", "Marta Melo Souza"},
                {"idade", 26},
                {
                    "filiacao", new BsonDocument
                    {
                        {"pai", "Mario de Souza"},
                        {"mae", "Isabela Melo de Souza"},
                    }
                }
            });

            // Gerar um erro se o mesmo _id já estiver registrado
            // Pessoas.InsertOne(new BsonDocument
            // {
            //     { "_id", 1 },
            //     { "nome", "Duplicado"}
            // });

            
        }
               

        private void Save()
        {
            /*
             *  
                db.pessoas.save({
                    "_id": "1",
                    "nome": "Olinda V. Silva",
                    "idade": 36
                })

                db.pessoas.find( { "_id": "1"} )

                // Atualiza toda a estrutura, removendo o campo idade
                db.pessoas.save({
                    "_id": "1",
                    "nome": "Olinda Vasconcelos da Silva"    
                })

                db.pessoas.find( { "_id": "1"} )
             * '
             */

        }

        public override void TestarExemplos()
        {
            Insert();
            //Save();
        }
    }
}