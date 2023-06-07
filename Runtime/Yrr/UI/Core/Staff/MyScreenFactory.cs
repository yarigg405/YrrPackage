using System;
using UnityEngine;

namespace Yrr.UI.Core
{
    internal sealed class MyScreenFactory : AbstractFrameFactory<Type, UIScreen>
    {
        [SerializeField]
        private UIScreen[] screens;

        protected override UIScreen GetModal(Type key)
        {
            foreach (var item in screens)
            {
                if (item.GetType() == key)
                {
                    return item;
                }
            }

            throw new Exception($"Frame {key} is not found!");
        }
    }
}