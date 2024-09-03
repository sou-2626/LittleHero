using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    // ŽžŠÔ(•ª)
    private int _countdownMinutes = 1;
    private int _minutes = 60;

    // Žc‚èŽžŠÔ
    public static float _countdownSeconds = 0;
    Text timeText;
    private void Start()
    {
        timeText = GetComponent<Text>();
        _countdownSeconds = _countdownMinutes * _minutes;
    }

    void Update()
    {
        _countdownSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)_countdownSeconds);
        timeText.text = span.ToString(@"mm\:ss");
    }
}