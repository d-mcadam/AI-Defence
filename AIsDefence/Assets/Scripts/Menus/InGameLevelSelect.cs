﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameLevelSelect : MonoBehaviour {

    [SerializeField]
    private AudioSource _Sound;

    public void ToScene(string scene)
    {
        StartCoroutine(Delay(scene));
    }

    private IEnumerator Delay(string scene)
    {
        Time.timeScale = 1;
        _Sound.Play();

        yield return new WaitForSeconds(0.3f);

        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void Restart()
    {
        //This is so in the future instead of recalling the scene
        //the level parameters will just reset
    }
}
