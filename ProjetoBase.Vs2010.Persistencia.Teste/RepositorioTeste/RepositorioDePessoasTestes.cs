using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ProjetoBase.Vs2010.Dominio.Entidades;
using ProjetoBase.Vs2010.Dominio.Enumerados;
using ProjetoBase.Vs2010.Dominio.Lib;
using ProjetoBase.Vs2010.Dominio.Repositorios;
using ProjetoBase.Vs2010.Infra;
using ProjetoBase.Vs2010.Persistencia.Lib;

namespace ProjetoBase.Vs2010.Persistencia.Teste.RepositorioTeste
{
    [TestFixture]
    public class RepositorioDePessoasTestes
    {
        private int _id;

        [SetUp]
        public void Contexto()
        {
            using (IUnidadeDeTrabalho unidadeDeTrabalho = Fabrica.Instancia.Obter<IUnidadeDeTrabalho>())
            {
                var deTrabalho = unidadeDeTrabalho as UnidadeDeTrabalho;
                if (deTrabalho != null)
                    deTrabalho.CriarBanco();
            }
        }

        [TearDown]
        public void Cleanup()
        {
            using (IUnidadeDeTrabalho unidadeDeTrabalho = Fabrica.Instancia.Obter<IUnidadeDeTrabalho>())
            {
                var deTrabalho = unidadeDeTrabalho as UnidadeDeTrabalho;
                if (deTrabalho != null)
                    deTrabalho.ExcluirBanco();
            }
        }

        [Test]
        public void Crud_Pessoa()
        {
            this.Salvar_Pessoa();
            this.Listar_Pessoa();
            this.Deletar_Pessoa();
        }

        public void Salvar_Pessoa()
        {
            using (IUnidadeDeTrabalho unidadeDeTrabalho = Fabrica.Instancia.Obter<IUnidadeDeTrabalho>())
            {
                IRepositorioDePessoas repositorioDePessoas =
                    Fabrica.Instancia.Obter<IRepositorioDePessoas>(unidadeDeTrabalho);

                Pessoa pessoa = new Pessoa { Nome = "Teste", Sexo = Sexo.Masculino };

                repositorioDePessoas.Salvar(pessoa);
                unidadeDeTrabalho.Commit();

                Assert.IsTrue(pessoa.Id > 0);
                this._id = pessoa.Id;
            }
        }

        public void Listar_Pessoa()
        {
            using (IUnidadeDeTrabalho unidadeDeTrabalho = Fabrica.Instancia.Obter<IUnidadeDeTrabalho>())
            {
                IRepositorioDePessoas repositorioDePessoas =
                    Fabrica.Instancia.Obter<IRepositorioDePessoas>(unidadeDeTrabalho);

                IEnumerable<Pessoa> pessoas = repositorioDePessoas.Listar().ToList();

                CollectionAssert.AllItemsAreInstancesOfType(pessoas, typeof(Pessoa));
                Assert.AreEqual(pessoas.Count(), 1);
            }
        }

        public void Deletar_Pessoa()
        {
            using (IUnidadeDeTrabalho unidadeDeTrabalho = Fabrica.Instancia.Obter<IUnidadeDeTrabalho>())
            {
                IRepositorioDePessoas repositorioDePessoas =
                    Fabrica.Instancia.Obter<IRepositorioDePessoas>(unidadeDeTrabalho);

                Pessoa pessoa = repositorioDePessoas.Obter(_id);
                repositorioDePessoas.Deletar(pessoa);
                unidadeDeTrabalho.Commit();
                pessoa = repositorioDePessoas.Obter(_id);
                Assert.IsNull(pessoa);
            }
        }
    }
}