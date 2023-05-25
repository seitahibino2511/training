using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugDeath : MonoBehaviour
{
    [SerializeField] PlayerMove _Player;
    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(_Player.GameOver);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
