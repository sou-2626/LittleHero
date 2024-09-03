using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // パンチで前に出た時の位置
    [SerializeField] float _maxPunchLength;

    // 初期位置と長さ
    public float _punchLength;

    // 位置
    private Vector3 _initPos;   // 最初
    private Vector3 _pos;       // 現在
    private float _count;
    private bool _isAttack;

    // カウントの速さ
    private float _countSpeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        _isAttack = false;
        // 初期位置を設定
        _initPos = gameObject.transform.localPosition;

        // パンチの長さ
        _punchLength = _maxPunchLength - _initPos.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 初期位置から半周だけして攻撃する処理
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
