using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cog : MonoBehaviour
{
    public GameObject cog;

    public bool checkMove;

    public float speed=2;

    public float DMGCog = 1;

    public float clampX;
    public float clamp_X;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x >= 0)
        {
            clampX = transform.position.x+2;
            clamp_X = transform.position.x-2;

        }
        if (transform.position.x < 0)
        {
            clampX = transform.position.x - 2;
            clamp_X = transform.position.x + 2;
        }

    }

    // Update is called once per frame
    void Update()
    {
        cog.transform.Rotate(0, 10, 0);
        if (checkMove)
        {
            Move();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerControl.Instance.GetHit(DMGCog);
        }
    }
    
    private void Move()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        if(clampX<clamp_X)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, clampX, clamp_X), transform.position.y, transform.position.z);
        }
        if (clampX > clamp_X)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, clamp_X, clampX), transform.position.y, transform.position.z);
        }
        if (transform.position.x == clampX || transform.position.x == clamp_X)
        {
            speed *= -1;
        }
       
    }
}
