using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LojaWEB_EF.Models;
using LojaWEB_EF.Contextos;

namespace LojaWEB_EF.Controllers
{
    [Route("api/[controller]")]
    public class PedidoController:Controller
    {
        Pedido pedido = new Pedido();
        readonly LojaContexto contexto;

        public PedidoController(LojaContexto contexto)
        {
            this.contexto = contexto;
        }
        [HttpGet]
        public IEnumerable<Pedido> Listar()
        {
            return contexto.Pedido.ToList();
        }

        [HttpGet("{idPedido}")]
        public Pedido Listar(int idPedido)
        {
            return contexto.Pedido.Where(x => x.idPedido == idPedido).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Cadastro([FromBody] Pedido pedido)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            contexto.Pedido.Add(pedido);
            int x = contexto.SaveChanges();
            if (x > 0)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut("{idPedido}")]
        public IActionResult Atualizar (int idPedido, [FromBody] Pedido pedido)
        {
            if (pedido == null || pedido.idPedido!=idPedido){
                return BadRequest();
            }
            var cli = contexto.Pedido.FirstOrDefault();
            if (cli == null)
                return NotFound();
            
            cli.idProduto = pedido.idProduto;
            cli.idCliente = pedido.idCliente;
            cli.quantidade = pedido.quantidade;
            cli.produto = pedido.produto;
            cli.cliente = pedido.cliente;

            contexto.Pedido.Update(cli);
            int rs = contexto.SaveChanges();

            if(rs > 0)
                return Ok();
            else
                return BadRequest();

        }

        [HttpDelete("{idPedido}")]
        public IActionResult Apagar (int idPedido)
        {
            var pedido = contexto.Pedido.Where(x=>x.idPedido==idPedido).FirstOrDefault();
            if(pedido == null)
                return NotFound();

            contexto.Pedido.Remove(pedido);
            int rs = contexto.SaveChanges();
            if(rs > 0)
                return Ok();
            else
                return BadRequest();
        }
    }
}