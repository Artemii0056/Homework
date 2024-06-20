using UnityEngine;
using DG.Tweening;


public class CubeRotate : MonoBehaviour
{
    private void Start()
    {
        DoRotate();
    }

    private void DoRotate()
    {
        Vector3 targetRotation = new Vector3(0, 360, 0);
        
        transform.DORotate(targetRotation, 2f, RotateMode.LocalAxisAdd).SetLoops(-1).SetEase(Ease.Linear);
    }
}
