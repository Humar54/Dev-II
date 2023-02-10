
using System.Collections;
using UnityEngine;

public class ObjectSpawned : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _selfDestroyDelay;

    private Material _material;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-1f,1f), Random.Range(0f, 1f), 0f) * _speed;
        _material = GetComponent<MeshRenderer>().material;
        _material = _material;

        float randomHue = Random.Range(0f, 1f);
        float randomSaturation = Random.Range(0.5f, 1f);
        float randomValue = 1f;
        Color randomColor = Color.HSVToRGB(randomHue, randomSaturation, randomValue);
        _material.color = randomColor;
        StartCoroutine(DestroyGameObject());
    }

    private IEnumerator DestroyGameObject()
    {
        yield return new WaitForSeconds(_selfDestroyDelay);
        GameManager.instance.RemoveCounter();
        Destroy(gameObject);
    }
}
