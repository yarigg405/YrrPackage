using System;
using UnityEngine;
using UnityEngine.Events;


namespace Yrr.UI
{
    public abstract class UIScreen : MonoBehaviour
    {
        [Space]
        [SerializeField] private UnityEvent<object> onShow;
        [SerializeField] private UnityEvent onHide;

        private event Action ClosingCallback;

        internal virtual void InitializeScreen() { }


        public void Show(object args, Action callback)
        {
            ShowProcedure();
            ClosingCallback = callback;
            OnShow(args);
            onShow?.Invoke(args);
        }

        protected virtual void ShowProcedure()
        {
            gameObject.SetActive(true);
        }

        protected virtual void OnShow(object args) { }


        public void Hide()
        {
            OnHide();
            onHide?.Invoke();
            ClosingCallback?.Invoke();
            ClosingCallback = null;
            HidingProcedure();
        }

        protected virtual void HidingProcedure()
        {
            gameObject.SetActive(false);
        }

        protected virtual void OnHide() { }
    }
}