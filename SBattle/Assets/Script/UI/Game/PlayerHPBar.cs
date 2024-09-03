using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    //�ő�HP�ƌ��݂�HP�B
    private int _maxHp = 150;
    private int _punchDamage = 15;
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
    private void OnTriggerEnter(Collider other)
    {
        //Enemy�^�O�̃I�u�W�F�N�g�ɐG���Ɣ���
        if (other.gameObject.tag == "BAttack")
        {
            //���݂�HP����_���[�W������
            _currentHp = _currentHp - _punchDamage;

            //�ő�HP�ɂ����錻�݂�HP��Slider�ɔ��f�B
            //int���m�̊���Z�͏����_�ȉ���0�ɂȂ�̂�float�ɂ��Ă���
            _slider.value = (float)_currentHp / (float)_maxHp;
        }
    }
}
