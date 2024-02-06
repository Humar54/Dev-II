using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] private List<Fruits> _fruitList;
    [SerializeField] private float _vitamineCContent;

    // Faire une fonction Eat a fruit  ou l'humain mange le premier fruit de la liste
    //{
        //Dans la console indiquer quel fruit a été mangé par l'humain
        //L'humain mange le fruit et ajoute  le contenue de vitamine C du fruit mangé à lui même
        //Enlever  le fruit à détruire de la liste
        //Détruire le fruit
    //}
    public void EatAFruit()
    {
        Debug.Log($"Human has eaten {_fruitList[0].name}");
        _vitamineCContent += _fruitList[0].GetEaten();
        Destroy(_fruitList[0].gameObject);
        _fruitList.RemoveAt(0);

        // ajouter le contenu ne vitamine C du premier fruit de la liste à celui de l'humain
        // Détruire le premier fruit de la liste
        // Enlever le fruit détruit de la liste
    }

}
