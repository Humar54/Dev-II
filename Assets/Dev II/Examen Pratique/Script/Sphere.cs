
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private float _maxDistance = 12f;
    void Update()
    {
        if((transform.position-Vector3.zero).magnitude> _maxDistance)
        {
            ControlManager._instance.AddOneToScore();
            Destroy(gameObject);
        }
    }
}
