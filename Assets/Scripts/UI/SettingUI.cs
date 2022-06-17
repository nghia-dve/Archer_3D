using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.buttonReset.onClick.AddListener(ResetGame);
        UIManager.Instance.buttonResum.onClick.AddListener(ResumGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
        GameData.SaveDataDamgeMagicdPlayer(1);
        GameData.SaveDataDamgeSwordPlayer(2);
        GameData.SaveDataExpPlayer(0);
        GameData.SaveDataHPPlayer(100);
        GameData.SaveDataLevelPlayer(1);
        GameData.SaveDataMaxHPPlayer(100);
        GameData.SaveDataSpeedMagicBall(2);
        GameData.SaveDataSpeedSpawnMagicBall(1);
    }



    public void ResumGame()
    {
        Time.timeScale = 1;
        UIManager.Instance.settingUI.SetActive(false);
    }

    public void NextLevel()
    {
        StartCoroutine(Loading(SceneManager.GetActiveScene().buildIndex+1));
    }

    IEnumerator Loading(int sceneIndex)
    {

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        if (asyncOperation != null)
        {
            //asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
            while (!asyncOperation.isDone)
            {
                float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);

                if (progress >= 1f)
                {

                }
                yield return null;
            }
            if (asyncOperation.isDone)
            {
                Debug.LogError("done");
            }
        }
        if (asyncOperation == null)
        {
            asyncOperation = SceneManager.LoadSceneAsync(0);
            while (!asyncOperation.isDone)
            {
                float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);

                if (progress >= 1f)
                {

                }
                yield return null;
            }

        }
    }

}
