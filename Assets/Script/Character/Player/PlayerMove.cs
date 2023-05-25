using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Character
{

    private float _fJamp;
    [SerializeField] GameObject canvas;

    bool _bclear = false;
    bool _dead = false;

    protected override void Start()
    {
        base.Start();
        _fSpeed = StatusManager.Instance.GetSpeed(1);
        _fJamp = StatusManager.Instance.GetJamp(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (_dead)  return;
        if (_bclear) return;
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
        if (_bWall) _fVec.x = 0;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") GameOver();
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
        if(collision.gameObject.tag == "OutLine" && !_dead) GameOver();
    }

    protected override void Death()
    {
        rb.gravityScale = 0;
        rb.gameObject.SetActive(false);
        canvas.SetActive(true);
    }

    void Clear()
    {
        _fVec.x = 0;
        anim.SetBool("victory",true);
        _bclear = true;
        StartCoroutine("ClearResult",1.5f);
    }

    IEnumerator ClearResult(float animtime)
    {
        yield return new WaitForSeconds(animtime);
        StageManager.Instance.ChangeStageSelect();
    }

    public void GameOver()
    {
        StartCoroutine("defeat", 1.2f); _dead = true;
    }

}
