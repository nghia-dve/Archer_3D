using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireBall : MonoBehaviour
{
    private List<GameObject> listFireBallPool = new List<GameObject>();

    private GameObject GetFromBool(Vector3 transform, Quaternion rotation)
    {
        //bool spawnNew = true;
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
        var fBN = Instantiate(PlayerControl.Instance.fireBall, transform, rotation);
        listFireBallPool.Add(fBN);
        return fBN;

        /*var fBN = Instantiate(PlayerControl.Instance.fireBall, transform, rotation);
        listFireBallPool.Add(fBN);*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == PlayerControl.Instance.magicWeapon.transform.name)
        {
            FireBallMove fireBallMove= GetFromBool( transform.position, transform.rotation).GetComponent<FireBallMove>();
            if(fireBallMove.gameObject.activeInHierarchy)
                fireBallMove.Init();
        }
    }
}
