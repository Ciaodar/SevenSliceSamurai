using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twodeeenemy : MonoBehaviour
{
    public sceneManager mySceneManager;
    public string sceneWantedToLoad;

    void OnTriggerEnter(Collider other)
    {
        mySceneManager.changeIntoScene(sceneWantedToLoad);
    }
}
