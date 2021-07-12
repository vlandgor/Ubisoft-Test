using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

public static class SaveSystem
{
    private static string path_in_file = "/data.dat";

    public static void SaveScene(List<Planet> planets)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + path_in_file;
        FileStream stream = new FileStream(path, FileMode.Create);

        SceneData data = new SceneData(CreateSceneData(planets));
        string json = JsonUtility.ToJson(data);

        formatter.Serialize(stream, json);
        Debug.Log("Saved to" + Application.persistentDataPath + path_in_file);
        stream.Close();
    }

    public static SceneData LoadScene()
    {
        string path = Application.persistentDataPath + path_in_file;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            string data = formatter.Deserialize(stream) as string;
            SceneData myObject = JsonUtility.FromJson<SceneData>(data);
            stream.Close();

            return myObject;
        }
        else
        {
            Debug.LogError("Load error");
            return null;
        }
    }

    private static List<PlanetData> CreateSceneData(List<Planet> planets)
    {
        List<PlanetData> planetDatas = new List<PlanetData>();

        foreach (Planet planet in planets)
        {
            PlanetData planetData = new PlanetData(planet);
            planetDatas.Add(planetData);
        }

        return (planetDatas);
    }
}
