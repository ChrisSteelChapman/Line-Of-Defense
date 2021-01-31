﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BootToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Out");
    }

    IEnumerator Out()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);   
    }
}
