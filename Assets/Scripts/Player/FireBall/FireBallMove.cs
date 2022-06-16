using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMove : MonoBehaviour
{
    private float liteTime = 15;

    public float speedFireBall = 2;

    public float DMG;

    [Header("==taget==")]

    public bool checkTagetPlayer;

    public void Init(bool checkTagetPlayer)
    {
        if(!checkTagetPlayer)
        {
            transform.up = -((PlayerControl.Instance.playerAttack.lookEnemy - transform.position) + Vector3.up * 0.5f);
        }
        if (checkTagetPlayer)
        {
            transform.up = -((PlayerControl.Instance.transform.position - transform.position) + Vector3.up * 0.5f);
        }
        StartCoroutine(DeactiveAfter(liteTime));
    }

    private void Update()
    {
        transform.Translate(0, -speedFireBall*Time.deltaTime, 0);
    }

    private IEnumerator DeactiveAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!checkTagetPlayer)
        {
            if (other.CompareTag("enemy") || other.CompareTag("obstacle") )
            {

                if (other.CompareTag("enemy"))
                {
                    other.transform.parent.GetComponent<EnemyControl>().ChangeHPEnemy(DMG);
                }
                
                gameObject.SetActive(false);
            }
        }
        if (checkTagetPlayer)
        {
            if (other.CompareTag("obstacle") || other.CompareTag("Player"))
            {
                if (other.CompareTag("Player"))
                {
                    PlayerControl.Instance.GetHit(DMG);
                }
                gameObject.SetActive(false);
            }
        }


    }

}
