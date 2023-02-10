using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    [SerializeField] private float _fadeTime = 5f;
    [SerializeField] private Color _startingColor;
    [SerializeField] private Color _endColor;

    private MeshRenderer _renderer;
    private float _timer;

    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _renderer.material.color = _startingColor;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        _renderer.material.color = Color.Lerp(_startingColor, _endColor, _timer / _fadeTime);
    }
}
