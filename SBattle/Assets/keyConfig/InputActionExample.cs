using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionExample : MonoBehaviour
{
    // Actionをインスペクターから編集できるようにする
    [SerializeField] private InputAction _action;

    // rigidbodyの定義
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
            // 上にジャンプさせる
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