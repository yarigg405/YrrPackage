using DG.Tweening;
using UnityEngine;
using Yrr.UI.Animators;

namespace Game
{
    internal sealed class ShowWithScaleAnimator : TweenAnimator
    {
        [SerializeField] private Transform root;
        [SerializeField] private float maxScale = 1.2f;
        [SerializeField] private float duration1;
        [SerializeField] private float duration2;

        protected override Sequence GetSequence()
        {
            DOTween.Kill(this);
            root.localScale = Vector3.zero;
            var seq = DOTween.Sequence(this).SetUpdate(true)
                .Append(root.DOScale(maxScale, duration1))
                .Append(root.DOScale(1, duration2));

            return seq;
        }

        protected override void ResetToDefault()
        {
            root.localScale = Vector3.one;
        }
    }
}
