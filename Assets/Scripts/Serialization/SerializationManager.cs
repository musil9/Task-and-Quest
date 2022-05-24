using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class SerializationManager : MonoBehaviour
{
    public static bool Save(string saveName, object saveData)
    {
        BinaryFormatter formatter = GetBinaryFormatter();

        if(!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }

        string path = Application.persistentDataPath + "/saves" + saveName + ".save";

        FileStream file = File.Create(path);

        formatter.Serialize(file, saveData);

        file.Close();

        return true;

    }

    public static object Load(string path)
    {
        if(!File.Exists(path))
        {
            return null;
        }

        BinaryFormatter formatter = GetBinaryFormatter();

        FileStream file = File.Open(path, FileMode.Open);

        try
        {
            object save = formatter.Deserialize(file);
            file.Close();
            return save;
        }
        catch 
        {

            Debug.LogErrorFormat("저장 실패 {0}", path);
            file.Close();
            return null;
        }
    }
    
    public static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        return formatter;
    }

    public void Work()
    {
        SaveData.current.profile.currency += 100;
        SaveData.current.profile.experience += 1;
        UpdateInfo();
    }

    public void BuyA()
    {
        if(SaveData.current.profile.currency >= 200)
        {
            SaveData.current.profile.currency -= 200;
            SaveData.current.A += 1;
            UpdateInfo();
        }
    }

    public void BuyB()
    {
        if (SaveData.current.profile.currency >= 350)
        {
            SaveData.current.profile.currency -= 350;
            SaveData.current.B += 1;
            UpdateInfo();
        }
    }

    public void OnLoadGame()
    {
        SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/Save.save");
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        //업데이트 UI or event
    }
}
