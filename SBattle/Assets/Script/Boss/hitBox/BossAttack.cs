using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    // ���b�V���̎擾
    MeshRenderer _mesh;
    
    // �I�u�W�F�N�g�̎擾
    public GameObject _playerObj;

    //private int _Alpha;
    // Start is called before the first frame update
    void Start()
    {
        // �������ŕ\��
        _mesh = GetComponent<MeshRenderer>();
        _mesh.material.color = new Color32(255, 0, 0, 120);

        // �v���C���[�I�u�W�F�N�g�̈ʒu����x�����擾���鏈��
        // ���̃I�u�W�F�N�g�����̈ʒu�ɔz�u����
        _playerObj.transform.position = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
