using UnityEngine;

public class Fruits : MonoBehaviour
{
    public float _vitamineCContent;

    // Faire une fonction être mangé qui retourne le contenue en vitamine C du fruit

    // Faire une fonction Taste Sweet qui affiche ("Yummy!") dans la console

    // Faire une fonction Taste Bitter qui affiche (Yuck! dans la console


    public virtual float GetEaten()
    {
        return _vitamineCContent;
    }

    public void TasteSweet()
    {
        Debug.Log("Hum Yum!");
    }

    public void TasteBitter()
    {
        Debug.Log("Yuck!");
    }

}
