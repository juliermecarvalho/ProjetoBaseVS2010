using Ninject.Modules;
using ProjetoBase.Vs2010.Dominio.Lib;
using ProjetoBase.Vs2010.Dominio.Repositorios;
using ProjetoBase.Vs2010.Persistencia.Lib;
using ProjetoBase.Vs2010.Persistencia.Repositorios;

namespace ProjetoBase.Vs2010.Infra
{
    public class Modulo : NinjectModule
    {
        public override void Load()
        {
            base.Bind<IUnidadeDeTrabalho>().To<UnidadeDeTrabalho>();
            base.Bind<IRepositorioDePessoas>().To<RepositorioDePessoas>();
        }
    }
}