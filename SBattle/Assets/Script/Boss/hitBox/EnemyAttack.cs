using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    MeshRenderer _mesh;
    GameObject _playerObj;
    public float _attckCount;
    public bool _isAttack;
    //private int _Alpha;
    // Start is called before the first frame update
    void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
        _playerObj = GameObject.FindWithTag("Player");
        _attckCount = 0;
        _isAttack = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // UŒ‚‚·‚é‚Ü‚Å‚Í“§–¾‚ÅUŒ‚‚ğ‚·‚é‚ÆŒ»‚ê‚é“–‚½‚è”»’è
        _attckCount += Time.deltaTime;
        if (_attckCount < 3.0f)
        {
            Vector3 myPos = this.transform.position;
            myPos.x = _playerObj.transform.position.x;
            myPos.z = _playerObj.transform.position.z;
            this.transform.position = myPos;
            _mesh.material.color = new Color32(0, 0, 0, 0);
        
        }
        else if (_attckCount < 4.0f)
        {
            _isAttack = true;
            _mesh.material.color = new Color32(255, 0, 0, 120);
        }
        else if (_attckCount > 4.6f)
        {
            _attckCount = 0;
            _isAttack= false;
        }
    }
}
