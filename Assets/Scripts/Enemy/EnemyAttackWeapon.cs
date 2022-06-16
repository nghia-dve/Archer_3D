using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackWeapon : MonoBehaviour
{
    [SerializeField]
    private EnemyControl enemyControl;

    private float DMGEnemy = 2;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && enemyControl.enemyAttack.checkAttack && enemyControl.checkCloseCombat)
        {
            PlayerControl.Instance.GetHit(DMGEnemy);
            enemyControl.enemyAttack.checkAttack = false;
        }
    }
}
