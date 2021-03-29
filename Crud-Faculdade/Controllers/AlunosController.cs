using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud_Faculdade.Services;
using Crud_Faculdade.Domain;
using Crud_Faculdade.Services.Errors;
using Microsoft.EntityFrameworkCore;

namespace Crud_Faculdade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly AlunoService _service;

        public AlunosController(AlunoService service)
        {
            _service = service;
        }

        // GET: api/Alunos
        [HttpGet]
        public IActionResult GetAlunos()
        {
            return Ok(_service.GetAlunos());
        }

        [HttpGet("{id}")]
        public IActionResult GetAluno([FromRoute] int id)
        {
            try
            {
                return Ok(_service.GetAluno(id));
            }
            catch (AlunoError err)
            {
                return NotFound(err);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAluno([FromBody] Aluno aluno)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _service.CreateAluno(aluno);

                return Created("api/alunos/" + aluno.Id, aluno); ;

            }
            catch (AlunoError err)
            {
                return BadRequest(err);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno([FromRoute] int id, [FromBody] string senha)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return Ok(await _service.UpdateAluno(id, senha));
            }
            catch (AlunoError err)
            {
                return NotFound(err);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _service.DeleteAluno(id);

                return NoContent();
            }
            catch (AlunoError err)
            {
                return NotFound(err);
            }
            catch (AlunoDbUpdateException error)
            {
                return BadRequest(error);

            }


        }
    }
}
