using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    MeshRenderer _mesh;
    EnemyAttack _enemyAttack;
    GameObject _enemyAttackObj;
    GameObject _playerObj;
    Collider _myCollider;
    public float _cubeSize;
    private float _cubeSizeY = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        _playerObj = GameObject.FindWithTag("Player");
        _myCollider = this.GetComponent<Collider>();
        _enemyAttackObj = GameObject.Find("EnemyAttack");
        _mesh = GetComponent<MeshRenderer>();
        _enemyAttack = _enemyAttackObj.GetComponent<EnemyAttack>();
        _cubeSize = 1.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // _isAttackÇ™trueÇÃéûÇ…çUåÇÇ‹Ç≈ÇÃéûä‘ÇÃï\é¶
        if (_enemyAttack._isAttack)
        {
            _cubeSize += 0.01f;
            this.transform.localScale = new Vector3(_cubeSize, _cubeSizeY, _cubeSize);
            _myCollider.isTrigger = true;
            _mesh.material.color = new Color32(255, 0, 0, 255);
        }
        else
        {
            _cubeSize = 1.0f;
            Vector3 myPos = this.transform.position;
            myPos.x = _playerObj.transform.position.x;
            myPos.z = _playerObj.transform.position.z;
            this.transform.position = myPos;
            _mesh.material.color = new Color32(0, 0, 0, 0);
            _myCollider.isTrigger = false;
        }
    }
}
