using apimongodio.Data.Collections;
using apimongodio.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace apimongodio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController: ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost("SalvarInfectado")]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            _infectadosCollection.InsertOne(infectado);
            
            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet("ObterInfectados")]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();
            
            return Ok(infectados);
    }

        [HttpDelete("DeletarInfectados")]
        public ActionResult DeletarInfectados()
        {
            var result = _infectadosCollection.DeleteMany(Builders<Infectado>.Filter.Empty);
            if(result.DeletedCount > 0){
                return Ok($"Total de {result.DeletedCount} infectados deletados com sucesso");
            }
            else{
                 return NotFound("Nenhum infectado encontrado para deletar");
            }
        }

    }
}