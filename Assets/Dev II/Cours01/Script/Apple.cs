
using UnityEngine;

public class Apple : Fruits
{
    //Faire une fonction EmitCrunchNoise propre a Apple qui affiche "Crunch"

    //Faire une fonction GetEaten qui est � la base propre aux Fruits mais avec le comportement unique de la pomme
        // Appeler EmitCrunchNoise 
        // Apperler Taste Sweet propre au fruits
        // Appeler le GetEaten propre au fruits pour retourner la valeur en vitamine C
    public override float GetEaten()
    {   
        //appel une fonction  de la classe parent qui est  propre � la pomme 
        TasteSweet();
        EmitCrunchNoise();
        //appel la fonction de base Get Eaten et retourne le contenu en vitamine C
        return base.GetEaten();
    }
    //Fonction propre � l'enfant
    public void EmitCrunchNoise()
    {
        Debug.Log("Crunch");
    }



}
