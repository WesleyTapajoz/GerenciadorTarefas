using AutoMapper;
using GerenciadorTarefas.Domain.Entity;
using GerenciadorTarefas.Domain.Identity;
using GerenciadorTarefas.Repository.Interfaces;
using GerenciadorTarefas.WebAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _repo;
        private readonly IMapper _mapper;

        public TarefaController(ITarefaRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tarefas = await _repo.GetAllAsync<Tarefa>();

                var results = _mapper.Map<TarefaModel[]>(tarefas);

                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        // POST api/<controller>
        [HttpPost("Adicionar")]
        [AllowAnonymous]
        public async Task<IActionResult> Adicionar([FromBody] TarefaModel model)
        {
            try
            {
                var emprestimo = _mapper.Map<Tarefa>(model);

                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Banco Dados Falhou {ex.Message}");
            }
            return BadRequest();

        }

        [HttpPut("Editar")]
        [AllowAnonymous]
        public async Task<IActionResult> Editar([FromBody] TarefaModel tarefaModel)
        {
            try
            {
                var tarefa = await _repo.GetById<Tarefa>(tarefaModel.Id);

                var model = _mapper.Map<Tarefa>(tarefaModel);

                _repo.Update(tarefa);

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }

            return Ok();
        }
    }
}
