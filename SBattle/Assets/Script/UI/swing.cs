using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing : MonoBehaviour
{
    private Vector3 _pos;
    private Vector3 _startPos;
    // Start is called before the first frame update
    void Start()
    {
        _startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _pos.x = Mathf.Sin(Time.time * 3) * 10;
        this.transform.position = new Vector3(_pos.x + _startPos.x, this.transform.position.y, this.transform.position.z);
    }
}
