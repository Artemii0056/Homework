using UnityEngine;
using DG.Tweening;

namespace DefaultNamespace
{
    public class SphereRotate : MonoBehaviour
    {
        private void Start()
        {
            DoMove();
        }

        private void DoMove()
        {
            var position = transform.position;

            float startPositinZ = position.z;
            
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOMoveZ(position.z + 2f, 1f));
            sequence.Append(transform.DOMoveZ(startPositinZ, 1f));
            sequence.SetLoops(-1).SetEase(Ease.Linear);
        }
    }
}