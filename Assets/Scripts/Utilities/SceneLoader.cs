using System;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Valve.VR;

public class SceneLoader : MonoBehaviour
{
    public SteamVR_LoadLevel steamLevelLoader;
    string rootPath;
#if UNITY_STANDALONE
    List<SceneInfo> sceneManifest = new List<SceneInfo>();
    void Start()
    {
        string dataPath = Application.dataPath;
        int slashCount = 0;
        int finalPathLength = 0;
        for (int i = dataPath.Length - 1; i > 0; i--)
        {
            if (dataPath[i] == '/')
                slashCount++;

            if (slashCount == 1)
                finalPathLength = i;
        }

        rootPath = dataPath.Substring(0, finalPathLength);
        if (File.Exists(rootPath + "/SceneManifest.xml"))
            sceneManifest = XMLOp.Deserialize<List<SceneInfo>>(rootPath + "/SceneManifest.xml");
    }
#endif

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