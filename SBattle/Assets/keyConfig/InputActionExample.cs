using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionExample : MonoBehaviour
{
    // Action���C���X�y�N�^�[����ҏW�ł���悤�ɂ���
    [SerializeField] private InputAction _action;

    // rigidbody�̒�`
    Rigidbody rb;

    bool _Jump = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_Jump)
        {
            // ��ɃW�����v������
            rb.AddForce(0, 5, 0, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _Jump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _Jump = false;
    }

}