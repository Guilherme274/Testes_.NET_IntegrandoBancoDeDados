using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Infraestrutura.Testes.Servico;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class AgenciaRepositorioTestes
    {
        private readonly IAgenciaRepositorio _repositorio;
        public ITestOutputHelper SaidaConsoleTeste { get; set; }

        public AgenciaRepositorioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado");

            var servico = new ServiceCollection();
            servico.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();
            var provedor = servico.BuildServiceProvider();

            _repositorio = provedor.GetService<IAgenciaRepositorio>();

        }

        [Fact]
        public void TestaObterTodasAsAgencias()
        {

            //Arrange
            //Act
            List<Agencia> lista = _repositorio.ObterTodos();

            //Assert
            Assert.NotNull(lista);
            Assert.Equal(2, lista.Count);
        }


        [Fact]
        public void TestaObterAgenciasPorId()
        {
            //Arrange
            //Act
            var agencia = _repositorio.ObterPorId(23);



            //Assert
            Assert.NotNull(agencia);
        }

        [Theory]
        [InlineData(23)]
        [InlineData(24)]
        public void TestaObterAgenciaPorVariosId(int id)
        {
            //Arrange
            //Act
            var agencia = _repositorio.ObterPorId(id);



            //Assert
            Assert.NotNull(agencia);
        }

        [Fact]
        public void TestaAtualizaNumeroAgencia()
        {

            //Arrange
            var agencia = _repositorio.ObterPorId(23);
            int novoNumeroAgencia = 213;
            agencia.Numero = novoNumeroAgencia;

            //Act
            var atualizado = _repositorio.Atualizar(23,agencia);



            //Assert
            Assert.True(atualizado);

        }

        [Fact]
        public void TestaInserirUmaNovaAgenciaNoBancoDeDados()
        {
            //Arrange 
            var agencia = new Agencia()
            {
                Nome = "Agencia Central Coast City",
                Identificador = Guid.NewGuid(),
                Id = 1,
                Endereco = "Rua Alexandre Fleming, 212",
                Numero = 43

            };



            //Act
            var retorno = _repositorio.Adicionar(agencia);

            //Assert
            Assert.True(retorno);


        }

        [Fact]
        public void TestaRemoverInformacaoDoBancoDeDados()
        {
            //Arrange
            //Act
            var dadoExcluido = _repositorio.Excluir(1);

            //Assert
            Assert.True(dadoExcluido);
        }

        [Fact]
        public void TestaExcecaoConsultaPorAgenciaPorId()
        {
            //Act
            //Assert
            Assert.Throws<FormatException>( () => _repositorio.ObterPorId(23));
        }

        [Fact]
        public void TestaObterAgenciasMock()
        {
            //Arange
            var bytebankRepositorioMock = new Mock<IByteBankRepositorio>();
            var mock = bytebankRepositorioMock.Object;

            //Act
            var lista = mock.BuscarAgencias();

            //Assert
            bytebankRepositorioMock.Verify(b => b.BuscarAgencias());
        }

        [Fact]
        public void TestaAdiconarAgenciaMock()
        {
            // Arrange
            var agencia = new Agencia()
            {
                Nome = "Agência Amaral",
                Identificador = Guid.NewGuid(),
                Id = 4,
                Endereco = "Rua Arthur Costa",
                Numero = 6497
            };

            var repositorioMock = new ByteBankRepositorio();

            //Act
            var adicionado = repositorioMock.AdicionarAgencia(agencia);

            //Assert
            Assert.True(adicionado);
        }
    }
}

