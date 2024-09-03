using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    // クリアかどうか
    public static bool _isClear = false;

    // ボタンを押しているとき
    public bool _isBottomDown;

    // クラスを持ってくる
    GameObject _FadePanel;
    Fade _fade;
    bool _isFadeOutEnd;
    float _fadeCount;

    float _sceneChengetime = 1;

    // Start is called before the first frame update
    void Start()
    {
        _isBottomDown = false;
        _isFadeOutEnd = false;
        _fadeCount = 0;
        _FadePanel = GameObject.Find("FadePanel");
        _fade = _FadePanel.GetComponent<Fade>();
    }

    // Update is called once per frame
    void Update()
    {
        // ボスの体力が０になった場合
        // isClearをTrueにしてシーン遷移する
        bool isClear = Input.GetKey(KeyCode.Return) |
                       BossHPBar._currentHp <= 0.001f;
        
        // 時間が０になった場合もしくはプレイヤーの体力が０になった場合
        // isClearをfalseにしてシーン遷移する
        bool isGameOver = Input.GetKey("joystick button 7") |
                          TimeCounter._countdownSeconds == 0 |
                          PlayerHPBar._currentHp <= 0.001f;

        if (isClear && !_isBottomDown)
        {
            _isClear = true;
            _fade.Out = true;
            _isFadeOutEnd = true;
            _isBottomDown = true;
        }
        else if(isGameOver && !_isBottomDown)
        {
            _isClear = false;
            _fade.Out = true;
            _isFadeOutEnd = true;
            _isBottomDown = true;
        }
        else
        {
            _isBottomDown = false;
        }

        if (_isFadeOutEnd)
        {
            _fadeCount += Time.deltaTime;
            if (_fadeCount > _sceneChengetime)
            {
                SceneManager.LoadScene("ResultScene");
            }
        }
    }
}
