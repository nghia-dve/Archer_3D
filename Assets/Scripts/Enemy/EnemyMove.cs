using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private EnemyControl enemyControl;

    

    private void Start()
    {
        enemyControl = GetComponent<EnemyControl>();
    }

    private void Update()
    {
        if (enemyControl.searchPlayer.VisibleTargets.Count > 0&&enemyControl.checkDie==false)
        {
            transform.forward = /*Vector3.MoveTowards(transform.forward,*/(enemyControl.searchPlayer.VisibleTargets[0].position - transform.position)/*,2*Time.deltaTime)*/;
            if (enemyControl.checkCloseCombat)
            {
                
                if (Vector3.Distance(transform.position, enemyControl.searchPlayer.VisibleTargets[0].position) >= enemyControl.distanceCloseCombat)
                {
                    Move();
                }
            }
            if (!enemyControl.checkCloseCombat)
            {
                if (Vector3.Distance(transform.position, enemyControl.searchPlayer.VisibleTargets[0].position) >= enemyControl.distanceCloseCombat+7)
                {
                    Move();
                }
                if (Vector3.Distance(transform.position, enemyControl.searchPlayer.VisibleTargets[0].position) <= enemyControl.distanceCloseCombat + 4)
                {
                    transform.forward = /*Vector3.MoveTowards(transform.forward,*/ -(enemyControl.searchPlayer.VisibleTargets[0].position - transform.position)/*, 2 * Time.deltaTime)*/;
                    Move();
                }
            }
            /*transform.forward = Vector3.MoveTowards(transform.forward, (enemyControl.searchPlayer.VisibleTargets[0].position - transform.position), 2 * Time.deltaTime);*/
        }
    }
    private void Move()
    {
        enemyControl.enemyAttack.checkAttack = false;
        enemyControl.animatorEnemy.SetTrigger("run");
        transform.position += transform.forward * enemyControl.moveSpeed * Time.deltaTime;
        if (enemyControl.rigidbodyEnemy != null)
            enemyControl.rigidbodyEnemy.isKinematic = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            if(enemyControl.rigidbodyEnemy != null)
                enemyControl.rigidbodyEnemy.isKinematic = true;
        }
    }

}
