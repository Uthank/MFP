using UnityEngine;

public class River : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 0.5f;

    private Renderer[] _renderers;

    void Start()
    {
        _renderers = GetComponentsInChildren<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * _scrollSpeed;

        foreach (var renderer in _renderers)
        {
            renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
    }
}
