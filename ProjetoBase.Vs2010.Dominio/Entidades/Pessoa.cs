using ProjetoBase.Vs2010.Dominio.Entidades.Base;
using ProjetoBase.Vs2010.Dominio.Enumerados;

namespace ProjetoBase.Vs2010.Dominio.Entidades
{
    public class Pessoa : Entidade
    {
        public string Nome { get; set; }

        public Sexo Sexo
        {
            get { return (Sexo)_sexoInt; }
            set { _sexoInt = (int)value; }
        }

        private int _sexoInt;

        internal virtual int SexoInt
        {
            get { return _sexoInt; }
            set { _sexoInt = value; }
        }
    }
}