using Microsoft.AspNetCore.Mvc;
using FolhaDePagamento.Models;
using System.Collections.Generic;
using System.Linq;

namespace FolhaDePagamento.FuncionarioControler
{
    [Route("api/funcionario")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {

        private static List<Funcionario> funcionarios = new List<Funcionario>();

        [HttpGet]
        [Route("Listar")]

        public IActionResult Listar()
        {
            return Ok(funcionarios);
        }

        //gera requisição via GET:/api/funcionario/buscar{CPF}
        [HttpGet]
        [Route("buscar/{CPF}")]
        public IActionResult Buscar([FromRoute] string cpf)
        {
            //Expressao lambda

            Funcionario funcionario = funcionarios.FirstOrDefault(
                funcionarioCadastrado => funcionarioCadastrado.Cpf.Equals(cpf)
            );
            return funcionario != null ? Ok(funcionario) : NotFound();


        }

        //POST:  /api/funcionario/cadastrar
        [HttpPost]
        [Route("cadastrar")]

        public IActionResult Cadastrar([FromBody] Funcionario funcionario)
        {
            funcionarios.Add(funcionario);
            return Created("", funcionarios);
        }

        public IActionResult Deletar([FromBody] Funcionario funcionario)
        {
            Funcionario CPF = Funcionario.Get(CPF);
            if (!CPF)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(Funcionario);
        }

        public IActionResult Atualizar(int id, Product product)
        {
            product.Id = id;
            if (!repository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}