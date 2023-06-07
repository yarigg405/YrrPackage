using DG.Tweening;
using UnityEngine;


namespace Yrr.UI.Animators
{
    public sealed class PopupAnimator : TweenAnimator
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private RectTransform rootTransform;


        protected override Sequence GetSequence()
        {
            ResetToDefaul();

            var seq = DOTween.Sequence(gameObject).SetUpdate(true)
                 .Append(DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 1f, 0.3f))
                 .Join(rootTransform.DOScale(1f, 0.3f));

            return seq;
        }

        protected override void ResetToDefaul()
        {
            canvasGroup.alpha = 0;
            rootTransform.localScale = Vector3.one * 1.5f;
        }
    }
}
