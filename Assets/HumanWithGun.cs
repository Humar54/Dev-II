
using UnityEngine;

public class HumanWithGun : MonoBehaviour
{
    [SerializeField] private Gun _equipedGun;
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _equipedGun.Shoot();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            _equipedGun.Reaload();
        }
    }
}
