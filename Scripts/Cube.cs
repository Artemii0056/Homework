using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(
    typeof(MeshRenderer),
    typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private Color _color;
    private MeshRenderer _meshRenderer;
    private int _maxChanсeOfSeparation = 100;

    public event Action<Cube> Destroyed;

    public Rigidbody Rigidbody { get; private set; }

    public int ChanсeOfSeparation { get; private set; } = 100;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void OnMouseUpAsButton()
    {
        if (ChanсeOfSeparation >= Random.Range(0, _maxChanсeOfSeparation)) 
            Destroyed?.Invoke(this);

        Destroy(gameObject);
    }

    public void Init(Color color, Vector3 scale, int chanceOfSeparation)
    {
        _meshRenderer.material.color = color;

        transform.localScale = scale;

        ChanсeOfSeparation = chanceOfSeparation;
    }
}