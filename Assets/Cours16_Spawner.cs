using UnityEngine;

public class Cours16_Spawner : MonoBehaviour
{

    [SerializeField] private GameObject _objectToSpawn;
    [SerializeField] private GameObject _cubeToSpawn;
    [SerializeField] private float _objSpeed = 5f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newObj = ObjectPoolManager.Instance.SpawnObject(_objectToSpawn, transform.position, Quaternion.identity);
            newObj.GetComponent<Rigidbody>().velocity = Vector3.one * _objSpeed;
        }

        if (Input.GetMouseButtonDown(1))
        {
            GameObject newObj = ObjectPoolManager.Instance.SpawnObject(_cubeToSpawn, transform.position, Quaternion.identity);
            newObj.GetComponent<Rigidbody>().velocity = new Vector3(-1, 1, 1) * _objSpeed;
        }

    }
}
