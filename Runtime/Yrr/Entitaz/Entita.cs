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
            var childrenComponents = GetComponentsInChildren<IEntitazComponent>(true);

            for (int i = 0; i < childrenComponents.Length; i++)
            {
                var child = childrenComponents[i];
                AddEntityComponent(child);
            }
        }


        public void AddEntityComponent(object component)
        {
            _components[component.GetType()] = component;
        }

        void IEntita.AddEntityComponent(object component, Type componentType)
        {
            _components[componentType] = component;
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
