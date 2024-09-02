using System;
using UnityEngine;

[RequireComponent(
    typeof(MeshRenderer), 
    typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private Color _color;
    private MeshRenderer _meshRenderer;
    
    public Rigidbody Rigidbody { get; private set; }

    public int ChanсeOfSeparation { get; private set; } = 100;

    public int MaxChanсeOfSeparation { get; private set; } = 100;

    public event Action<Cube> Destroyed;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void OnMouseUpAsButton()
    {
        Destroyed?.Invoke(this);

        gameObject.SetActive(false);
    }

    public void Init(Color color, Vector3 scale, int chanceOfSeparation)
    {
        _meshRenderer.material.color = color;

        transform.localScale = scale;

        ChanсeOfSeparation = chanceOfSeparation;
    }
}