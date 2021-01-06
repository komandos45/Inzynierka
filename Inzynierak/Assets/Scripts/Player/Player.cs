using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int xp = 0;
    [SerializeField] private int requiredXp = 100;
    [SerializeField] private int levelBase = 100;
    private int lvl = 1;
    private string path;

        public int Xp
    {
        get { return xp; }
    }
        public int RequiredXp
    {
        get { return requiredXp; }
    }
        public int LevelBase
    {
        get { return levelBase; }
    } 


    public int Lvl
    {
        get { return lvl; }
    }


    private void Start()
    {
        path = Application.persistentDataPath + "/pl.dat";
        InitLevelData();
        Load();
    }
    public void AddXp(int xp)
        {
        this.xp += Mathf.Max(0, xp);
        InitLevelData();
        Save();
        }



        private void InitLevelData()
        {
            if (xp >= requiredXp)
            {
                lvl += 1;
                requiredXp = levelBase * lvl;
                xp = 0;
            }
            


        }
    private void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);
        PlayerData data = new PlayerData(this);
        bf.Serialize(file, data);
        file.Close();

    }

    private void Load()
    {
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            PlayerData data = (PlayerData) bf.Deserialize(file);
            file.Close();

            xp = data.Xp;
            requiredXp = data.RequiredXp;
            levelBase = data.LevelBase;
            lvl = data.Lvl;



        }
        else
        {
            InitLevelData();
        }



    }


}
