using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    // メッシュの取得
    MeshRenderer _mesh;
    
    // オブジェクトの取得
    public GameObject _playerObj;

    //private int _Alpha;
    // Start is called before the first frame update
    void Start()
    {
        // 半透明で表示
        _mesh = GetComponent<MeshRenderer>();
        _mesh.material.color = new Color32(255, 0, 0, 120);

        // プレイヤーオブジェクトの位置を一度だけ取得する処理
        // このオブジェクトをその位置に配置する
        _playerObj.transform.position = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
