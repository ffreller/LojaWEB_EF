using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LojaWEB_EF.Models;
using LojaWEB_EF.Contextos;

namespace LojaWEB_EF.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController:Controller
    {
        Cliente cliente = new Cliente();
        readonly LojaContexto contexto;

        public ClienteController(LojaContexto contexto)
        {
            this.contexto = contexto;
        }
        [HttpGet]
        public IEnumerable<Cliente> Listar()
        {
            return contexto.Cliente.ToList();
        }

        [HttpGet("{id}")]
        public Cliente Listar(int idCliente)
        {
            return contexto.Cliente.Where(x => x.idCliente == idCliente).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Cadastro([FromBody] Cliente cliente)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            contexto.Cliente.Add(cliente);
            int x = contexto.SaveChanges();
            if (x > 0)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar (int idCliente, [FromBody] Cliente cliente)
        {
            if (cliente == null || cliente.idCliente!=idCliente){
                return BadRequest();
            }
            var cli = contexto.Cliente.FirstOrDefault();
            if (cli == null)
                return NotFound();
            
            cli.idCliente = cliente.idCliente;
            cli.nomeCliente = cliente.nomeCliente;
            cli.email = cliente.email;
            cli.idade = cliente.idade;
            cli.pedido = cliente.pedido;

            contexto.Cliente.Update(cli);
            int rs = contexto.SaveChanges();

            if(rs > 0)
                return Ok();
            else
                return BadRequest();

        }

        [HttpDelete("{id}")]
        public IActionResult Apagar (int idCliente)
        {
            var cliente = contexto.Cliente.Where(x=>x.idCliente==idCliente).FirstOrDefault();
            if(cliente == null)
                return NotFound();

            contexto.Cliente.Remove(cliente);
            int rs = contexto.SaveChanges();
            if(rs > 0)
                return Ok();
            else
                return BadRequest();
        }
    }
}