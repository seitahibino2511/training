using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Character
{

    [SerializeField] float _fJamp;

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("isDead")) return;
        if (anim.GetBool("victory")) return;

        if (Input.GetKeyDown(KeyCode.Space) && anim.GetBool("isOnGround")) rb.AddForce(new Vector2(0, _fJamp),ForceMode2D.Impulse);

        _fVec.x = Input.GetAxis("Horizontal");
        if (_fVec.x > 0)
        {
            anim.SetBool("isMoving", true);
            transform.localScale = new Vector3(2.0f,2.0f,1.0f);
        }
        else if(_fVec.x < 0)
        {
            anim.SetBool("isMoving", true);
            transform.localScale = new Vector3(-2.0f, 2.0f, 1.0f);
        }
        else anim.SetBool("isMoving", false);
        Debug.Log(_bWall);
        Debug.Log("aaa" + anim.GetBool("isOnGround"));
        if (_bWall) _fVec.x = 0;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") StartCoroutine("defeat", 2.0f);
        if (collision.gameObject.tag == "Ground" && !anim.GetBool("isOnGround")) _bWall = true;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.tag == "Enemy") collision.GetComponent<MoveEnemy>().Damage();
        if (collision.gameObject.tag == "Goal") Clear();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground") anim.SetBool("isOnGround", false);
    }

    protected override void Death()
    {
        gameObject.SetActive(false);
    }

    void Clear()
    {
        anim.SetBool("victory",true);
    }

}
