using System;
using UnityEngine;


namespace Yrr.UI
{
    public sealed class UIManager : MonoBehaviour
    {
        public event Action<UIScreen> OnScreenShown;
        public event Action<UIScreen> OnScreenHided;
        public event Action<UIScreen> OnModalShown;

        private ScreenStorage _screenStorage;
        private ScreenManager _screenManager;


        private void Start()
        {
            _screenStorage = new ScreenStorage();
            _screenManager = new ScreenManager(_screenStorage);

            _screenManager.OnScreenShown += OnScreenShown;
            _screenManager.OnScreenHided += OnScreenHided;
            _screenManager.OnModalShown += OnModalShown;


            var windows = transform.GetComponentsInChildren<UIScreen>(true);

            foreach (var screen in windows)
            {
                _screenStorage.AddScreen(screen.GetType(), screen);
                screen.InitializeScreen();
                screen.Hide();
            }

            GoToScreen(windows[0]);
        }

        #region Open screens methods

        public void GoToScreen(UIScreen screen)
        {
            _screenManager.ChangeScreen(screen.GetType(), null, null);
        }


        [HideInInspector]
        public void GoToScreen(Type key, object args = null)
        {
            _screenManager.ChangeScreen(key, args, null);
        }

        [HideInInspector]
        public void GoToScreen(Type key, object args, Action callback)
        {
            _screenManager.ChangeScreen(key, args, callback);
        }

        [HideInInspector]
        public void GoToScreen(Type key, Action callback)
        {
            _screenManager.ChangeScreen(key, null, callback);
        }


        public void GoToScreen<T>(object args = null)
        {
            GoToScreen(typeof(T), args);
        }

        public void GoToScreen<T>(Action callback)
        {
            GoToScreen(typeof(T), callback);
        }

        public void GoToScreen<T>(object args, Action callback)
        {
            GoToScreen(typeof(T), args, callback);
        }

        #endregion


        #region Open modal methods

        public void OpenModal(UIScreen screen)
        {
            _screenManager.ShowModal(screen.GetType(), null, null);
        }


        [HideInInspector]
        public void OpenModal(Type key, object args = null)
        {
            _screenManager.ShowModal(key, args, null);
        }

        [HideInInspector]
        public void OpenModal(Type key, Action callback)
        {
            _screenManager.ShowModal(key, null, callback);
        }

        [HideInInspector]
        public void OpenModal(Type key, object args, Action callback)
        {
            _screenManager.ShowModal(key, args, callback);
        }


        public void OpenModal<T>(object args = null)
        {
            OpenModal(typeof(T), args);
        }

        public void OpenModal<T>(Action callback)
        {
            OpenModal(typeof(T), callback);
        }

        public void OpenModal<T>(object args, Action callback)
        {
            OpenModal(typeof(T), args, callback);
        }

        #endregion
    }
}
