
using System.Collections.Generic;
using UnityEngine;


public class LeanTweenColor : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> _spritList = new List<SpriteRenderer>();
    [SerializeField] private float _delay;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _endColor;

    private void Start()
    {
        foreach (SpriteRenderer sprite in _spritList)
        {
            sprite.color = _startColor;
        }

        foreach (SpriteRenderer sprite in _spritList)
        {
            float randomDelay = Random.Range(0, _delay);
            LeanTween.color(sprite.gameObject, _endColor, randomDelay);
        }
    }
}
