using System.Collections;
using UnityEngine;

public class Cours16_Bullet : MonoBehaviour
{
    [SerializeField] private float _selfDestroyDelay = 5f;


    private void OnEnable()
    {
        StartCoroutine(SelfDestroyAfterDelay());
    }

    private IEnumerator SelfDestroyAfterDelay()
    {
        yield return new WaitForSeconds(_selfDestroyDelay);
        ObjectPoolManager.Instance.ReturnObjectPool(gameObject);
    }

}
