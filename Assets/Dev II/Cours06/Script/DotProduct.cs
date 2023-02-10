
using UnityEngine;

public class DotProduct : MonoBehaviour
{

    [SerializeField] private Transform _sphere;

    private MeshRenderer _sphereRenderer;

    private void Start()
    {
        _sphereRenderer = _sphere.GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        Vector3 normalizedDirectionToSphere = (_sphere.position - transform.position).normalized;
        float dotProduct = Vector3.Dot(transform.forward, normalizedDirectionToSphere);
        Debug.Log(dotProduct);

        if(dotProduct>0)
        {
            _sphereRenderer.material.color = Color.green;
        }
        else
        {
            _sphereRenderer.material.color = Color.red;
        }
    }

}
