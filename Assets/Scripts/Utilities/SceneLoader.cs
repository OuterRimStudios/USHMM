using System;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class SceneLoader : MonoBehaviour
{

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

        string mainfestPath = dataPath.Substring(0, finalPathLength);
        if (File.Exists(mainfestPath + "/SceneManifest.xml"))
        {
            sceneManifest = XMLOp.Deserialize<List<SceneInfo>>(mainfestPath + "/SceneManifest.xml");
            Debug.LogError("number of scenes: " + sceneManifest.Count);
            Debug.LogError("scene index: " + sceneManifest[0].sceneIndex + " | " + sceneManifest[0].executablePath);
        }
    }
#endif

    void Update()
    {
        if (Input.inputString.Length != 0)
        {
#if UNITY_STANDALONE
            for (int i = 0; i < sceneManifest.Count; i++)
            {
                if (Input.inputString[0].ToString() == sceneManifest[i].sceneIndex.ToString())
                {
                    try
                    {
                        Process newScene = new Process();
                        newScene.StartInfo.FileName = sceneManifest[i].executablePath;
                        newScene.Start();
                        Application.Quit();
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(e);
                    }
                }
            }
#endif
#if UNITY_EDITOR
            try
            {
                int sceneIndex = Convert.ToInt32(Input.inputString[0].ToString()) - 1;
                if (SceneManager.GetSceneByBuildIndex(sceneIndex) != null)
                    SceneManager.LoadScene(sceneIndex);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
#endif
        }
    }
}

public class SceneManifest
{
    public static void CreateSceneManifest(List<string> exePaths, string manifestPath)
    {
        List<SceneInfo> sceneInfoList = new List<SceneInfo>();
        for (int i = 0; i < exePaths.Count; i++)
            sceneInfoList.Add(new SceneInfo(i + 1, exePaths[i]));

        XMLOp.Serialize(sceneInfoList, manifestPath + "/SceneManifest.xml");
    }
}

public class SceneInfo
{
    public int sceneIndex;
    public string executablePath;

    public SceneInfo()
    {
        sceneIndex = -1;
        executablePath = "";
    }
    public SceneInfo(int _sceneIndex, string _executablePath)
    {
        sceneIndex = _sceneIndex;
        executablePath = _executablePath;
    }
}