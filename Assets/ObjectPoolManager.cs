using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance;
    private List<PooledObjectInfo> _objectPools = new();
    private List<GameObject> _poolParent = new();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    public GameObject SpawnObject(GameObject objToSpawn, Vector3 spawnPos, Quaternion spawnRotation)
    {
        PooledObjectInfo pool = _objectPools.Find(p => p._poolName == objToSpawn.name);


        if (pool == null)
        {
            pool = new PooledObjectInfo() { _poolName = objToSpawn.name };
            _objectPools.Add(pool);
            GameObject newPoolParent = new(objToSpawn.name);
            newPoolParent.transform.parent = transform;
            _poolParent.Add(newPoolParent);
        }

        GameObject spawnableObj = null;
        foreach (GameObject obj in pool._inactiveObjects)
        {
            if (_objectPools != null)
            {
                spawnableObj = obj;
                break;
            }
        }

        if (spawnableObj == null)
        {
            spawnableObj = Instantiate(objToSpawn, spawnPos, spawnRotation);
            spawnableObj.transform.parent = _poolParent.Find(p => p.name == objToSpawn.name).transform;
        }
        else
        {
            spawnableObj.transform.position = spawnPos;
            spawnableObj.transform.rotation = spawnRotation;
            pool._inactiveObjects.Remove(spawnableObj);
            spawnableObj.SetActive(true);
        }
        return spawnableObj;

    }

    public void ReturnObjectPool(GameObject obj)
    {
        string goName = obj.name.Substring(0, obj.name.Length - 7);
        PooledObjectInfo pool = _objectPools.Find(p => p._poolName == goName);

        if (pool == null)
        {
            Debug.LogWarning("Trying to release an object that is not pooler" + obj.name);
        }
        else
        {
            obj.SetActive(false);
            pool._inactiveObjects.Add(obj);
        }
    }

}

public class PooledObjectInfo
{
    public string _poolName;
    public List<GameObject> _inactiveObjects = new();
}
