using UnityEngine;
using TMPro;

public class RessourcesManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _foodTXT;
    [SerializeField] private TextMeshProUGUI _oreTXT;
    [SerializeField] private TextMeshProUGUI _woodTXT;
    [SerializeField] private int _foodCount = 100;
    [SerializeField] private int _woodCount = 0;
    [SerializeField] private int _oreCount = 0;

    private void Start()
    {
        UpdateAllTextField();
    }

    public void SpendDayOfWork()
    {
        foreach (Transform child in transform)
        {
            Worker worker = child.GetComponent<Worker>();
            worker.Work();
        }

        UpdateAllTextField();
        // Appeler la fonction Work() pour chaque worker 
        // Mettre à jour tout les champs texte
    }

    public void AddWood(int woodToAdd)
    {
        _woodCount += woodToAdd;
    }

    public void AddOre(int oreToAdd)
    {
        _oreCount += oreToAdd;
    }

    public void AddFood(int foodToAdd)
    {
        _foodCount += foodToAdd;
    }

    private void UpdateAllTextField()
    {
        _foodTXT.text = _foodCount.ToString();
        _oreTXT.text = _oreCount.ToString();
        _woodTXT.text = _woodCount.ToString();

        // Updater les champs texte.
    }
}
