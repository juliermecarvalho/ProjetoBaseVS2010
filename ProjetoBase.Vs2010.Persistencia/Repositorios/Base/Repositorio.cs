using System.Linq;
using ProjetoBase.Vs2010.Dominio.Entidades.Base;
using ProjetoBase.Vs2010.Dominio.Lib;
using ProjetoBase.Vs2010.Dominio.Repositorios.Base;
using ProjetoBase.Vs2010.Persistencia.Lib;

namespace ProjetoBase.Vs2010.Persistencia.Repositorios.Base
{
    public class Repositorio<TEntidade> : IRepositorio<TEntidade> where TEntidade : Entidade
    {
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

        protected Contexto Contexto
        {
            get { return ((UnidadeDeTrabalho)_unidadeDeTrabalho).Contexto; }
        }

        public Repositorio(IUnidadeDeTrabalho unidadeDeTrabalho)
        {
            _unidadeDeTrabalho = unidadeDeTrabalho;
        }

        public TEntidade Obter(int id)
        {
            return this.Contexto.Set<TEntidade>().Find(id);
        }

        public void Salvar(TEntidade entidade)
        {
            this.Contexto.Set<TEntidade>().Add(entidade);
        }

        public void Deletar(TEntidade entidade)
        {
            this.Contexto.Set<TEntidade>().Remove(entidade);
        }

        public IQueryable<TEntidade> Listar()
        {
            return this.Contexto.Set<TEntidade>();
        }
    }
}