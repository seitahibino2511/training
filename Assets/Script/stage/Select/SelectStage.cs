using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectStage :MonoBehaviour
{
    [SerializeField] string _Sname;
    Button _button;
    [SerializeField] GameObject _Panel;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Inv);
    }

    public void Change()
    {
        StageManager.Instance.ChangeStage(_Sname);
    }

    public void Inv()
    {
        _Panel.SetActive(true);
    }
}
