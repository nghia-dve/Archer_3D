using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : MonoBehaviour
{
    [HideInInspector]
    public List<string> listRandomUpdate = new List<string>();

    public float ratio;

    private void Start()
    {
        UIManager.Instance.buttonUpdate1.onClick.AddListener(UpdatePlayer1);
        UIManager.Instance.buttonUpdate2.onClick.AddListener(UpdatePlayer2);
        UIManager.Instance.buttonUpdate3.onClick.AddListener(UpdatePlayer3);
        UIManager.Instance.buttonSetting.onClick.AddListener(OpenSettingUI);
        AddListRandom();
    }

    public void ChangeHP()
    {
        UIManager.Instance.textHP.text =$"{PlayerControl.Instance.HPPlayer}";
        UIManager.Instance.imageHP.fillAmount = PlayerControl.Instance.HPPlayer / PlayerControl.Instance.MaxHPPlayer;
        GameData.SaveDataHPPlayer((int)PlayerControl.Instance.HPPlayer);
        GameData.SaveDataMaxHPPlayer((int)PlayerControl.Instance.MaxHPPlayer);
    }

    public void ChangeLevel()
    {
        UIManager.Instance.imageEXP.fillAmount = UIManager.Instance.eXP/UIManager.Instance.maxEXP;
        if (UIManager.Instance.eXP >= UIManager.Instance.maxEXP)
        {
            UIManager.Instance.Level++;
            UIManager.Instance.textLevel.text = $"Level {UIManager.Instance.Level}";
            UIManager.Instance.maxEXP += 10;
            UIManager.Instance.UpdateUI.SetActive(true);
            UIManager.Instance.eXP = 0;
            RandomUpdate();
            GameData.SaveDataLevelPlayer(UIManager.Instance.Level);
            GameData.SaveDataExpPlayer(UIManager.Instance.eXP);
        }
        else
        {
            UIManager.Instance.textLevel.text = $"Level {UIManager.Instance.Level}";
        }
    }

    public void UpdatePlayer1()
    {
        UpdatePlayer(UIManager.Instance.textButtonUpdate1);
        Time.timeScale = 1;
        ChangeLevel();
    }
    public void UpdatePlayer2()
    {
        UpdatePlayer(UIManager.Instance.textButtonUpdate2);
        Time.timeScale = 1;
        ChangeLevel();
    }
    public void UpdatePlayer3()
    {
        UpdatePlayer(UIManager.Instance.textButtonUpdate3);
        Time.timeScale = 1;
        ChangeLevel();
    }

    public void UpdatePlayer(Text text)
    {
        
        UIManager.Instance.UpdateUI.SetActive(false);
        switch (text.text)
        {
            case "Update DMG Sword":
                PlayerControl.Instance.damgeSword += 0.2f;
                GameData.SaveDataDamgeSwordPlayer(PlayerControl.Instance.damgeSword);
                break;
            case "Update DMG Magic":
                PlayerControl.Instance.spawnFireBall.damgeMagic += 0.1f;
                GameData.SaveDataDamgeMagicdPlayer(PlayerControl.Instance.spawnFireBall.damgeMagic);
                break;
            case "Update Speed Spawn Magic Ball":
                PlayerControl.Instance.spawnFireBall.fireRateFireBall += 1;
                GameData.SaveDataSpeedSpawnMagicBall((int)PlayerControl.Instance.spawnFireBall.fireRateFireBall);
                break;
            case "Update Speed Magic Ball":
                PlayerControl.Instance.spawnFireBall.speedFireBall += 0.3f;
                GameData.SaveDataSpeedMagicBall(PlayerControl.Instance.spawnFireBall.speedFireBall);
                break;
            case "Update HP":
                UpdateRatioHPPlayer();
                PlayerControl.Instance.MaxHPPlayer += 10;
                PlayerControl.Instance.HPPlayer =Mathf.Round(PlayerControl.Instance.MaxHPPlayer * ( ratio));
                ChangeHP();
                break;
            case "healing":
                PlayerControl.Instance.HPPlayer = PlayerControl.Instance.MaxHPPlayer;
                ChangeHP();
                break;
            default:
                break;
        }
    }

    private void UpdateRatioHPPlayer()
    {
        ratio = PlayerControl.Instance.HPPlayer / PlayerControl.Instance.MaxHPPlayer;
    }

    public void AddListRandom()
    {
        listRandomUpdate.Add("Update DMG Sword");
        listRandomUpdate.Add("Update DMG Magic");
        listRandomUpdate.Add("Update Speed Spawn Magic Ball");
        listRandomUpdate.Add("Update Speed Magic Ball");
        listRandomUpdate.Add("Update HP");
        listRandomUpdate.Add("healing");
    }

    public void RandomUpdate()
    {
        Time.timeScale = 0;
        UIManager.Instance.textButtonUpdate1.text = RandomListRandom(Random.Range(0, 100));
        UIManager.Instance.textButtonUpdate2.text = RandomListRandom(Random.Range(0, 100));
        UIManager.Instance.textButtonUpdate3.text = RandomListRandom(Random.Range(0, 100));
    }

    public string RandomListRandom(int rd)
    {
        if (rd == 100)
        {
            return listRandomUpdate[2];
        }
        else
            if (rd > 90)
        {
            return listRandomUpdate[3];
        }
        else
            if (rd > 70)
        {
            return listRandomUpdate[1];
        }
        else
            if (rd > 50)
        {
            return listRandomUpdate[0];
        }
        else
            if (rd > 30)
        {
            return listRandomUpdate[4];
        }
        return listRandomUpdate[5];
    }

    public void OpenSettingUI()
    {
        Time.timeScale = 0;
        UIManager.Instance.settingUI.SetActive(true);
    }
}
