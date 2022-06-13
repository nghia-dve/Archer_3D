using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    /*float speedCamera = -2f;*/
    public float TransitionSpeed;
    /*private Vector3 velocity;*/
    public Transform PlayerFollow;
    [SerializeField]
    public Vector3 Offset;

    private void Awake()
    {
        Offset = transform.position - PlayerFollow.transform.position;
    }

    private void LateUpdate()
    {
        /* velocity = transform.forward * -speedCamera * Time.deltaTime;
         transform.Translate(velocity);*/
        /*transform.position = Vector3.Lerp(transform.position,
        PlayerFollow.position + Offset, Time.deltaTime * TransitionSpeed);*/
        transform.position = new Vector3(transform.position.x, transform.position.y , Vector3.Lerp(transform.position,
        PlayerFollow.position + Offset, Time.deltaTime * TransitionSpeed).z);

    }

}
