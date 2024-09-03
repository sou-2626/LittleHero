using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackHit : MonoBehaviour
{
    // �A�^�b�N���\��������
    public int AttackNum = 0;
    
    // �I�u�W�F�N�g�̎擾
    public GameObject _playerObj;
    private GameObject _hitAreaObj;
    private GameObject _countAreaObj;

    // �A�^�b�N�t���O
    private�@bool _isAttack;
    private bool _isAttacking;
    public bool IsDestroy;

    // Start is called before the first frame update
    void Start()
    {
        // ������
        _isAttack = false;
        _isAttacking = false;

        // Cube�v���n�u��GameObject�^�Ŏ擾
        _hitAreaObj = (GameObject)Resources.Load("BossAttackArea");
        _countAreaObj = (GameObject)Resources.Load("BossAttackCount");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isAttack)
        {
            Instantiate(_hitAreaObj, _hitAreaObj.transform.position, Quaternion.identity);
            Instantiate(_countAreaObj, _countAreaObj.transform.position, Quaternion.identity);
        }
        else
        {
            Destroy(_hitAreaObj);
            Destroy(_countAreaObj);
        }

        if (Input.GetKey(KeyCode.Return) && !_isAttacking)
        {
            _isAttack = true;
            _isAttacking = true;
        }
        else
        {
            _isAttack = false;
            _isAttacking = false;
        }
    }
}
