using DG.Tweening;
using UnityEngine;
using Yrr.UI.Animators;

namespace Game
{
    internal sealed class RotateAnimator : TweenAnimator
    {
        [SerializeField] private Transform root;

        [SerializeField] private float durationUp;
        [SerializeField] private float durationDown;
        [SerializeField] private Vector3 startRotation;
        [SerializeField] private Vector3 maxRotation;


        protected override Sequence GetSequence()
        {
            root.transform.localRotation = Quaternion.Euler(startRotation);
            return DOTween.Sequence().SetUpdate(true)
                  .Append(root.DOLocalRotate(maxRotation, durationUp))
                  .Append(root.DOLocalRotate(startRotation, durationDown));
        }

        protected override void ResetToDefault()
        {
            root.transform.localRotation = Quaternion.Euler(startRotation);
        }
    }
}
