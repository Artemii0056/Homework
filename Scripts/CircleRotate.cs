using UnityEngine;
using DG.Tweening;

namespace DefaultNamespace
{
    public class CircleRotate : MonoBehaviour
    {
        private void Start()
        {
            DoRotate();
        }

        private void DoRotate()
        {
            float scaleOffset = 1.5f;

            var localScale = transform.localScale;

            Vector3 startScale = localScale;
            Vector3 targetScale = new Vector3(localScale.x + scaleOffset, localScale.y + scaleOffset,
                localScale.z + scaleOffset);

            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(targetScale, 2f));
            sequence.Append(transform.DOScale(startScale, 2f));
            sequence.SetLoops(-1).SetEase(Ease.Linear);
        }
    }
}