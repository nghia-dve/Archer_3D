using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [Header("==HP==")]
    [SerializeField]
    private GameObject HP;

    public float maxHP = 20;

    public float countHP = 0;

    [Header("==Die==")]
    public bool checkDie = false;

    public float timeDie = 2;

    [Header("==Move==")]
    public float moveSpeed = 1;

    [Header("==combat==")]
    public bool checkCloseCombat=false;

    public float distanceCloseCombat = 1;

    [Header("==clamp==")]
    [SerializeField]
    private float clampX = 4;

    [SerializeField]
    private float clampZ = 14f;

    [HideInInspector]
    public SearchPlayer searchPlayer;

    [HideInInspector]
    public Rigidbody rigidbodyEnemy;

    [HideInInspector]
    public Collider colliderEnemy;

    [HideInInspector]
    public EnemyAttack enemyAttack;

    [HideInInspector]
    public Animator animatorEnemy;

    private void Awake()
    {
        searchPlayer = GetComponent<SearchPlayer>();
        animatorEnemy = GetComponent<Animator>();
        rigidbodyEnemy = GetComponent<Rigidbody>();
        colliderEnemy = transform.GetChild(0).GetComponent<Collider>();
        enemyAttack= transform.GetChild(0).GetComponent<EnemyAttack>();
    }


    private void Start()
    {    
        timeDie = animatorEnemy.GetFloat("timeDie");
        countHP = maxHP;
    }

    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -clampX, clampX),
            Mathf.Clamp(transform.position.y, 0, 0), Mathf.Clamp(transform.position.z, -clampZ, clampZ));
    }

    public void ChangeHPEnemy(float DMG)
    {
        countHP -= DMG;
        HP.transform.localScale = new Vector3(Mathf.Clamp(countHP/maxHP,0,1), 1, 1);
        if (HP.transform.localScale.x <= 0)
        {           
            transform.parent = null;
            colliderEnemy.enabled = false;
            Destroy(rigidbodyEnemy);
            if (!checkDie)
            {
                checkDie = true;
                animatorEnemy.SetTrigger("die");
            }
            StartCoroutine(DeactiveAfterEnemy(timeDie));
        }
        GetHit();
    }

    private void GetHit()
    {
        if (!checkDie)
        {
            animatorEnemy.SetTrigger("GetHit");
            enemyAttack.checkAttack = false;
        }
        
    }


    private IEnumerator DeactiveAfterEnemy(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
