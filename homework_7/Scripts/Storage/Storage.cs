using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class Storage
{
    private string _filepath;
    private BinaryFormatter _formatter;

    public Storage()
    {
        var directory = Application.persistentDataPath + "/saves";
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        _filepath = directory + "/Gamesave.save";
        InitBinaryFormatter();
    }

    private void InitBinaryFormatter()
    {
        _formatter = new BinaryFormatter();
        var selector = new SurrogateSelector();

        var vector3Surrogate = new Vector3SerializationSurrogate();

        selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), vector3Surrogate);
        _formatter.SurrogateSelector = selector;
    }

    public object Load(object saveDataByDefault)
    {
        if (!File.Exists(_filepath))
        {
            if( saveDataByDefault != null)
            {
                Save(saveDataByDefault);
            }
            return saveDataByDefault;
        }

        var file = File.Open(_filepath, FileMode.Open);
        var savedData = _formatter.Deserialize(file);
        file.Close();
        return savedData;
    }

    public void Save(object saveData)
    {
        var file = File.Create(_filepath);

        _formatter.Serialize(file, saveData);
    }
}
