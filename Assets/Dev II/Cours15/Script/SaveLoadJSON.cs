using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

//
// Classe contenant toutes les données du joueur à sauvegarder.
// Elle doit être [Serializable] pour pouvoir être convertie en JSON.
//
[Serializable]
public class PlayerData
{
    public string _name;                 // Nom du joueur
    public string _time;                 // Date/heure de la sauvegarde
    public int _gold;                    // Exemple : quantité d’or
    public Vector3 _position;            // Position du joueur dans la scène
    public List<Ress> _ressourceList;    // Liste de ressources possédées
    public List<Enemy5> _enemyList;      // Liste d’ennemis (exemple)
}

//
// Petite classe représentant une ressource (nom + valeur).
//
[Serializable]
public class Ress
{
    public string _name;
    public int _value;
}

public class SaveLoadJSON : MonoBehaviour
{
    // Données du joueur actuellement en mémoire
    [SerializeField] private PlayerData _currentData = new();
    [SerializeField] string _saveFilePath;
    [SerializeField] TMP_InputField _inputField;
    [SerializeField] SaveSlot _saveSlotPrefab;
    [SerializeField] Transform _verticalLayout;

    void Start()
    {
        // Au lancement, on crée un slot pour chaque fichier JSON déjà existant
        CreateAllSavedSlot();
    }

    //
    // Crée une nouvelle sauvegarde à partir des données actuelles
    //
    public void CreateNewSave()
    {
        // On enregistre la date actuelle
        _currentData._time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        // Le nom de la sauvegarde vient du champ texte
        _currentData._name = _inputField.text;

        // On crée un nouveau slot visuel dans l’UI
        CreateSaveSlot(_currentData._name, _currentData._time);

        // On écrit les données dans un fichier JSON
        SaveCurrentPlayerData();
    }

    //
    // Instancie un slot de sauvegarde dans l’UI
    //
    public void CreateSaveSlot(string name, string time)
    {
        List<SaveSlot> allSavedSlot = _verticalLayout.GetComponentsInChildren<SaveSlot>().ToList();

        SaveSlot existingSlot = allSavedSlot.FirstOrDefault(slot => slot.GetName() == name);


        if (existingSlot==null)
        {
             existingSlot = Instantiate(_saveSlotPrefab);
        }


        // On met à jour le texte du slot (nom + date)
        existingSlot.UpdateSaveSlot(name, time, this);

        // On place le slot dans le layout vertical
        existingSlot.transform.SetParent(_verticalLayout);

        // On le place juste avant le dernier élément 
        existingSlot.transform.SetSiblingIndex(_verticalLayout.childCount - 2);
    }

    //
    // Convertit les données du joueur en JSON et les écrit dans un fichier
    //
    public void SaveCurrentPlayerData()
    {
        // Conversion en JSON
        string savePlayerData = JsonUtility.ToJson(_currentData);

        // Écriture dans un fichier portant le nom du joueur
        File.WriteAllText(Application.persistentDataPath + $"/{_currentData._name}.json", savePlayerData);

        Debug.Log("Save file created at: " + _saveFilePath);
    }

    //
    // Crée un slot UI pour chaque fichier JSON trouvé dans le dossier de sauvegarde
    //
    public void CreateAllSavedSlot()
    {
        if (Directory.Exists(Application.persistentDataPath))
        {
            string worldsFolder = Application.persistentDataPath;
            DirectoryInfo d = new(worldsFolder);

            // On parcourt tous les fichiers .json
            foreach (var file in d.GetFiles("*.json"))
            {
                // On charge les données du fichier
                PlayerData data = LoadFromJson(Application.persistentDataPath + "/" + file.Name);

                // On crée un slot UI correspondant
                CreateSaveSlot(data._name, data._time);
            }
        }
    }

    //
    // Charge un fichier JSON et retourne un PlayerData
    //
    public PlayerData LoadFromJson(string adress)
    {
        if (File.Exists(adress))
        {
            // Lecture du fichier JSON
            string playerData = File.ReadAllText(adress);

            // Conversion JSON ? PlayerData
            _currentData = JsonUtility.FromJson<PlayerData>(playerData);

            return _currentData;
        }
        else
        {
            Debug.Log("There is no save files to load!");
            return null;
        }
    }

    //
    // Supprime un fichier de sauvegarde
    //
    public void DeleteSaveFile(string name)
    {
        string path = Application.persistentDataPath + $"/{name}.json";

        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            Debug.Log("There is no file to delete with this name");
        }
    }
}
