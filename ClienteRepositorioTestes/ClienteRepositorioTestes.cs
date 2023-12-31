using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace ClienteRepositorioTestes
{
    public class ClienteRepositorioTestes
    {
        private readonly IClienteRepositorio _repositorio;
        public ClienteRepositorioTestes()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IClienteRepositorio>();
        }

        [Fact]
        public void TestaObterTodosoClientes()
        {

            //Arrange
            //Act
            List<Cliente> lista = _repositorio.ObterTodos();

            //Arrange
            Assert.NotNull(lista);
            Assert.Equal(3, lista.Count);
        }


        [Fact]
        public void TestaObterClientePorId()
        {
            //Arrange
            //Act
            var cliente = _repositorio.ObterPorId(1);



            //Assert
            Assert.NotNull(cliente);
        }
    }
}