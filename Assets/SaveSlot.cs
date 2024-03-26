using TMPro;
using UnityEngine;

public class SaveSlot : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _date;

    private SaveLoadJSON _saveloadJSON;

    public void UpdateSaveSlot(string name, string date, SaveLoadJSON saveJson)
    {
        _name.text = name;
        _date.text = date;
        _saveloadJSON = saveJson;

    }

    public void Load()
    {
        _saveloadJSON.LoadDataJsonGame(_name.text);
    }

    public void Save()
    {
        string date;
        _saveloadJSON.SaveGame(out date);
        _date.text = date;
    }
    public void Delete()
    {
        _saveloadJSON.DeleteSaveFile(_name.text);
        Destroy(gameObject);
    }
}






