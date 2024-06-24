using UnityEngine;

public class RescalingСomponent : MonoBehaviour
{
    [SerializeField] private float _speed = 1;

    private void Update() =>
        transform.localScale += Vector3.one * _speed * Time.deltaTime;
}