using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugScript : MonoBehaviour
{
    bool _bMode = false;
    RectTransform _rt;
    // Start is called before the first frame update
    void Start()
    {
        _rt = GetComponent<RectTransform>();
        Button button = GetComponent<Button>();
        
        button.onClick.AddListener(ChangeMode);
    }


    void ChangeMode()
    {
        
        _bMode = !_bMode;
        if (_bMode) _rt.localPosition = new Vector3(500, 450, 0);
        else _rt.localPosition = new Vector3(915, 450, 0);
    }
    
}
