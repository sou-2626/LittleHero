using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    //最大HPと現在のHP。
    private int _maxHp = 150;
    private int _punchDamage = 15;
    public static int _currentHp;

    // 中にスライダーを入れる
    public Slider _slider;

    void Start()
    {
        //Sliderを満タンにする。
        _slider.value = 1;
        //現在のHPを最大HPと同じに。
        _currentHp = _maxHp;
    }

    //ColliderオブジェクトのIsTriggerにチェック入れること。
    private void OnTriggerEnter(Collider other)
    {
        //Enemyタグのオブジェクトに触れると発動
        if (other.gameObject.tag == "BAttack")
        {
            //現在のHPからダメージを引く
            _currentHp = _currentHp - _punchDamage;

            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるのでfloatにしておく
            _slider.value = (float)_currentHp / (float)_maxHp;
        }
    }
}
