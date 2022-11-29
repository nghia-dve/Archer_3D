using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Transform model;

    private Vector3 movingDir;

    [SerializeField]
    private float clampX = 4;

    [SerializeField]
    private float clampZ = 14f;

    private void Update()
    {
        SetRigidbody();
        GetTagetDir();
        Move();
        Amin();
    }

    private void SetRigidbody()
    {
        transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void GetTagetDir()
    {
        movingDir = InputManager.Instance.JoyStickDirection;
    }

    private void Move()
    {
        if (movingDir.magnitude < 0.01f) return;
        transform.parent.position += movingDir * PlayerControl.Instance.moveSpeedPlayer * Time.deltaTime;
        model.rotation = Quaternion.LookRotation(movingDir);
        transform.parent.position = new Vector3(Mathf.Clamp(transform.parent.position.x, -clampX, clampX),
            Mathf.Clamp(transform.position.y, 0, 0), Mathf.Clamp(transform.parent.position.z, -clampZ, clampZ));
    }

    private void Amin()
    {
        PlayerControl.Instance.animatorPlayer.SetBool("isRun", false);
        //PlayerControl.Instance.playerAttack.CheckEnemy();
        if (movingDir.magnitude < 0.01f) return;
        PlayerControl.Instance.animatorPlayer.SetBool("isRun", true);
        //PlayerControl.Instance.playerAttack.SearchEnemy();
    }
}
