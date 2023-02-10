using UnityEngine;

public class Normalization : MonoBehaviour
{
    [SerializeField] private Transform _ptA;
    [SerializeField] private Transform _ptB;
    [SerializeField] private Rigidbody _sphereRB;

    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _seldDestroyRange = 0.5f;

    private void Start()
    {
        _sphereRB.transform.position = _ptA.transform.position;
        Vector3 direction = (_ptB.position - _ptA.position).normalized;
        _sphereRB.velocity = direction * _speed;
        Debug.Log(_sphereRB.velocity.magnitude + "[m/s]");
    }

    private void Update()
    {
        if (!_sphereRB) { return; }
        if((_sphereRB.transform.position-_ptB.transform.position).magnitude< _seldDestroyRange)
        {
            Destroy(_sphereRB.gameObject);
        }
    }
}
