using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    //�ő�HP�ƌ��݂�HP
    private int _maxHp = 150;
    private int _punchDamage = 15;
    private int _invTimeMax = 360;
    private int _invTime = 0;
    public static int _currentHp;

    // ���ɃX���C�_�[������
    public Slider _slider;

    void Start()
    {
        //Slider�𖞃^���ɂ���B
        _slider.value = 1;
        //���݂�HP���ő�HP�Ɠ����ɁB
        _currentHp = _maxHp;
    }

    //Collider�I�u�W�F�N�g��IsTrigger�Ƀ`�F�b�N����邱�ƁB
    //private void OnTriggerStay(Collider other)
    private void OnTriggerEnter(Collider other)
    {
        if(_invTime > 0)
        {
            _invTime--;
        }

        //Enemy�^�O�̃I�u�W�F�N�g�ɐG���Ɣ���
        if (other.gameObject.tag == "BAttack")
        {
            if (_invTime <= 0)
            {
                //���݂�HP����_���[�W������
                _currentHp = _currentHp - _punchDamage;
                _invTime = _invTimeMax;
            }

            //�ő�HP�ɂ����錻�݂�HP��Slider�ɔ��f�B
            //int���m�̊���Z�͏����_�ȉ���0�ɂȂ�̂�float�ɂ��Ă���
            _slider.value = (float)_currentHp / (float)_maxHp;
        }
    }
}
