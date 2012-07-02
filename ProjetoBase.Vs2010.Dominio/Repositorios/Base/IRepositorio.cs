using System.Linq;
using ProjetoBase.Vs2010.Dominio.Entidades.Base;

namespace ProjetoBase.Vs2010.Dominio.Repositorios.Base
{
    public interface IRepositorio<TEntidade> where TEntidade : IEntidade
    {
        TEntidade Obter(int id);

        void Salvar(TEntidade entidade);

        void Deletar(TEntidade entidade);

        IQueryable<TEntidade> Listar();
    }
}