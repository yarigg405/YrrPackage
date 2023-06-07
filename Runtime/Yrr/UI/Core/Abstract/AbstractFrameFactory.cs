using UnityEngine;


namespace Yrr.UI.Core
{
    internal abstract class AbstractFrameFactory<TKey, TValue> : MonoBehaviour, IScreenFactory<TKey, TValue> where TValue : UIScreen
    {
        [SerializeField]
        private Transform container;

        public TValue GetScreen(TKey key)
        {
            var modal = GetModal(key);  
            return modal;
        }

        protected abstract TValue GetModal(TKey key);

        protected virtual void OnFrameCreated(TValue popup)
        {
        }
    }
}