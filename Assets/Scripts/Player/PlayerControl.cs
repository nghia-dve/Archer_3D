using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private static PlayerControl instance;

    public static PlayerControl Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<PlayerControl>();
            return instance;
        }
    }


    [HideInInspector]
    public PlayerAttack playerAttack;

    [HideInInspector]
    public PlayerMove playerMove;

    [HideInInspector]
    public Animator animatorPlayer;

    [HideInInspector]
    public bool checkAttackSword = false;

    [HideInInspector]
    public bool checkAttackMagic = false;

    /* public SwordAttack swordAttack;*/

    [Header("==Player==")]
    public float moveSpeedPlayer = 3;

    public float HPPlayer = 100;

    public float MaxHPPlayer = 100;

    [Header("==weapon==")]
    public GameObject magicWeapon;

    public GameObject swordWeapon;

    //[Header("==joystick==")]
    //public FloatingJoystick joystick;

    [Header("==enemy==")]
    public Transform enemys;

    [Header("==Sword==")]
    public float damgeSword = 2;

    [Header("==Magic==")]
    public SpawnFireBall spawnFireBall;

    [Header("==nextLevel==")]
    public List<GameObject> listCubedis = new List<GameObject>();

    public GameObject cubeActi;


    private void Awake()
    {
        playerAttack = gameObject.GetComponent<PlayerAttack>();
        playerMove = gameObject.GetComponent<PlayerMove>();
        animatorPlayer = gameObject.GetComponent<Animator>();
        AddComponentWeapon(magicWeapon, false);
        AddComponentWeapon(swordWeapon, true);

    }

    private void AddComponentWeapon(GameObject gameObject, bool checkSword)
    {
        gameObject.AddComponent<MeshCollider>();
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<MeshCollider>().convex = true;
        gameObject.GetComponent<MeshCollider>().isTrigger = true;
        if (checkSword)
        {
            gameObject.AddComponent<SwordAttack>();
        }


    }

    public void GetHit(float DMGEnemy)
    {
        HPPlayer -= DMGEnemy;
        HPPlayer = Mathf.Clamp(HPPlayer, 0, Mathf.Infinity);
        UIManager.Instance.homeUI.ChangeHP();
        if (HPPlayer <= 0)
        {
            UIManager.Instance.ScriptSettingUI.ResetGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("nextLevel"))
        {
            UIManager.Instance.ScriptSettingUI.NextLevel();
        }
    }
}
