using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultSceneManager : MonoBehaviour
{

    // ボタンを押しているとき
    public bool _isBottomDown;
    public Text _bossHPText;
    public Text _timeText;

    GameObject _fadePanel;
    GameObject[] _clearObjs;
    GameObject[] _gameoverObjs;
    Fade _fade;

    private bool _result;
    private float _time;
    private int _bossRestHP;
    private bool _isFadeOutEnd;
    private float _fadeCount;
    private float _sceneChengetime = 1;
    private bool _isTitile = false;
    private bool _isGame = false;

    private int _resultObjctNum = 4;
    // Start is called before the first frame update
    void Start()
    {
        // オブジェクトの参照
        _fadePanel = GameObject.Find("FadePanel");
        _clearObjs = GameObject.FindGameObjectsWithTag("Clear");
        _gameoverObjs = GameObject.FindGameObjectsWithTag("GameOver");

        _fade = _fadePanel.GetComponent<Fade>();
        
        _result = GameSceneManager._isClear;
        _time = TimeCounter._countdownSeconds;
        _bossRestHP = BossHPBar._currentHp;
        _isBottomDown = false;
        _isFadeOutEnd = false;
        _fadeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_result)
        {
            for (int i = 0;i < _resultObjctNum; i++)
            {
                _gameoverObjs[i].SetActive(false);
            }
            // 時間の表示
            var span = new TimeSpan(0, 0, (int)_time);
            _timeText.text = span.ToString(@"mm\:ss");
        }
        else
        {
            for (int i = 0; i < _resultObjctNum; i++)
            {
                _clearObjs[i].SetActive(false);
            }
            // ボスの残りHPの表示
            _bossHPText.text = _bossRestHP.ToString("");
        }

        // フェードアウトの開始
        if (!_isBottomDown)
        {
            if(Input.GetKey("joystick button 0"))
            {
                _fade.Out = true;
                _isFadeOutEnd = true;
                _isBottomDown = true;
                _isGame = true;
            }
            else if(Input.GetKey("joystick button 1"))
            {
                _fade.Out = true;
                _isFadeOutEnd = true;
                _isBottomDown = true;
                _isTitile = true;
            }
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
                if (_isGame)
                {
                    SceneManager.LoadScene("GameScene");
                }
                if (_isTitile)
                {
                    SceneManager.LoadScene("TitleScene");
                }
            }
        }
    }
}
