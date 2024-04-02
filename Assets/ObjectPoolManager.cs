using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance;
    private List<Pool> _objectPools = new();
    private List<GameObject> _poolParent = new();

    //Singleton
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
        //Find the corresponding pool object with the same name as the object to Spawn
        Pool pool = _objectPools.Find(p => p._poolName == objToSpawn.name);

        //If there is no matching pool create a new one
        if (pool == null)
        {
            pool = new Pool() { _poolName = objToSpawn.name };
            _objectPools.Add(pool);
            GameObject newPoolParent = new(objToSpawn.name);
            newPoolParent.transform.parent = transform;
            _poolParent.Add(newPoolParent);
        }

        GameObject spawnableObj = null;
        //return the first inactive object from the pool inactive object list
        foreach (GameObject obj in pool._inactiveObjects)
        {
            if (_objectPools != null)
            {
                spawnableObj = obj;
                break;
            }
        }

        //if there is no inactive object available create a new object otherwise use the one that was found as an object to "Spawn"
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
    {   //format the objectName to get ride of the (Clone) (7 characters)
        string goName = obj.name.Substring(0, obj.name.Length - 7);
        //Add back the object to  inactive object list of the corresponding pool
        Pool pool = _objectPools.Find(p => p._poolName == goName);

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

public class Pool
{
    public string _poolName;
    public List<GameObject> _inactiveObjects = new();
}
