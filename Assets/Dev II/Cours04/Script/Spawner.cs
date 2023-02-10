using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_prefab, transform.position, Quaternion.identity);
            GameManager.instance.AddCounter();
        }
    }
}
