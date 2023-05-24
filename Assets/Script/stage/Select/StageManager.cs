using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager
{

    private static StageManager _instance;
    public static StageManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new StageManager();
            }

            return _instance;
        }
    }

    public void ChangeStage(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ChangeStageSelect()
    {
        SceneManager.LoadScene("StageSelect");
    }

}
