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
        _saveloadJSON.LoadFromJson(Application.persistentDataPath + $"/{_name.text}.json");
    }

    public void Delete()
    {
        _saveloadJSON.DeleteSaveFile(_name.text);
        Destroy(gameObject);
    }
}






