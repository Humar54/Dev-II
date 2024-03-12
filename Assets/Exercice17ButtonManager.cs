
using TMPro;
using UnityEngine;

public class Exercice17ButtonManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void ShowName(Animal animal)
    {
        IShowName showName = animal.GetComponent<IShowName>();
        _text.text = showName.GetName();
    }

    public void Worker(Animal animal)
    {
        IWorker worker = animal.GetComponent<IWorker>();
        if (worker != null)
        {
            worker.Work();
        }
        else
        {
            Debug.Log($"{animal.name} dont work...");
        }
    }
}
