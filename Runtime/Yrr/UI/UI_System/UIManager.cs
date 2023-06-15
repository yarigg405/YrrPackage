using System;
using Unity.Android.Types;
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

        public UIScreen GetScreen<T>() where T : UIScreen
        {
            return _screenStorage.GetScreen(typeof(T));
        }

        #region Open screens methods

        public void GoToScreen(UIScreen screen)
        {
            _screenManager.ChangeScreen(screen.GetType(), null, null);
        }


        public bool GoToScreen(Type key, object args = null)
        {
            _screenManager.ChangeScreen(key, args, null);
            return true;
        }

        public bool GoToScreen(Type key, object args, Action callback)
        {
            _screenManager.ChangeScreen(key, args, callback);
            return true;
        }

        public bool GoToScreen(Type key, Action callback)
        {
            _screenManager.ChangeScreen(key, null, callback);
            return true;
        }


        public bool GoToScreen<T>(object args = null)
        {
            return GoToScreen(typeof(T), args);
        }

        public bool GoToScreen<T>(Action callback)
        {
            return GoToScreen(typeof(T), callback);
        }

        public bool GoToScreen<T>(object args, Action callback)
        {
            return GoToScreen(typeof(T), args, callback);
        }

        #endregion


        #region Open modal methods

        public void OpenModal(UIScreen screen)
        {
            _screenManager.ShowModal(screen.GetType(), null, null);
        }



        public bool OpenModal(Type key, object args = null)
        {
            _screenManager.ShowModal(key, args, null);
            return true;
        }

        public bool OpenModal(Type key, Action callback)
        {
            _screenManager.ShowModal(key, null, callback);
            return true;
        }

        public bool OpenModal(Type key, object args, Action callback)
        {
            _screenManager.ShowModal(key, args, callback);
            return true;
        }



        public bool OpenModal<T>(object args = null)
        {
            return OpenModal(typeof(T), args);
        }

        public bool OpenModal<T>(Action callback)
        {
            return OpenModal(typeof(T), callback);
        }

        public bool OpenModal<T>(object args, Action callback)
        {
            return OpenModal(typeof(T), args, callback);
        }

        #endregion
    }
}
