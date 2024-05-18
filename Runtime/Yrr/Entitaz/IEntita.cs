using System;


namespace Yrr.Entitaz
{
    public interface IEntita
    {
        T GetEntityComponent<T>();

        bool TryGetEntityComponent<T>(out T element);

        void AddEntityComponent(object component, Type componentType);
    }
}
