using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireBall : MonoBehaviour
{

    private List<GameObject> listFireBallPool = new List<GameObject>();

    [Header("==FireBall==")]
    public GameObject fireBall;

    public float delaySpawnFireBall = 0.665f;

    public float fireRateFireBall = 1f;

    public float fireRateSpawn;

    [Header("==speed Fire Ball==")]
    public float speedFireBall = 2;

    [Header("==Dame==")]

    public float damgeMagic = 1;

    [Header("==taget==")]

    public bool checkTagetPlayer;

    [Header("==anim==")]
    public Animator animator;

    [Header("==ennemy==")]
    public EnemyControl enemyControl;


    private void Start()
    {
        animator.SetFloat("fireRateMagic", fireRateFireBall);
        fireRateSpawn = delaySpawnFireBall * animator.GetFloat("fireRateMagic");
    }

    private void Update()
    {
        if (!checkTagetPlayer)
        {
            if (PlayerControl.Instance.checkAttackMagic)
            {
                animator.SetFloat("fireRateMagic", fireRateFireBall);
                DelaySpawn();
            }
        }
        if (checkTagetPlayer)
        {
            if (enemyControl.enemyAttack.checkAttack)
            {
                animator.SetFloat("fireRateMagic", fireRateFireBall);
                DelaySpawn();

            }
        }

    }

    private GameObject GetFromBool(Vector3 transform, Quaternion rotation)
    {
        for (int i = 0; i < listFireBallPool.Count; i++)
        {
            var fB = listFireBallPool[i];
            if (!fB.activeInHierarchy)
            {
                fB.SetActive(true);
                fB.transform.SetPositionAndRotation(transform, rotation);
                return fB;
            }
        }
        //Debug.LogError("spawn");
        var fBN = Instantiate(fireBall, transform, rotation);
        listFireBallPool.Add(fBN);
        return fBN;
    }

    private void DelaySpawn()
    {
        fireRateSpawn -= Time.deltaTime;
        if (fireRateSpawn <= 0)
        {
            FireBallMove fireBallMove = GetFromBool(transform.position, transform.rotation).GetComponent<FireBallMove>();
            if (fireBallMove.gameObject.activeInHierarchy)
            {
                fireBallMove.checkTagetPlayer = checkTagetPlayer;
                fireBallMove.Init(checkTagetPlayer);
                fireBallMove.DMG = damgeMagic;
                fireBallMove.speedFireBall = speedFireBall;
            }
            fireRateSpawn = delaySpawnFireBall / animator.GetFloat("fireRateMagic");
            if (checkTagetPlayer)
            {
                enemyControl.enemyAttack.checkAttack = false;
            }
        }
        fireRateSpawn = Mathf.Clamp(fireRateSpawn, -1, 5);
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == PlayerControl.Instance.magicWeapon.transform.name)
        {
            FireBallMove fireBallMove= GetFromBool( transform.position, transform.rotation).GetComponent<FireBallMove>();
            if(fireBallMove.gameObject.activeInHierarchy)
                fireBallMove.Init();
        }
    }*/
}
