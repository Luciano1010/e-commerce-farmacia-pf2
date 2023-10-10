using e_commerce_farmacia_pf2.Model;
using e_commerce_farmacia_pf2.Service;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_farmacia_pf2.Controllers
{
    [Route("~/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaservice;
        private readonly IValidator<Categoria> _categoriaValidator;
        public CategoriaController(ICategoriaService categoriaservice, IValidator<Categoria> categoriaValidator)

        {
            _categoriaservice = categoriaservice;
            _categoriaValidator = categoriaValidator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _categoriaservice.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetbyId(long id)
        {
            var Resposta = await _categoriaservice.GetById(id);

            if (Resposta == null)
                return NotFound();

            return Ok(Resposta);
        }

        [HttpGet("tipo/{tipo}")]
        public async Task<ActionResult> GetbyTipo(string tipo)
        {
            var Resposta = await _categoriaservice.GetByTipo(tipo);

            if (Resposta == null)
                return NotFound();

            return Ok(Resposta);
        }


        [HttpPost] 
        public async Task<ActionResult> Create([FromBody] Categoria categorias)
        {
            var validarcategorias = await _categoriaValidator.ValidateAsync(categorias);

            if (!validarcategorias.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validarcategorias);
            }
            await _categoriaservice.Create(categorias);

            return CreatedAtAction(nameof(GetbyId), new { id = categorias.Id }, categorias);

        }


        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Categoria categorias)
        {
            if (categorias.Id == 0)
                return BadRequest("Id da categoria é invalido");

            var validarcategorias = await _categoriaValidator.ValidateAsync(categorias);
            if (!validarcategorias.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validarcategorias);
            }

            var Resposta = await _categoriaservice.Update(categorias);

            if (Resposta is null)
                return NotFound("Categoria não Encontrada");

            return Ok(Resposta);

        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(long Id)
        {
            var BuscaPostagem = await _categoriaservice.GetById(Id);


            if (BuscaPostagem is null)
                return NotFound("Postagem não encontrada");

            await _categoriaservice.Delete(BuscaPostagem);
            return NoContent();


        }
    }
}