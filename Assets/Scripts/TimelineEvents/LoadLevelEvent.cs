﻿using System;
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

    public override void StartEvent()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        steamLevelLoader?.Trigger(sceneIndex);
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

public class SceneManifest
{
    public const string BUILD_NAME = "/Build.exe";

    public static void CreateSceneManifest(List<string> folderNames, string manifestPath)
    {
        List<SceneInfo> sceneInfoList = new List<SceneInfo>();
        for (int i = 0; i < folderNames.Count; i++)
        {
            //Debug.Log(folderNames[i]);
            sceneInfoList.Add(new SceneInfo(i + 1, folderNames[i]));
        }

        XMLOp.Serialize(sceneInfoList, manifestPath + "/SceneManifest.xml");
    }
}

public class SceneInfo
{
    public int sceneIndex;
    public string folderName;

    public SceneInfo()
    {
        sceneIndex = -1;
        folderName = "";
    }
    public SceneInfo(int _sceneIndex, string _folderName)
    {
        sceneIndex = _sceneIndex;
        folderName = _folderName;
    }
}