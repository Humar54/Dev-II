
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private float _maxDistance = 12f;
    void Update()//4pts
    {

        // si la distance de la sphère par rapport au centre du tableau "position (0,0,0)" est plus grande que la Distance maximale, incrémenter le score du ControlManager en appelant la fonction AddScore à partir du singleton puis détruire la sphère.
        if ((transform.position-Vector3.zero).magnitude> _maxDistance)
        {
            ControlManager._instance.AddOneToScore();
            Destroy(gameObject);
        }
    }
}
