using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<UIManager>();
            return instance;
        }
    }

    [Header("==MainUI==")]
    public Button buttonSetting;

    public Text textLevel;

    public Image imageEXP;

    public Image imageHP;

    public Text textHP;

    public HomeUI homeUI;

    [Header("==UpdateUI==")]

    public GameObject UpdateUI;

    public Button buttonUpdate1;

    public Text textButtonUpdate1;

    public Button buttonUpdate2;

    public Text textButtonUpdate2;

    public Button buttonUpdate3;

    public Text textButtonUpdate3;


    [Header("==SettingUI==")]
    public GameObject settingUI;

    public Button buttonReset;

    public Button buttonResum;

    public SettingUI ScriptSettingUI;

    [Header("==data==")]
    public DataBasic data;

    [HideInInspector]
    public int Level;

    [HideInInspector]
    public float eXP;

    [HideInInspector]
    public float maxEXP;

    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = 60;
        Level = data.level;
        eXP = data.eXP;
        maxEXP = data.maxEXP;
        PlayerControl.Instance.HPPlayer = data.hP;
        PlayerControl.Instance.MaxHPPlayer = data.hP;
        PlayerControl.Instance.damgeSword = data.damgeSword;
        PlayerControl.Instance.spawnFireBall.damgeMagic = data.dameMagic;
        HPPlayer hPPlayer = GameData.hPPlayer();
        MaxHPPlayer maxHPPlayer = GameData.MaxHPPlayer();
        DamgeSword damgeSword = GameData.damgeSword();
        DamgeMagic damgeMagic = GameData.damgeMagic();
        SpeedSpawnMagicBall speedSpawnMagicBall = GameData.speedSpawnMagicBall();
        SpeedMagicBall speedMagicBall = GameData.speedMagicBall();
        LevelPlayer levelPlayer = GameData.levelPlayer();
        ExpPlayer expPlayer = GameData.expPlayer();
        if (hPPlayer != null)
        {
            PlayerControl.Instance.HPPlayer
                = hPPlayer.GetHP();
        }
        if (maxHPPlayer != null)
        {
            PlayerControl.Instance.MaxHPPlayer = maxHPPlayer.GetMaxHP();
        }
        if (damgeSword != null)
        {
            PlayerControl.Instance.damgeSword = damgeSword.GetDamge();
        }
        if (damgeMagic != null)
        {
            PlayerControl.Instance.spawnFireBall.damgeMagic = damgeMagic.GetDamge();
        }
        if (speedSpawnMagicBall != null)
        {
            PlayerControl.Instance.spawnFireBall.fireRateFireBall = speedSpawnMagicBall.GetSpeed();
        }
        if (speedMagicBall != null)
        {
            PlayerControl.Instance.spawnFireBall.speedFireBall = speedMagicBall.GetSpeed();
        }
        if (levelPlayer != null)
        {
            Level = levelPlayer.GetLevel();
        }
        if (expPlayer != null)
        {
            eXP = expPlayer.GetExp();
        }


        

    }
    private void Start()
    {
        homeUI.ChangeLevel();
        homeUI.ChangeHP();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
