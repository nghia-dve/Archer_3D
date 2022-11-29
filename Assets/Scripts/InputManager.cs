using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;

    public static InputManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<InputManager>();
            return instance;
        }
    }
    [Header("==joystick==")]
    [SerializeField]
    private FloatingJoystick joyStick;

    private Vector3 joyStickDirection;
    public Vector3 JoyStickDirection { get { return joyStickDirection; } }

    // Update is called once per frame
    void Update()
    {
        _GetJoyStickDir();
    }

    private void _GetJoyStickDir()
    {
        joyStickDirection = new Vector3(joyStick.Horizontal, 0, joyStick.Vertical);
    }

}
