using DG.Tweening;
using System;
using UnityEngine;



namespace Yrr.UI.Animators
{
    public abstract class TweenAnimator : MonoBehaviour
    {
        [SerializeField] private bool playOnEnable;
        [SerializeField] private bool loop;
        private TweenCallback _callback;


        private void OnEnable()
        {
            if (playOnEnable)
            {
                Animate();
            }

            if (loop)
            {
                _callback = () => Animate();
            }
        }

        private void OnDisable()
        {
            StopAnimation();
        }


        public void Animate()
        {
            var seq = GetSequence();
            if (_callback != null)
                seq.AppendCallback(_callback);
        }

        public void StopAnimation()
        {
            DOTween.Kill(this);
            ResetToDefaul();
        }

        public void SetCallback(Action callback)
        {
            _callback = () => callback();
        }

        protected abstract Sequence GetSequence();

        protected abstract void ResetToDefaul();

    }
}
