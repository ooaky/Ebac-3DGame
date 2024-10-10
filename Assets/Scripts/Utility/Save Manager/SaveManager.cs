using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Core.Singleton;
using System;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField]
    private SaveSetup _saveSetup;
 
    //private string _path = Application.dataPath + "/save.txt"; // a / eh importante para garantir que salva dentro da pasta de assets
                                                               //salva dentro dos assets do projeto

    //string path = Application.persistentDataPath + "/save.txt";
    //guarda dentro de arquivos do servidor do computador -- dentro do usuario

    private string _path = Application.streamingAssetsPath + "/save.txt";
    //guarda na pasta de streming assets dentro do projeto -- precisa ser criada manualmente

    public int lastLevel;
    public int lastCheckpoint;
    public float savedLife;

    public Action<SaveSetup> FileLoaded;

    public SaveSetup Setup
    {
        get { return _saveSetup; }
    }


    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject); //nao eh destruido quando a cena eh carregada/trocada
    }

    private void CreateNewSave()
    {
        _saveSetup = new SaveSetup();

        _saveSetup.lastLevel = 0;
        _saveSetup.playerName = "Joras";
        _saveSetup.lastCheckpoint = 0;
    }

    private void Start()
    {
        Invoke(nameof(Load), .1f);
    }

    #region SAVE

    [NaughtyAttributes.Button]
    private void Save()
    {

        string setupToJson = JsonUtility.ToJson(_saveSetup, true); //biblioteca da unity que transforma a classe em um arquivo json
        Debug.Log(setupToJson);

        SaveFile(setupToJson);
    }

    public void SaveLastLevel(int level)
    {
        _saveSetup.lastLevel = level;
        SaveCollectables();
        Save();
    }

    public void SaveName(string name)
    {
        _saveSetup.playerName = name;
        Save();
    }

    public void SaveLastCheckpoint(int checkpoint)
    {
        _saveSetup.lastCheckpoint = checkpoint;
        SaveCollectables();
        Save();
    }

    public void SaveCollectables()
    {
        _saveSetup.coins = Collectables.ItemManager.Instance.GetItemByType(Collectables.ItemType.COIN).soInt.value;
        _saveSetup.lifePacks = Collectables.ItemManager.Instance.GetItemByType(Collectables.ItemType.LIFE_PACK).soInt.value;
        _saveSetup.objective = Collectables.ItemManager.Instance.GetItemByType(Collectables.ItemType.OBJECTIVE).soInt.value;
        Save();
    }

    #endregion

    private void SaveFile(string json)
    {
        Debug.Log(_path);
        File.WriteAllText(_path, json);
    }

    [NaughtyAttributes.Button]
    private void Load()
    {
        string fileLoaded = "";

        if (File.Exists(_path))
        {
            fileLoaded = File.ReadAllText(_path);
            //le primeiro para garantir que nao tem nada salvo anteriormente

            _saveSetup = JsonUtility.FromJson<SaveSetup>(fileLoaded);

            lastLevel = _saveSetup.lastLevel;
            lastCheckpoint = _saveSetup.lastCheckpoint;
        }
        else
        {
            CreateNewSave();
            Save();
        }


        FileLoaded?.Invoke(_saveSetup); 

    }

    #region DEBUG

    [NaughtyAttributes.Button]
    private void SaveLevelOne()
    {
        SaveLastLevel(1);
    }    

    [NaughtyAttributes.Button]
    private void SaveLevelFive()
    {
        SaveLastLevel(5);
    }

    #endregion

}



[System.Serializable]
public class SaveSetup
{
    public int lastLevel;
    public int lastCheckpoint;
    public string playerName;
    public int coins;
    public int lifePacks;
    public int objective;

}
