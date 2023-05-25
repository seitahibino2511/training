using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StatusManager
{
    private static StatusManager _instance;
    List<string[]> csvDatas = new List<string[]>();
    public static StatusManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new StatusManager();
                _instance.LoadData();
            }

            return _instance;
        }
    }

    void LoadData()
    {
        TextAsset data = Resources.Load<TextAsset>("traning_Unity");

        StringReader reader = new StringReader(data.text);
        while(reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(","));
        }
    }

    public float GetSpeed(int id)
    {
        return float.Parse(csvDatas[id][2]);
    }

    public float GetJamp(int id)
    {
        return float.Parse(csvDatas[id][3]);
    }

}
