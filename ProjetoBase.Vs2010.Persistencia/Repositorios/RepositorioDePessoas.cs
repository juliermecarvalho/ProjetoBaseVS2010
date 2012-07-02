using ProjetoBase.Vs2010.Dominio.Entidades;
using ProjetoBase.Vs2010.Dominio.Lib;
using ProjetoBase.Vs2010.Dominio.Repositorios;
using ProjetoBase.Vs2010.Persistencia.Repositorios.Base;

namespace ProjetoBase.Vs2010.Persistencia.Repositorios
{
    public class RepositorioDePessoas : Repositorio<Pessoa>, IRepositorioDePessoas
    {
        public RepositorioDePessoas(IUnidadeDeTrabalho unidadeDeTrabalho)
            : base(unidadeDeTrabalho)
        {
        }
    }
}