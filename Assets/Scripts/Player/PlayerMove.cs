using UnityEngine;
public class PlayerMove : MonoBehaviour
{

    [SerializeField]
    private float clampX = 4;

    [SerializeField]
    private float clampZ = 14f;

    private float vertical;

    private float horizontal;

    private Vector3 vectorRotation;

    private void Start()
    {
        
    }

    private void Update()
    {
        CheckMove();
    }

    private void CheckMove()
    {
        vertical = PlayerControl.Instance.joystick.Vertical;
        horizontal = PlayerControl.Instance.joystick.Horizontal;
        if (vertical != 0 || horizontal != 0)
        {
            Move();
            PlayerControl.Instance.animatorPlayer.SetBool("isRun", true);
            PlayerControl.Instance.playerAttack.SearchEnemy();
        }
        else
        if (vertical == 0 || horizontal == 0)
        {
            PlayerControl.Instance.animatorPlayer.SetBool("isRun", false);
            PlayerControl.Instance.playerAttack.CheckEnemy();
        }
    }    

    private void Move()
    {
        transform.position = new Vector3(transform.position.x + horizontal * PlayerControl.Instance.moveSpeedPlayer * Time.deltaTime,
            transform.position.y, transform.position.z + vertical * PlayerControl.Instance.moveSpeedPlayer * Time.deltaTime);

        if (vertical != 0 || horizontal != 0)
        {
            vectorRotation = new Vector3(horizontal, 0, vertical);
        }
        transform.rotation = Quaternion.LookRotation(vectorRotation);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -clampX, clampX), 
            Mathf.Clamp(transform.position.y, 0, 0), Mathf.Clamp(transform.position.z, -clampZ, clampZ));
    }
}
