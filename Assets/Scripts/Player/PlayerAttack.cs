using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [HideInInspector]
    public Vector3 lookEnemy;

    private float distanceAttackSword=2.5f;
    // Start is called before the first frame update
    private void Start()
    {
        SearchEnemy();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void SearchEnemy()
    {
        PlayerControl.Instance.checkAttackSword = false;
        PlayerControl.Instance.checkAttackMagic = false;
        PlayerControl.Instance.animatorPlayer.SetBool("isAttackMagic", false);
        PlayerControl.Instance.animatorPlayer.SetBool("isAttackSword", false);
        if (PlayerControl.Instance.enemys.childCount > 0)
        {
            float minPSEnemy = Mathf.Abs(Vector3.Distance(transform.position, PlayerControl.Instance.enemys.GetChild(0).position));

            Vector3 vectorMinPSEnemy = PlayerControl.Instance.enemys.GetChild(0).position;
            foreach (Transform item in PlayerControl.Instance.enemys)
            {
                if (item.GetChild(0).CompareTag("enemy"))
                {
                    if (Mathf.Abs(Vector3.Distance(transform.position, item.position)) < minPSEnemy)
                    {

                        minPSEnemy = Vector3.Distance(transform.position, item.position);
                        vectorMinPSEnemy = item.position;
                    }
                }
            }
            lookEnemy = vectorMinPSEnemy;
        }
        
    }
    public void AttackEnemySword()
    {
        PlayerControl.Instance.swordWeapon.SetActive(true);
        PlayerControl.Instance.magicWeapon.SetActive(false);
        PlayerControl.Instance.animatorPlayer.SetBool("isAttackMagic", false);
        PlayerControl.Instance.animatorPlayer.SetBool("isAttackSword", true);
        transform.forward = new Vector3((lookEnemy - transform.position).x, 0, (lookEnemy - transform.position).z);
        PlayerControl.Instance.checkAttackSword = true;
        PlayerControl.Instance.checkAttackMagic = false;
    }

    public void CheckEnemy()
    {
        SearchEnemy();
        if (Vector3.Distance(transform.position, lookEnemy) > distanceAttackSword && PlayerControl.Instance.enemys.childCount > 0)
        {
            AttackEnemyMagic();
        }
        if (Vector3.Distance(transform.position, lookEnemy) <= distanceAttackSword && PlayerControl.Instance.enemys.childCount > 0)
        {
            AttackEnemySword();
        }
        if (PlayerControl.Instance.enemys.childCount == 0)
        {
            /*checkAttackSword = false;
            checkAttackMagic = false;*/
        }

    }

    public void AttackEnemyMagic()
    {
        PlayerControl.Instance.swordWeapon.SetActive(false);
        PlayerControl.Instance.magicWeapon.SetActive(true);
        PlayerControl.Instance.animatorPlayer.SetBool("isAttackSword", false);
        PlayerControl.Instance.animatorPlayer.SetBool("isAttackMagic", true);
        transform.forward =new Vector3((lookEnemy - transform.position).x,0, (lookEnemy - transform.position).z);
        PlayerControl.Instance.checkAttackSword = false;
        PlayerControl.Instance.checkAttackMagic = true;

    }

    
}