using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform _Player;
    Vector3 _offset;
    [SerializeField] float _fCameraSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - _Player.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _Player.transform.position + _offset, _fCameraSpeed * Time.deltaTime);
    }
}
