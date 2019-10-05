using System;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Valve.VR;

public class LoadLevelEvent : OuterRimStudios.Event
{
    public SteamVR_LoadLevel steamLevelLoader;
    public bool loadLevel;
    public GameObject canvasIndicator;

    public override void StartEvent()
    {
        if (loadLevel)
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            steamLevelLoader?.Trigger(sceneIndex);
        }
        else
        {
            steamLevelLoader.Fade();
            StartCoroutine(EnableCanvasIndicator());
        }
    }

    IEnumerator EnableCanvasIndicator()
    {
        yield return new WaitForSeconds(steamLevelLoader.fadeOutTime);
        SceneLoader.Instance?.LoadExecutable(0);
        canvasIndicator.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Home))
            steamLevelLoader?.Trigger(0);
        else if (Input.inputString.Length != 0)
        {
            /*
            for (int i = 0; i < sceneManifest.Count; i++)
            {
                if (Input.inputString[0].ToString() == sceneManifest[i].sceneIndex.ToString())
                {
                    try
                    {
                        Process newScene = new Process();
                        newScene.StartInfo.FileName = rootPath + sceneManifest[i].folderName + SceneManifest.BUILD_NAME;
                        newScene.Start();
                        Application.Quit();
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(e);
                    }
                }
            }
            */
            try
            {
                int sceneIndex = Convert.ToInt32(Input.inputString[0].ToString()) - 1;
                if (SceneManager.GetSceneByBuildIndex(sceneIndex) != null)
                {
                    steamLevelLoader?.Trigger(sceneIndex);
                    //SceneManager.LoadScene(sceneIndex);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}