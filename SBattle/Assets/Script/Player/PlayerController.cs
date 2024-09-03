using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    // プレイヤーのスピード
    private float _speed = 3;
    private float _avoidanceSpeed = 100;
    private float _jumpSpeed = 12;

    // 物理関係の処理
    private float _gravity = 15;
    private float _fallSpeed = 20;
    private float _initFallSpeed = 2;

    private Rigidbody _rb;
    private Transform _transform;
    private CharacterController _characterController;
    public GameObject _Player;

    // 変数
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
    /// 移動Action(PlayerInput側から呼ばれる)
    /// </summary>
    public void OnMove(InputAction.CallbackContext context)
    {
        // 入力値を保持しておく
        _inputMove = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// ジャンプAction(PlayerInput側から呼ばれる)
    /// </summary>
    public void OnJump(InputAction.CallbackContext context)
    {
        // ボタンが押された瞬間かつ着地している時だけ処理
        if (!context.performed || !_characterController.isGrounded) return;

        // 鉛直上向きに速度を与える
        _verticalVelocity = _jumpSpeed;
    }

    public void OnAvoidance(InputAction.CallbackContext context)
    {
        // ボタンが押された瞬間かつ着地している時だけ処理
        if (!context.performed || !_characterController.isGrounded) return;

        // 正面に速度を与える
        _rb.AddForce(Vector3.forward * _avoidanceSpeed, ForceMode.Impulse);
    }

    private void Update()
    {
        // 地面についているかの判定
        var isGrounded = _characterController.isGrounded;

        // 地面についているときのみジャンプができる
        if (isGrounded && !_isGroundedPrev)
        {
            // 着地する瞬間に落下の初速を指定しておく
            _verticalVelocity = -_initFallSpeed;
        }
        // 空中の場合
        else if (!isGrounded)
        {
            // 空中にいるときは、下向きに重力加速度を与えて落下させる
            _verticalVelocity -= _gravity * Time.deltaTime;

            // 落下する速さ以上にならないように補正
            if (_verticalVelocity < -_fallSpeed)
            {
                _verticalVelocity = -_fallSpeed;
            }
        }

        _isGroundedPrev = isGrounded;

        _speedNow = _speed;

        // 操作入力と鉛直方向速度から、現在速度を計算
        var moveVelocity = new Vector3(
            _inputMove.x * _speedNow,
            _verticalVelocity,
            _inputMove.y * _speedNow
        );

        // 現在フレームの移動量を移動速度から計算
        var moveDelta = moveVelocity * Time.deltaTime;

        // CharacterControllerに移動量を指定し、オブジェクトを動かす
        _characterController.Move(moveDelta);

        // 移動量が０ではないとき
        if (_inputMove != Vector2.zero)
        {
            // 操作入力からy軸周りの目標角度[deg]を計算
            var targetAngleY = -Mathf.Atan2(_inputMove.y, _inputMove.x)
                * Mathf.Rad2Deg + 90;

            // イージングしながら次の回転角度[deg]を計算
            var angleY = Mathf.SmoothDampAngle(
                _transform.eulerAngles.y,
                targetAngleY,
                ref _turnVelocity,
                0.1f
            );

            // オブジェクトの回転を更新
            _transform.rotation = Quaternion.Euler(0, angleY, 0);
        }
    }

    // ちょっとよくわからなかったので後回し
    ///// <summary>
    ///// 標的に命中する射出速度の計算
    ///// </summary>
    ///// <param name="pointA">射出開始座標</param>
    ///// <param name="pointB">標的の座標</param>
    ///// <returns>射出速度</returns>
    //private Vector3 AvoidVelocity(Vector3 pointA, Vector3 pointB, float angle)
    //{
    //    // 射出角をラジアンに変換
    //    float rad = angle * Mathf.PI / 180;

    //    // 水平方向の距離
    //    float x = Vector2.Distance(new Vector2(pointA.x, pointA.z), new Vector2(pointB.x, pointB.z));

    //    // 垂直方向の距離
    //    float y = pointA.y - pointB.y;

    //    // 斜方投射の公式を初速度について解く
    //    // Mathf.Pow(累乗する数,何乗か)
    //    float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

    //    if (float.IsNaN(speed))
    //    {
    //        // 条件を満たす初速を算出できなければVector3.zeroを返す
    //        return Vector3.zero;
    //    }
    //    else
    //    {
    //        return (new Vector3(pointB.x - pointA.x, x * Mathf.Tan(rad), pointB.z - pointA.z).normalized * speed);
    //    }
    //}
}