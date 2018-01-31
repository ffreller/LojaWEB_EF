using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LojaWEB_EF.Models;
using LojaWEB_EF.Contextos;

namespace LojaWEB_EF.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController:Controller
    {
        Produto produto = new Produto();
        readonly LojaContexto contexto;

        public ProdutoController(LojaContexto contexto)
        {
            this.contexto = contexto;
        }
        [HttpGet]
        public IEnumerable<Produto> Listar()
        {
            return contexto.Produto.ToList();
        }

        [HttpGet("{idProduto}")]
        public Produto Listar(int idProduto)
        {
            return contexto.Produto.Where(x => x.idProduto == idProduto).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Cadastro([FromBody] Produto produto)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            contexto.Produto.Add(produto);
            int x = contexto.SaveChanges();
            if (x > 0)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut("{idProduto}")]
        public IActionResult Atualizar (int idProduto, [FromBody] Produto produto)
        {
            if (produto == null || produto.idProduto!=idProduto){
                return BadRequest();
            }
            var cli = contexto.Produto.FirstOrDefault();
            if (cli == null)
                return NotFound();
            
            cli.idProduto = produto.idProduto;
            cli.nomeProduto = produto.nomeProduto;
            cli.descricao = produto.descricao;
            cli.preco = produto.preco;
            cli.quantidade = produto.quantidade;
            cli.pedido = produto.pedido;

            contexto.Produto.Update(cli);
            int rs = contexto.SaveChanges();

            if(rs > 0)
                return Ok();
            else
                return BadRequest();

        }

        [HttpDelete("{idProduto}")]
        public IActionResult Apagar (int idProduto)
        {
            var produto = contexto.Produto.Where(x=>x.idProduto==idProduto).FirstOrDefault();
            if(produto == null)
                return NotFound();

            contexto.Produto.Remove(produto);
            int rs = contexto.SaveChanges();
            if(rs > 0)
                return Ok();
            else
                return BadRequest();
        }
    }
}