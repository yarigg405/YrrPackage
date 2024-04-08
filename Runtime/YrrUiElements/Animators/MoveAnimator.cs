using DG.Tweening;
using UnityEngine;


namespace Yrr.UI.Animators
{
    internal sealed class MoveAnimator : TweenAnimator
    {
        [SerializeField] private Transform root;
        [SerializeField] private Vector3 startPos;
        [SerializeField] private Vector3 endPos;
        [SerializeField] private float duration;


        protected override Sequence GetSequence()
        {
            root.localPosition = startPos;

            var seq = DOTween.Sequence(gameObject).SetUpdate(true)
                .Append(root.DOLocalMove(endPos, duration))

                ;
            return seq;
        }

        protected override void ResetToDefault()
        {
            root.localPosition = startPos;
        }


        [ContextMenu("SetStartPos")]
        private void SetStartPos()
        {
            startPos = root.localPosition;
        }

        [ContextMenu("SetEndPos")]
        private void SetEndPos()
        {
            endPos = root.localPosition;
        }
    }
}
