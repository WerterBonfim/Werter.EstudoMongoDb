using MongoDB.Bson;
using MongoDB.Driver;
using Werter.EstudoMongoDb.ConsoleApp.Suporte;
using B = MongoDB.Driver.Builders<MongoDB.Bson.BsonDocument>;

namespace Werter.EstudoMongoDb.ConsoleApp
{
    public class AlterandoDocumentos : SuporteDb, ICenarioDeEstudo
    {
        private void Update()
        {
            // https://docs.mongodb.com/manual/reference/operator/update/set/#behavior
            /*
            *
                // Adiciona, caso nao exista ou atualiza
                db.pessoas.save({
                    "_id" : "2",
                    "nome" : "Mario Cruz",
                    "idade" : 15
                })

                db.pessoas.find({ "_id": "2" })

                // uso do operador $set = atualiza somente o conteudo que esta contido nele
                db.pessoas.update(
                    { "nome": "Mario Cruz" },
                    { "$set": { "idade": 30 } }
                )
                    
                db.pessoas.find({ "_id": "2" })
            */

            // comandos equivalentes

            Pessoas.UpdateOne(
                filter: B.Filter.Eq("nome", "Mario Cruz"),
                update: B.Update.Set("idade", 50)
            );


            Pessoas.UpdateOne(
                filter: B.Filter.Eq("nome", "Mario Cruz"),
                update: new BsonDocument("$set", new BsonDocument("idade", 51))
            );
        }

        #region [ Exemplos: Update com upset e multi]

        private void UpdateCom_upset_e_multi()
        {
            InserirExemplosParaUpdate();

            var resultado = Pessoas.UpdateMany(
                filter: B.Filter.Eq("idade", 20),
                update: B.Update.Set("idade", 70)
            );
        }

        private void InserirExemplosParaUpdate()
        {
            var exite = Pessoas
                .Find(B.Filter.Eq("_id", "100"))
                .Any();

            if (exite)
                return;

            var werter = new BsonDocument {{"_id", "100"}, {"nome", "Werter Bonfim"}, {"idade", 30}};
            var liz = new BsonDocument {{"_id", "101"}, {"nome", "Lizandra Bonfim"}, {"idade", 25}};
            var fulano = new BsonDocument {{"_id", "102"}, {"nome", "Fulano qualquer"}, {"idade", 20}};
            var ciclano = new BsonDocument {{"_id", "103"}, {"nome", "Ciclano sem nome"}, {"idade", 20}};
            var beltrano = new BsonDocument {{"_id", "104"}, {"nome", "Beltrano de alguem"}, {"idade", 20}};

            var pessoas = new[]
            {
                werter, liz, fulano, ciclano, beltrano
            };

            Pessoas.InsertMany(pessoas);
        }

        #endregion


        public void ExecutarExemplos()
        {
            InserirExemplosParaUpdate();
            Update();
            UpdateCom_upset_e_multi();
        }
        
    }
}