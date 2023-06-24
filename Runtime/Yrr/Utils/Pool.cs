using System.Collections.Generic;
using UnityEngine;


namespace Yrr.Utils
{
    public class Pool<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private Transform objectsInPoolContainer;
        private T _prefab;
        private readonly Queue<T> _pooledObjects = new();

        public void InitializePool(T prefab, int initialCount)
        {
            _prefab = prefab;
            for (var i = 0; i < initialCount; i++)
            {
                var bullet = Instantiate(prefab, objectsInPoolContainer);
                _pooledObjects.Enqueue(bullet);
            }
        }

        public T SpawnObject(Transform parentForNewObject = null)
        {
            var parent = parentForNewObject == null ? null : parentForNewObject;

            if (_pooledObjects.TryDequeue(out var newObject))
            {
                newObject.transform.SetParent(parent);
            }
            else
            {
                newObject = Instantiate(_prefab, parent);
            }

            return newObject;
        }

        public void DespawnObject(T poolableObject)
        {
            _pooledObjects.Enqueue(poolableObject);
            poolableObject.transform.SetParent(this.objectsInPoolContainer);
        }

    }
}
