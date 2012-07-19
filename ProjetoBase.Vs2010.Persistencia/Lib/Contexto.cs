using System.Data.Entity;
using ProjetoBase.Vs2010.Dominio.Entidades;
using ProjetoBase.Vs2010.Persistencia.Mapeamentos;

namespace ProjetoBase.Vs2010.Persistencia.Lib
{
    public class Contexto : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public Contexto()
            : base("Base")
        {
        }

        internal Contexto(string stringDeConexao)
            : base(stringDeConexao)
        {
        }

        /// <summary>
        /// Metódos sé para os testes
        /// </summary>
        internal void CriarBanco()
        {
            this.Database.CreateIfNotExists();
        }

        /// <summary>
        /// Metódos sé para os testes
        /// </summary>
        internal void ExcluirBanco()
        {
            this.Database.Delete();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MapPessoa());
        }
    }
}