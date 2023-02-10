using UnityEngine;

public class CameraFieldOfView : MonoBehaviour
{
    [SerializeField] private Transform _sphere;
    [SerializeField] private float _cameraFOVRatio = 0.5f;

    private MeshRenderer _sphereRenderer;

    private void Start()
    {
        _sphereRenderer = _sphere.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 _lookDirection = (_sphere.position - transform.position).normalized;
        float dotProduct = Vector3.Dot(transform.forward, _lookDirection);
        //Debug.Log(dotProduct);

        if (Physics.Raycast(transform.position, _lookDirection,out hit,Mathf.Infinity))
        {
            if (hit.collider.tag == "Sphere" && dotProduct > _cameraFOVRatio)
            {
                _sphereRenderer.material.color = Color.green;
            }
            else
            {
                _sphereRenderer.material.color = Color.red;
            }
        }
    }
}
