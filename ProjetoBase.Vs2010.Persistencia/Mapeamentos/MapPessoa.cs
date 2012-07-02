using System.Data.Entity.ModelConfiguration;
using ProjetoBase.Vs2010.Dominio.Entidades;

namespace ProjetoBase.Vs2010.Persistencia.Mapeamentos
{
    internal class MapPessoa : EntityTypeConfiguration<Pessoa>
    {
        public MapPessoa()
        {
            this.ToTable("Pessoas");
        }
    }
}