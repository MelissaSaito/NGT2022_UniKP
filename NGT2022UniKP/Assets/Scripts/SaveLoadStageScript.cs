using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class SaveLoadStageScript : MonoBehaviour
{
    GameObject Camera;

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
        Camera = GameObject.Find("Main Camera");
    }

    public void Save(int stage)
    {
        StageData data = new StageData();

        data.stageLimit = stage;

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(StageData));

        FileStream fs = new FileStream(FullSavePath, FileMode.OpenOrCreate);

        xmlSerializer.Serialize(fs, data);

        Debug.Log("File saved to " + FullSavePath);

        fs.Close();
    }

    //public void Load()
    //{
    //    if (File.Exists(FullSavePath))
    //    {
    //        XmlSerializer xmlSerializer = new XmlSerializer(typeof(StageData));

    //        FileStream readStream = new FileStream(FullSavePath, FileMode.Open);

    //        StageData loadedData = xmlSerializer.Deserialize(readStream) as StageData;

    //        Camera.GetComponent<SelectSceneScipt>().stageLimit = loadedData.stageLimit;

    //        Debug.Log("File loaded " + FullSavePath);

    //        readStream.Close();
    //    }
        

    //}

    [Serializable]
    public class StageData
    {
        public int stageLimit;
    }
}
