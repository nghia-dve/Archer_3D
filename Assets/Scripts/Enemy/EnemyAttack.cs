using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private bool checkAttack = false;

    private float DMGEnemy=2;

    private float timeAttack = 0.833f;

    private EnemyControl enemyControl;

    private void Start()
    {
        enemyControl = transform.parent.GetComponent<EnemyControl>();
        timeAttack = enemyControl.animatorEnemy.GetFloat("timeAttack");
    }

    private void Update()
    {
        if (enemyControl.searchPlayer.VisibleTargets.Count > 0)
        {
            if (Vector3.Distance(transform.position, enemyControl.searchPlayer.VisibleTargets[0].position) <= 2)
            {
                StartCoroutine(DelayAttack(timeAttack));
                enemyControl.animatorEnemy.SetTrigger("enemyAttack");
            }
            if (Vector3.Distance(transform.position, enemyControl.searchPlayer.VisibleTargets[0].position) > 2)
            {
                checkAttack = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player")&&checkAttack)
        {
            PlayerControl.Instance.GetHit(DMGEnemy);
        }
    }
    /*private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && checkAttack)
        {
            Debug.LogError("trungStay");
        }
    }*/
    private IEnumerator DelayAttack(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        checkAttack = true;
    }
}
