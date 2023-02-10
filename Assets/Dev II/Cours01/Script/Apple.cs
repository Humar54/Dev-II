
using UnityEngine;

public class Apple : Fruits
{
    public override float GetEaten()
    {   
        //appel une fonction  de la classe parent qui est  propre à la pomme 
        TasteSweet();
        EmitCrunchNoise();
        //appel la fonction de base Get Eaten et retourne le contenu en vitamine C
        return base.GetEaten();
    }
    //Fonction propre à l'enfant
    public void EmitCrunchNoise()
    {
        Debug.Log("Crunch");
    }
}
