using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class SaveLoadScript : MonoBehaviour
{
    GameObject Stage1;

    public string fileName = "StageSaved";

    private string extension = ".xml";

    public string FullSavePath
    {
        get
        {
           return Application.persistentDataPath + "/" + fileName + extension;
        }
    }

    void Awake()
    {
        Stage1 = GameObject.Find("Stage1");
    }

    public void Save()
    {
        StageData data = new StageData();
        data.stageLimit = Stage1.GetComponent<SelectSceneScipt>().stageLimit;

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(StageData));

        FileStream fs = new FileStream(FullSavePath, FileMode.OpenOrCreate);

        xmlSerializer.Serialize(fs, data);

        Debug.Log("File saved to " + FullSavePath);

        fs.Close();
    }

    public void Load()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(StageData));

        FileStream readStream = new FileStream(FullSavePath, FileMode.Open);

        StageData loadedData = xmlSerializer.Deserialize(readStream) as StageData;

        Stage1.GetComponent<SelectSceneScipt>().stageLimit = loadedData.stageLimit;

        Debug.Log("File loaded " + FullSavePath);

        readStream.Close();
    }

    [Serializable]
    public class StageData
    {
        public int stageLimit;
    }
}
