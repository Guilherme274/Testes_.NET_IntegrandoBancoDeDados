using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;

namespace ClienteRepositorioTestes
{
    public class UnitTest1
    {
        [Fact]
        public void TestaObterTodosoClientes()
        {

            //Arrange
            var _repositorio = new ClienteRepositorio();

            //Act
            List<Cliente> lista = _repositorio.ObterTodos();

            //Arrange
            Assert.NotNull(lista);
        }
    }
}