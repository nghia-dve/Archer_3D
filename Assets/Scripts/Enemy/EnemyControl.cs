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

    [Header("==Anim==")]
    public Animator animatorEnemy;

    [Header("==Die==")]
    public bool checkDie = false;

    public float timeDie = 2;

    [Header("==Move==")]
    public float moveSpeed = 1;

    [HideInInspector]
    public SearchPlayer searchPlayer;

    [HideInInspector]
    public Rigidbody rigidbodyEnemy;

    [HideInInspector]
    public Collider colliderEnemy;

    private void Awake()
    {
        searchPlayer = GetComponent<SearchPlayer>();
        animatorEnemy = GetComponent<Animator>();
        rigidbodyEnemy = GetComponent<Rigidbody>();
        transform.GetChild(0).GetComponent<Collider>();
    }


    private void Start()
    {    
        timeDie = animatorEnemy.GetFloat("timeDie");
        countHP = maxHP;
    }

    public void ChangeHPEnemy(float DMG)
    {
        countHP -= DMG;
        HP.transform.localScale = new Vector3(Mathf.Clamp(countHP/maxHP,0,1), 1, 1);
        if (HP.transform.localScale.x <= 0)
        {           
            gameObject.transform.parent.gameObject.transform.parent = null;
            colliderEnemy.enabled = false;
            Destroy(rigidbodyEnemy);
            if (checkDie == false)
            {
                animatorEnemy.SetTrigger("die");
                checkDie = true;
            }
            StartCoroutine(DeactiveAfterEnemy(timeDie));
        }
        GetHit();
    }

    private void GetHit()
    {
        if (checkDie == false)
        {
            animatorEnemy.SetTrigger("GetHit");
        }
        
    }


    private IEnumerator DeactiveAfterEnemy(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
