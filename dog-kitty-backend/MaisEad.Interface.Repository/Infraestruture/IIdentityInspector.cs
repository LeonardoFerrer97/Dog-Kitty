using System;
namespace MaisEad.Interface.Repository.Infraestruture
{
    public interface IIDentityInspector<TEntity> where TEntity : class
    {
        string GetColumnsIdentityForType();
    }
}
