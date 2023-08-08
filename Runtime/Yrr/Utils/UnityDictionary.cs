using System;
using System.Collections.Generic;
using UnityEngine;


namespace Yrr.Utils
{
    [Serializable]
    public sealed class UnityDictionary<TKey, TValue>
    {
        [SerializeField] private List<UnityKeyValuePair<TKey, TValue>> data;
        private Dictionary<TKey, TValue> _repository;

        public void Initialize()
        {
            _repository = new Dictionary<TKey, TValue>();
            foreach (var item in data)
            {
                try
                {
                    _repository.Add(item.Key, item.Value);
                }

                catch (ArgumentException)
                {
                    Debug.LogError($"Item {item.Key} has already been added");
                }
            }
        }

        public TValue Get(TKey key)
        {
            if (_repository.TryGetValue(key, out var value)) return value;
            Debug.Log("Item is not found: " + key.ToString());
            return default;
        }
    }

    [Serializable]
    internal sealed class UnityKeyValuePair<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;
    }
}
