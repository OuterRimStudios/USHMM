using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildManager
{
    [MenuItem("Build Tools/Build")]
    public static void BuildProject()
    {
        //Get filename
        string path = EditorUtility.SaveFolderPanel("Choose Location of Built Game", "", "");
        List<string> levels = new List<string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            levels.Add(scene.path);

        //Build
        List<string> exePaths = new List<string>();
        foreach (string level in levels)
        {
            UnityEngine.Debug.Log(level);
            int sceneNameLength = level.Length - 19;    //the 19 comes from 'Assets/Scenes/' + '.unity' that are removed
            string folderName = level.Substring(13, sceneNameLength);
            string exePath = path + folderName + "/Build.exe";
            exePaths.Add(exePath);
            BuildPipeline.BuildPlayer(new string[] { level }, exePath, BuildTarget.StandaloneWindows64, BuildOptions.Development);
        }

        //Create Scene Manifest
        SceneManifest.CreateSceneManifest(exePaths, path);
    }

    [MenuItem("Build Tools/Build and Run")]
    public static void BuildRunProject()
    {
        //Get filename
        string path = EditorUtility.SaveFolderPanel("Choose Location of Built Game", "", "");
        List<string> levels = new List<string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            levels.Add(scene.path);

        //Build
        List<string> exePaths = new List<string>();
        foreach (string level in levels)
        {
            string folderName = level.Substring(13);
            string exePath = path + folderName + "/Build.exe";
            exePaths.Add(exePath);
            BuildPipeline.BuildPlayer(new string[] { level }, exePath, BuildTarget.StandaloneWindows64, BuildOptions.Development);
        }

        //Create Scene Manifest
        SceneManifest.CreateSceneManifest(exePaths, path);

        //Run executable
        Process proc = new Process();
        proc.StartInfo.FileName = exePaths[0];
        proc.Start();
    }
}