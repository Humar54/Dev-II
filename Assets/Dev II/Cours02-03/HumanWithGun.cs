
using UnityEngine;

public class HumanWithGun : MonoBehaviour
{
    // Référence à un Gun. 
    // IMPORTANT :Même si on met un ShotGun ou un Sniper dans l’inspecteur,
    // la variable est de type "Gun". C’est du POLYMORPHISME.
    // l'humain n’a pas besoin de connaître le type exact de l’arme pour pouvoir l'utiliser.

    [SerializeField] private Gun _equipedGun;
    
  
    void Update()
    {
        // On appelle Shoot() sur un Gun...n'importe quel type de Gun! BOOM!
        if (Input.GetMouseButtonDown(0))
        {
            _equipedGun.Shoot();
        }

        // Même chose on appel reload sur n'importe quel type de Gun.
        if(Input.GetKeyDown(KeyCode.R))
        {
            _equipedGun.Reaload();
        }
    }
}
