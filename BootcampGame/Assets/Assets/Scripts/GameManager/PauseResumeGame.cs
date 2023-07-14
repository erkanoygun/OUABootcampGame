using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResumeGame : MonoBehaviour
{
    [SerializeField] GameObject pausePop,Hint,setting;

    public void Pause()
    {
        pausePop.SetActive(true);
        Time.timeScale = 0;
    } 
    public void Resume()
    {
        pausePop.SetActive(false);
        Time.timeScale = 1;
    }
    public void HintOpen()
    {
        pausePop.SetActive(false);
        Hint.SetActive(true);
        Time.timeScale = 0;
    }
    public void HintClose()
    {
        Hint.SetActive(false);
        Time.timeScale = 1;
    }
    public void SettingOpen()
    {
        setting.SetActive(true);
        Time.timeScale = 0;
    }
    public void SettingClose()
    {
        setting.SetActive(false);
        Time.timeScale = 1;
    }
   
}
