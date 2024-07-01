using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    private Color _color;
    private MeshRenderer _meshRenderer;

    public int ChanсeOfSeparation { get; private set; } = 100;

    public event Action<Cube> Destroyed;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void OnMouseUpAsButton()
    {
        Destroyed?.Invoke(this);

        gameObject.SetActive(false);
    }

    public void Init(Color color, Transform localScale, int chanceOfSeparation)
    {
        _meshRenderer.material.color = color;

        transform.localScale = localScale.localScale / 2;

        ChanсeOfSeparation = chanceOfSeparation;
    }
}