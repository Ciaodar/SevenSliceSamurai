using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public GameObject enemybir;
    public GameObject enemyiki;
    public GameObject enemyuc;
    public void changeIntoScene(string name)
    {
        SceneManager.LoadScene("name");
    }

    private void Start()
    {
        PlayerPrefs.SetInt("ilk",0);
        PlayerPrefs.SetInt("ikinci",0);
        PlayerPrefs.SetInt("ucunuc",0);
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("ilk") == 0)
        {
            enemybir.SetActive(true);
        }
        else
        {
            enemybir.SetActive(false);
        }
        
        if (PlayerPrefs.GetInt("ikinci") == 0)
        {
            enemyiki.SetActive(true);
        }
        else
        {
            enemyiki.SetActive(false);
        }
        
        if (PlayerPrefs.GetInt("ucuncu") == 0)
        {
            enemyuc.SetActive(true);
        }
        else
        {
            enemyuc.SetActive(false);
        }
        
    }
}
