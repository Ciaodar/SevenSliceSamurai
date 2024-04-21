using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class canvasScript : MonoBehaviour
{
   public GameObject siyah;
   public GameObject hikaye;
   
   public void Quit()
   { 
      Application.Quit();
   }

   public void Load()
   {
      siyah.SetActive(true);
      
      //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   private void Update()
   {
      if (hikaye.activeSelf && Input.GetKeyDown(KeyCode.Space))
      {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      }
   }
}
