using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    // �v���C���[�̃X�s�[�h
    private float _speed = 3;
    private float _avoidanceSpeed = 100;
    private float _jumpSpeed = 12;

    // �����֌W�̏���
    private float _gravity = 15;
    private float _fallSpeed = 20;
    private float _initFallSpeed = 2;

    private Rigidbody _rb;
    private Transform _transform;
    private CharacterController _characterController;
    public GameObject _Player;

    // �ϐ�
    private Vector2 _inputMove;
    private float _speedNow;
    private float _verticalVelocity;
    private float _turnVelocity;
    private int _Count;
    public bool _isGroundedPrev;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _transform = transform;
        _characterController = GetComponent<CharacterController>();
        _isGroundedPrev = false;
    }

    /// <summary>
    /// �ړ�Action(PlayerInput������Ă΂��)
    /// </summary>
    public void OnMove(InputAction.CallbackContext context)
    {
        // ���͒l��ێ����Ă���
        _inputMove = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// �W�����vAction(PlayerInput������Ă΂��)
    /// </summary>
    public void OnJump(InputAction.CallbackContext context)
    {
        // �{�^���������ꂽ�u�Ԃ����n���Ă��鎞��������
        if (!context.performed || !_characterController.isGrounded) return;

        // ����������ɑ��x��^����
        _verticalVelocity = _jumpSpeed;
    }

    public void OnAvoidance(InputAction.CallbackContext context)
    {
        // �{�^���������ꂽ�u�Ԃ����n���Ă��鎞��������
        if (!context.performed || !_characterController.isGrounded) return;

        // ���ʂɑ��x��^����
        _rb.AddForce(Vector3.forward * _avoidanceSpeed, ForceMode.Impulse);
    }

    private void Update()
    {
        // �n�ʂɂ��Ă��邩�̔���
        var isGrounded = _characterController.isGrounded;

        // �n�ʂɂ��Ă���Ƃ��̂݃W�����v���ł���
        if (isGrounded && !_isGroundedPrev)
        {
            // ���n����u�Ԃɗ����̏������w�肵�Ă���
            _verticalVelocity = -_initFallSpeed;
        }
        // �󒆂̏ꍇ
        else if (!isGrounded)
        {
            // �󒆂ɂ���Ƃ��́A�������ɏd�͉����x��^���ė���������
            _verticalVelocity -= _gravity * Time.deltaTime;

            // �������鑬���ȏ�ɂȂ�Ȃ��悤�ɕ␳
            if (_verticalVelocity < -_fallSpeed)
            {
                _verticalVelocity = -_fallSpeed;
            }
        }

        _isGroundedPrev = isGrounded;

        _speedNow = _speed;

        // ������͂Ɖ����������x����A���ݑ��x���v�Z
        var moveVelocity = new Vector3(
            _inputMove.x * _speedNow,
            _verticalVelocity,
            _inputMove.y * _speedNow
        );

        // ���݃t���[���̈ړ��ʂ��ړ����x����v�Z
        var moveDelta = moveVelocity * Time.deltaTime;

        // CharacterController�Ɉړ��ʂ��w�肵�A�I�u�W�F�N�g�𓮂���
        _characterController.Move(moveDelta);

        // �ړ��ʂ��O�ł͂Ȃ��Ƃ�
        if (_inputMove != Vector2.zero)
        {
            // ������͂���y������̖ڕW�p�x[deg]���v�Z
            var targetAngleY = -Mathf.Atan2(_inputMove.y, _inputMove.x)
                * Mathf.Rad2Deg + 90;

            // �C�[�W���O���Ȃ��玟�̉�]�p�x[deg]���v�Z
            var angleY = Mathf.SmoothDampAngle(
                _transform.eulerAngles.y,
                targetAngleY,
                ref _turnVelocity,
                0.1f
            );

            // �I�u�W�F�N�g�̉�]���X�V
            _transform.rotation = Quaternion.Euler(0, angleY, 0);
        }
    }

    // ������Ƃ悭�킩��Ȃ������̂Ō��
    ///// <summary>
    ///// �W�I�ɖ�������ˏo���x�̌v�Z
    ///// </summary>
    ///// <param name="pointA">�ˏo�J�n���W</param>
    ///// <param name="pointB">�W�I�̍��W</param>
    ///// <returns>�ˏo���x</returns>
    //private Vector3 AvoidVelocity(Vector3 pointA, Vector3 pointB, float angle)
    //{
    //    // �ˏo�p�����W�A���ɕϊ�
    //    float rad = angle * Mathf.PI / 180;

    //    // ���������̋���
    //    float x = Vector2.Distance(new Vector2(pointA.x, pointA.z), new Vector2(pointB.x, pointB.z));

    //    // ���������̋���
    //    float y = pointA.y - pointB.y;

    //    // �Ε����˂̌����������x�ɂ��ĉ���
    //    // Mathf.Pow(�ݏ悷�鐔,���悩)
    //    float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

    //    if (float.IsNaN(speed))
    //    {
    //        // �����𖞂����������Z�o�ł��Ȃ����Vector3.zero��Ԃ�
    //        return Vector3.zero;
    //    }
    //    else
    //    {
    //        return (new Vector3(pointB.x - pointA.x, x * Mathf.Tan(rad), pointB.z - pointA.z).normalized * speed);
    //    }
    //}
}