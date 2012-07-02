using ProjetoBase.Vs2010.Dominio.Lib;

namespace ProjetoBase.Vs2010.Persistencia.Lib
{
    public class UnidadeDeTrabalho : IUnidadeDeTrabalho
    {
        public Contexto Contexto { get; set; }

        public UnidadeDeTrabalho()
        {
            Contexto = new Contexto();
        }

        /// <summary>
        /// Atenção contrutor usado só para os testes
        /// </summary>
        /// <param name="stringDeConexao"></param>
        internal UnidadeDeTrabalho(string stringDeConexao)
        {
            Contexto = new Contexto(stringDeConexao);
        }

        /// <summary>
        /// Metódos só usado para os testes
        /// </summary>
        internal void CriarBanco()
        {
            this.Contexto.CriarBanco();
        }

        /// <summary>
        /// Metódos só usado para os testes
        /// </summary>
        internal void ExcluirBanco()
        {
            this.Contexto.ExcluirBanco();
        }

        public void Commit()
        {
            this.Contexto.SaveChanges();
        }

        public void Dispose()
        {
            this.Contexto.Dispose();
            this.Contexto = null;
        }
    }
}