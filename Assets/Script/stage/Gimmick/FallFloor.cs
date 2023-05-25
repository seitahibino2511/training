using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallFloor : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 _firstPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _firstPos = rb.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") rb.velocity = new Vector3(0,-5,0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "OutLine")
        {
            rb.velocity = Vector3.zero;
            rb.position = _firstPos;
        }

    }

    //IEnumerator fall(float time)
    //{
    //    yield return 
    //}

}
