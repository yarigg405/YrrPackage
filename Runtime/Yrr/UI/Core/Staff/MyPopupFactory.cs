using System;
using System.Collections.Generic;


namespace Yrr.UI.Core
{
    internal sealed class MyPopupFactory : AbstractFrameFactory<Type, UIModalScreen>
    {
        private Dictionary<Type, UIModalScreen> _modals = new();

        private void Start()
        {
            var windows = transform.GetComponentsInChildren<UIModalScreen>(true);

            foreach (var screen in windows)
            {
                _modals.Add(screen.GetType(), screen);
                screen.Hide();
            }
        }

        protected override UIModalScreen GetModal(Type key)
        {
            return _modals[key];
            throw new Exception($"Screen {key} is not found!");
        }
    }
}