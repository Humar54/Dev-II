using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public string _name;
    public string _time;
    public int _gold;
    public Vector3 _position;
    public List<Ress> _ressourceList;
}

[Serializable]
public class AllData
{
    public List<PlayerData> _allSaves = new();
}


[Serializable]
public class Ress
{
    public string _name;
    public int _value;
}
public class SaveLoadJSON : MonoBehaviour
{
    [SerializeField] private AllData _allData = new();
    [SerializeField] private PlayerData _playerData = new();
    [SerializeField] string _saveFilePath;
    [SerializeField] TMP_InputField _inputField;
    [SerializeField] SaveSlot _saveSlotPrefab;
    [SerializeField] Transform _verticalLayout;

    void Start()
    {
        _allData._allSaves.Clear();
        LoadFromJsonGame();
        foreach (PlayerData datum in _allData._allSaves)
        {
            LoadPlayerData(datum);
        }
    }


    public void CreateNewSave()
    {
        CreateNewPlayerData(_inputField.text); ;
    }
    private void CreateNewPlayerData(string name)
    {
        _playerData._name = name;
        SaveSlot newSaveSlot = Instantiate(_saveSlotPrefab);
        newSaveSlot.UpdateSaveSlot(name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), this);
        newSaveSlot.transform.SetParent(_verticalLayout);
        newSaveSlot.transform.SetSiblingIndex(_verticalLayout.childCount - 2);
        string date;
        _allData._allSaves.Add(_playerData);
        Debug.Log("Add Has Been Called");
        SaveGame(out date);
        _playerData = new PlayerData();
    }

    private void LoadPlayerData(PlayerData playerData)
    {
        _playerData = playerData;
        _playerData._name = playerData._name;

        _playerData._gold = playerData._gold;
        _playerData._position = playerData._position;
        _playerData._ressourceList = playerData._ressourceList;


        SaveSlot newSaveSlot = Instantiate(_saveSlotPrefab);
        newSaveSlot.UpdateSaveSlot(_playerData._name, _playerData._time, this);
        newSaveSlot.transform.SetParent(_verticalLayout);
        newSaveSlot.transform.SetSiblingIndex(_verticalLayout.childCount - 2);
    }

    private void UpdateSavePath()
    {
        _saveFilePath = Application.persistentDataPath + "/AllData.json";
    }

    public void SaveGame(out string date)
    {
        UpdateSavePath();
        _playerData._time = DateTime.Now.ToString(("yyyy-MM-dd HH:mm:ss"));

        date = _playerData._time;
        string savePlayerData = JsonUtility.ToJson(_allData);
        File.WriteAllText(_saveFilePath, savePlayerData);
        Debug.Log("Save file created at: " + _saveFilePath);
    }


    public void LoadDataJsonGame(string name)
    {
        _playerData = _allData._allSaves.Find(x => x._name == name);
    }


    public void LoadFromJsonGame()
    {
        UpdateSavePath();
        if (File.Exists(_saveFilePath))
        {
            string loadAllPlayerData = File.ReadAllText(_saveFilePath);
            _allData = JsonUtility.FromJson<AllData>(loadAllPlayerData);
            Debug.Log("Load game complete! \nPlayer health: " + _playerData._name + ", Player gold: " + _playerData._gold + ", Player Position: (x = " + _playerData._position.x + ", y = " + _playerData._position.y + ", z = " + _playerData._position.z + ")");
        }
        else
        {
            Debug.Log("There is no save files to load!");
        }
    }

    public void DeleteSaveFile(string name)
    {
        UpdateSavePath();
        _allData._allSaves.Remove(_allData._allSaves.Find(x => x._name == name));
        string date;
        SaveGame(out date);
    }
}
