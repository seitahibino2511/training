using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectStage :MonoBehaviour
{
    [SerializeField] string _Sname;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => StageManager.Instance.ChangeStage(_Sname));
    }

}
