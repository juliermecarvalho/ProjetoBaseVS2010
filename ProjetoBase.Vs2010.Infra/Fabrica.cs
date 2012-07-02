using Ninject;
using Ninject.Parameters;
using ProjetoBase.Vs2010.Dominio.Lib;

namespace ProjetoBase.Vs2010.Infra
{
    public class Fabrica
    {
        private static Fabrica _fInstancia;

        public static Fabrica Instancia
        {
            get
            {
                if (_fInstancia == null)
                    _fInstancia = new Fabrica();

                return _fInstancia;
            }
        }

        private StandardKernel Kernel { get; set; }

        protected Fabrica()
        {
            var persistencia = new Modulo();
            this.Kernel = new StandardKernel(persistencia);
        }

        /// <summary>
        /// esse metódo só existe para os teste!!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stringDeConexao"></param>
        /// <returns></returns>
        internal T Obter<T>(string stringDeConexao)
        {
            return this.Kernel.Get<T>(new ConstructorArgument("stringDeConexao", stringDeConexao));
        }

        public T Obter<T>()
        {
            return this.Kernel.Get<T>();
        }

        public T Obter<T>(IUnidadeDeTrabalho unidadeTrabalho)
        {
            return this.Kernel.Get<T>(new ConstructorArgument("unidadeDeTrabalho", unidadeTrabalho));
        }
    }
}