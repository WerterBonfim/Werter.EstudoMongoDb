using Werter.EstudoMongoDb.ConsoleApp.Suporte;
using B = MongoDB.Driver.Builders<MongoDB.Bson.BsonDocument>;

namespace Werter.EstudoMongoDb.ConsoleApp
{
    public class AlterandoDocumentos : SuporteBase
    {

        private void Update()
        {
            /*
            *
               db.pessoas.save({
                   "_id": "2",
                   "nome": "Mario Cruz",
                   "idade": 26
               })

               db.pessoas.find({ "_id": "2"})

               // Obs: A alteraçao faz o documento ir para final da fila
               db.pessoas.update(
                   { "nome": "Mario Cruz" }, { "nome": "Mario Cruz", "idade": 29 }
               )
                   
               db.pessoas.find({ "_id": "2"})
            */

            Pessoas.UpdateOne(
                B.Filter.Eq("nome", "Mario Cruz"),
                B.Update.Set("idade", 50)
            );
        }


        public override void TestarExemplos()
        {
            Update();
        }
    }
}