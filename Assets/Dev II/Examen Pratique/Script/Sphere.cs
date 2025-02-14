
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private float _maxDistance = 12f;
    void Update()//4pts
    {
        // si la sphère est en dessous de -5 en y par rapport , incrémenter le score du ControlManager en appelant la fonction AddScore à partir du singleton puis détruire la sphère.
        if ((transform.position-Vector3.zero).magnitude> _maxDistance)
        {
            ControlManager._instance.AddOneToScore();
            Destroy(gameObject);
        }
    }
}
