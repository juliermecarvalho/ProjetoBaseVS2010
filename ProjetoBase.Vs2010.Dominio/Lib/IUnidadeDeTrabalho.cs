using System;

namespace ProjetoBase.Vs2010.Dominio.Lib
{
    public interface IUnidadeDeTrabalho : IDisposable
    {
        void Commit();
    }
}