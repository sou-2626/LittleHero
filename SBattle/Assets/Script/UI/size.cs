using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class size : MonoBehaviour
{
    private Vector3 _scale;
    private Vector3 _startScale;
    // Start is called before the first frame update
    void Start()
    {
        _startScale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        _scale.x = Mathf.Sin(Time.time * 5) * 0.2f;
        _scale.y = Mathf.Sin(Time.time * 5) * 0.2f;
        this.transform.localScale = new Vector3(_scale.x + _startScale.x, _scale.y + _startScale.y, this.transform.localScale.z);
    }
}
