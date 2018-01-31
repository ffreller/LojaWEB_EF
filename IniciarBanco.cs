using System.Linq;
using LojaWEB_EF.Contextos;
using LojaWEB_EF.Models;

namespace LojaWEB_EF
{
    public class IniciarBanco
    {
        public static void Iniciar(LojaContexto contexto)
        {
            contexto.Database.EnsureCreated();
            if(contexto.Cliente.Any())
            {
                return;
            }
        
        var cliente = new Cliente()
            {nomeCliente="Pedro", email="pedro@terra.com.br", idade=23};
        contexto.Cliente.Add(cliente);

        var produto = new Produto()
            {nomeProduto="Mouse", descricao="Mouse Microsoft", preco=20, quantidade=10};
        contexto.Produto.Add(produto);

        var pedido = new Pedido()
            {idCliente=cliente.idCliente, idProduto=produto.idProduto, quantidade=1};
        contexto.Pedido.Add(pedido);
        
        contexto.SaveChanges();
        }
    }
}