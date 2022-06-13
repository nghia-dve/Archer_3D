using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMove : MonoBehaviour
{
    private float liteTime = 15;
    public void Init()
    {
        transform.up = -((PlayerControl.Instance.playerAttack.lookEnemy - transform.position )+ Vector3.up*0.5f);
        StartCoroutine(DeactiveAfter(liteTime));
    }

    private void Update()
    {
        transform.Translate(0, -PlayerControl.Instance.speedFireBall*Time.deltaTime, 0);
        
    }

    private IEnumerator DeactiveAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy")||other.CompareTag("obstacle"))
        {
            if (other.CompareTag("enemy"))
            {
                other.transform.parent.GetComponent<EnemyControl>().ChangeHPEnemy(PlayerControl.Instance.damgeMagic);
            }
            gameObject.SetActive(false);
        }
       
    }

}
