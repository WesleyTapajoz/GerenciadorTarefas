using AutoMapper;
using GerenciadorTarefas.Domain.Entity;
using GerenciadorTarefas.Repository.Interfaces;
using GerenciadorTarefas.Repository.Repositories;
using GerenciadorTarefas.WebAPI.Extensions;
using GerenciadorTarefas.WebAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GerenciadorTarefas.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
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
                 var retorno = _repo.GetByIdAndUserId(User.GetUserId()).ToList();
                return Ok(retorno);

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        // POST api/<controller>
        [HttpPost("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] TarefaAddModel model)
        {
            try
            {
                var tarefa = _mapper.Map<Tarefa>(model);
                tarefa.UserId = User.GetUserId();
                _repo.Add(tarefa);

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
        public async Task<IActionResult> Editar([FromBody] TarefaAlterarModel tarefaModel)
        {
            try
            {
                if (!_repo.PermissaoUsuario(User.GetUserId()))
                    return BadRequest("Usuário não tem permissão para alterar!");

                var tarefa = await _repo.GetById<Tarefa>(tarefaModel.TarefaId);
                _mapper.Map(tarefaModel, tarefa);
                _repo.Update(tarefa);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
                return null;
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] int tarefaId)
        {
            try
            {
                if (!_repo.PermissaoUsuario(User.GetUserId()))
                    return BadRequest("Usuário não tem permissão para deletar!");


                var tarefa = await _repo.GetById<Tarefa>(tarefaId); 
                _repo.Delete(tarefa);
                if (await _repo.SaveChangesAsync())
                   return Ok();

                return null;

            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
