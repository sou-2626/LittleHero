using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BAnimation : MonoBehaviour
{
    EnemyAttack _enemyAttack;
    GameObject _enemyAttackObj;
    public Animator anim;
    private Vector2 _inputMove;
    private bool _isAttack = false;
    public float _attackCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        _enemyAttackObj = GameObject.Find("EnemyAttack");
        anim = GetComponent<Animator>();
        _enemyAttack = _enemyAttackObj.GetComponent<EnemyAttack>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // _isAttack‚ªtrue‚ÌŽž‚ÉUŒ‚‚Ü‚Å‚ÌŽžŠÔ‚Ì•\Ž¦
        if (_enemyAttack._isAttack)
        {
            _attackCount += Time.deltaTime;
            if (_attackCount > 1.0f)
            {
                _isAttack = true;
            }
        }
        else
        {
            _attackCount = 0;
        }

        if (_isAttack)
        {
            anim.SetInteger("move", 1);
            _isAttack = false;
        }
        else
        {
            anim.SetInteger("move", 0);//reset
        }


    }
}
