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

    [Serializable]
    public class StageData
    {
        public int stageLimit;
    }
}
