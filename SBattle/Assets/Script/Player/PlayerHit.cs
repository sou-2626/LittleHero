using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // �p���`�őO�ɏo�����̈ʒu
    [SerializeField] float _maxPunchLength;

    // �����ʒu�ƒ���
    public float _punchLength;

    // �ʒu
    private Vector3 _initPos;   // �ŏ�
    private Vector3 _pos;       // ����
    private float _count;
    private bool _isAttack;

    // �J�E���g�̑���
    private float _countSpeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        _isAttack = false;
        // �����ʒu��ݒ�
        _initPos = gameObject.transform.localPosition;

        // �p���`�̒���
        _punchLength = _maxPunchLength - _initPos.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // �����ʒu���甼���������čU�����鏈��
        if (_isAttack)
        {
            _count += _countSpeed;
            if (_pos.z < 0)
            {
                _isAttack = false;
            }
            _pos.z = Mathf.Sin(_count) * _punchLength;
            _pos = new Vector3(_initPos.x, _initPos.y, _pos.z);

            gameObject.transform.localPosition = _pos;
        }
        else
        {
            _count = 0;
        }

        if (Input.GetKey("z"))
        {
            _isAttack = true;
        }
    }
}
