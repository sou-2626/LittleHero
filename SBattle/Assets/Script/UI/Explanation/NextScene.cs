using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
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
        // フェードアウトの開始
        bool isStartBotton = Input.GetKey(KeyCode.Return) || Input.GetKey("joystick button 7");
        if (isStartBotton & !_isBottomDown)
        {
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
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}
