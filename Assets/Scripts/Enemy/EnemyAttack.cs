using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [HideInInspector]
    public bool checkAttack = false;

    private float DMGEnemy=2;

    private float timeAttack = 1;

    private EnemyControl enemyControl;

    private void Start()
    {
        enemyControl = transform.parent.GetComponent<EnemyControl>();
        timeAttack = enemyControl.animatorEnemy.GetFloat("timeAttack");
        
    }

    private void Update()
    {
        
        if (enemyControl.searchPlayer.VisibleTargets.Count > 0&& enemyControl.checkDie == false)
        {
            if (enemyControl.checkCloseCombat)
            {
                if (Vector3.Distance(transform.position, enemyControl.searchPlayer.VisibleTargets[0].position) < enemyControl.distanceCloseCombat)
                {
                    DelayAttack();
                    //Debug.LogError(timeAttack);
                }
            }
            if (!enemyControl.checkCloseCombat)
            {
                if (Vector3.Distance(transform.position, enemyControl.searchPlayer.VisibleTargets[0].position)< enemyControl.distanceCloseCombat + 7
                    && Vector3.Distance(transform.position, enemyControl.searchPlayer.VisibleTargets[0].position) > enemyControl.distanceCloseCombat + 4)
                {
                    DelayAttack();
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player")&&checkAttack&&enemyControl.checkCloseCombat)
        {
            PlayerControl.Instance.GetHit(DMGEnemy);
            checkAttack = false;
        }
    }
    private void DelayAttack()
    {
        if (timeAttack<=0)
        {
            enemyControl.animatorEnemy.SetTrigger("enemyAttack");
            timeAttack = enemyControl.animatorEnemy.GetFloat("timeAttack");
            checkAttack = true;
        }
        else
        {
            timeAttack -= Time.deltaTime;
            
        }    
    }
}
