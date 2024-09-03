using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject target; // 追従するターゲットオブジェクト

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player"); //名前がPlayerのオブジェクトを取得してターゲットに指定
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(target.transform);
    }
}