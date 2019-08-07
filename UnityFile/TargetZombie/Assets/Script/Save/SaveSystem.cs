using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public static class SaveSystem
{
    public static List<PlayerData> player = new List<PlayerData>();

    public static void SaveScore(PlayerData Objects,List<PlayerData>playScore)
    {
         BinaryFormatter formatter = new BinaryFormatter();
         string path = Application.persistentDataPath + "/player.fun";
            playScore.Add(Objects);
            FileStream stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, playScore);
            stream.Close();
    }
        

    public static List<PlayerData> LoadScore()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            player = (List<PlayerData>)formatter.Deserialize(stream);
            stream.Close();

            return player;
        }
        else
        {
            return null;
        }
    }
}
