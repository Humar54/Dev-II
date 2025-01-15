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
    public List<Enemy5> _enemyList;
}




[Serializable]
public class Ress
{
    public string _name;
    public int _value;
}
public class SaveLoadJSON : MonoBehaviour
{

    [SerializeField] private PlayerData _currentData = new();
    [SerializeField] string _saveFilePath;
    [SerializeField] TMP_InputField _inputField;
    [SerializeField] SaveSlot _saveSlotPrefab;
    [SerializeField] Transform _verticalLayout;

    void Start()
    {
        CreateAllSavedSlot();
        //_currentData = new();
    }


    public void CreateNewSave()
    {
        _currentData._time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _currentData._name = _inputField.text;
        CreateSaveSlot(_currentData._name, _currentData._time);
        SaveCurrentPlayerData();
    }
    /*
    private void CreateNewPlayerData(string name)
    {
        _currentData._name = name;
        SaveSlot newSaveSlot = Instantiate(_saveSlotPrefab);
        newSaveSlot.UpdateSaveSlot(name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), this);
        newSaveSlot.transform.SetParent(_verticalLayout);
        newSaveSlot.transform.SetSiblingIndex(_verticalLayout.childCount - 2);


        Debug.Log("Add Has Been Called");
        SaveGame(out date);
        _currentData = new PlayerData();
    }
    */
    /*
    private void LoadPlayerData(PlayerData playerData)
    {
        _currentData = playerData;
        _currentData._name = playerData._name;

        _currentData._gold = playerData._gold;
        _currentData._position = playerData._position;
        _currentData._ressourceList = playerData._ressourceList;



    }
    */
    public void CreateSaveSlot(string name, string time)
    {
        SaveSlot newSaveSlot = Instantiate(_saveSlotPrefab);
        newSaveSlot.UpdateSaveSlot(name, time, this);
        newSaveSlot.transform.SetParent(_verticalLayout);
        newSaveSlot.transform.SetSiblingIndex(_verticalLayout.childCount - 2);
    }
    /*
    private void UpdateSavePath(string fileName)
    {
        Debug.Log(Application.persistentDataPath + $"/{fileName}.json");
        _saveFilePath = Application.persistentDataPath + $"/{fileName}.json";
    }
    */
    public void SaveCurrentPlayerData()
    {

        string savePlayerData = JsonUtility.ToJson(_currentData);
        File.WriteAllText(Application.persistentDataPath + $"/{_currentData._name}.json", savePlayerData);
        Debug.Log("Save file created at: " + _saveFilePath);
    }


    public void CreateAllSavedSlot()
    {
        if (Directory.Exists(Application.persistentDataPath))
        {
            string worldsFolder = Application.persistentDataPath;

            DirectoryInfo d = new(worldsFolder);

            foreach (var file in d.GetFiles("*.json"))
            {

                PlayerData data = LoadFromJson(Application.persistentDataPath + "/" + file.Name);
                CreateSaveSlot(data._name, data._time);
            }
        }
    }



    public PlayerData LoadFromJson(string adress)
    {

        if (File.Exists(adress))
        {

            string playerData = File.ReadAllText(adress);
            _currentData = JsonUtility.FromJson<PlayerData>(playerData);
            return _currentData;

            //Debug.Log("Load game complete! \nPlayer health: " + _currentData._name + ", Player gold: " + _currentData._gold + ", Player Position: (x = " + _currentData._position.x + ", y = " + _currentData._position.y + ", z = " + _currentData._position.z + ")");
        }
        else
        {
            Debug.Log("There is no save files to load!");
            return null;
        }
    }

    public void DeleteSaveFile(string name)
    {

        if (File.Exists(Application.persistentDataPath + $"/{name}.json"))
        {
            File.Delete(Application.persistentDataPath + $"/{name}.json");
        }
        else
        {
            Debug.Log("There is no file to delete with this name");
        }
    }
}
