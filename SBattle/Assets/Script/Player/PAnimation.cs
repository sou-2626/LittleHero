using UnityEngine;
using UnityEngine.InputSystem;

public class PAnimation : MonoBehaviour
{
    public Animator anim;
    private Vector2 _inputMove;
    public static bool _isJump = false;
    public static bool _isAttack = false;
    public static bool _isAvoidance = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // ì¸óÕílÇï€éùÇµÇƒÇ®Ç≠
        _inputMove = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!_isAvoidance)
        {
            _isJump = true;
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        _isAttack = true;
    }

    public void OnAvoidance(InputAction.CallbackContext context)
    {
        _isAvoidance = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAvoidance)
        {
            anim.SetInteger("motion", 4);
            _isAvoidance = false;
        }
        else if (_isAttack)
        {
            anim.SetInteger("motion", 3);
            _isAttack = false;
        }
        else if (_isJump)
        {
            anim.SetInteger("motion", 2);
            _isJump = false;
        }
        else if (_inputMove != Vector2.zero)
        {
            anim.SetInteger("motion", 1);
        }
        else
        {
            anim.SetInteger("motion", 0);//reset
        }
    }
}
