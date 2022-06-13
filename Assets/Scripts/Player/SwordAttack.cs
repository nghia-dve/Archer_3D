using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (PlayerControl.Instance.checkAttackSword && other.CompareTag("enemy"))
        {
            other.transform.parent.GetComponent<EnemyControl>().ChangeHPEnemy(PlayerControl.Instance.damgeSword);
        }
    }
}
