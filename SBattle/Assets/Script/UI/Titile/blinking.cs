using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinking : MonoBehaviour
{
    // �_�ł�����Ώ�
    [SerializeField] private SpriteRenderer _target;

    // ���n��̃A���t�@�l�̕ω��J�[�u
    [SerializeField] private AnimationCurve _alphaCurve = AnimationCurve.Linear(0, 0, 1, 1);

    private float _cycle;
    private double _time;

    private void Start()
    {
        var length = _alphaCurve.length;
        if (length < 1)
            return;

        _cycle = _alphaCurve.keys[length - 1].time;
    }

    private void Update()
    {
        // �����������o�߂�����
        _time += Time.deltaTime;

        // ����������cycle�Ő܂�Ԃ�
        if (_time > _cycle)
            _time = Mathf.Repeat((float)_time, _cycle);

        // �A�j���[�V�����J�[�u�ɏ]�����A���t�@�l�v�Z
        var alpha = _alphaCurve.Evaluate((float)_time);

        // ��������time�ɂ�����A���t�@�l�𔽉f
        var color = _target.color;
        color.a = alpha;
        _target.color = color;
    }
}
