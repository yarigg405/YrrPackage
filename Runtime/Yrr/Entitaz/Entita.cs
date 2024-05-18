using System;
using System.Collections.Generic;
using UnityEngine;


namespace Yrr.Entitaz
{
    public class Entita : MonoBehaviour, IEntita
    {
        private readonly Dictionary<Type, object> _components = new();


        public virtual void SetupEntita()
        {
            if (_components.Count > 0) return;

            var childrenComponents = GetComponentsInChildren<IEntitazComponent>();

            foreach (var child in childrenComponents) 
                AddEntityComponent(child);
        }


        public void AddEntityComponent(object component)
        {
            _components.Add(component.GetType(), component);
        }

        void IEntita.AddEntityComponent(object component, Type componentType)
        {
            _components.Add(componentType, component);
        }

        T IEntita.GetEntityComponent<T>()
        {
            return (T)_components[typeof(T)];
        }

        bool IEntita.TryGetEntityComponent<T>(out T element)
        {
            if (_components.TryGetValue(typeof(T), out var result))
            {
                element = (T)result;
                return true;
            }

            element = default;
            return false;
        }
    }
}
