using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject target; // �Ǐ]����^�[�Q�b�g�I�u�W�F�N�g

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player"); //���O��Player�̃I�u�W�F�N�g���擾���ă^�[�Q�b�g�Ɏw��
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(target.transform);
    }
}