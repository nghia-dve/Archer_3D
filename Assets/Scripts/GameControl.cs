using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private static GameControl instance;
    public static GameControl Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameControl>();
            return instance;
        }
    }

    [SerializeField]
    private GameObject player;
    public GameObject Player { get { return player; } }

    [SerializeField]
    private GameObject enemy;
    public GameObject Enemy { get { return enemy; } }
}
