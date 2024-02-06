using UnityEngine;

public class Orange : Fruits
{
    [SerializeField] private bool _hasPeel;

    //Faire une fonction SquirtJuice propre a l'orange qui affiche "what a mess" dans la console"

    //Faire une fonction être mangé propre a l'orange
        // Appeler SquirtJuice
        // Si l'orange possède une pelure, appeler TasteBitter de fruit si non appeler TasteSweet de fruit
        // Appeler le GetEaten de la classe fruit de base pour retourner la valeur en vitamine C




    public override float GetEaten()
    {
        SquirtJuice();
        if (_hasPeel)
        {
            TasteBitter();
        }
        else
        {
            TasteSweet();
        }
        return base.GetEaten();
    }

    public void SquirtJuice()
    {
        Debug.Log("What a mess!");
    }
}
