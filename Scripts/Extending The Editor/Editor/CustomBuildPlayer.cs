using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;

public class CustomBuildPlayer
{
    // Output the build size or a failure depending on BuildPlayer.
    [MenuItem("Build/Build Current Scene")]
    public static void BuildCurrentScene()
    {
        string path = EditorUtility.SaveFolderPanel("Build Folder", "", "");

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Prototype/Scenes/Prototype Scene.unity" };

        buildPlayerOptions.locationPathName = path + "/BuiltGame.app";
        buildPlayerOptions.target = BuildTarget.StandaloneOSX;
        buildPlayerOptions.options = BuildOptions.Development;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            float buildSize = summary.totalSize / 1000; //Convert from bytes to kilobytes
            buildSize /= 1000; //Convert from kilobytes to megabytes

            Debug.Log($"Build succeeded: {buildSize} mb");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
        }
    }
}


/*    [MenuItem("Build/Build MacOSX")]
    public static void BuildGame()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.locationPathName = "MacBuild";

        //If levels in BuildPlayerOptions is left empty, then the current open Scene will be Built.
        // buildPlayerOptions.scenes = new[] { "Assets/Scene1", "Assets/Scene2" };

        buildPlayerOptions.target = BuildTarget.StandaloneOSX;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log($"Build Succeeded: {summary.totalSize} bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build Failed");
        }

        #region  Example
        /*
        using System.Diagnostics;

        //Get filename.
        string path = EditorUtility.SaveFolderPanel("Game Folder", "", "");

        //Get Scenes
        string[] levels = new string[]{ "Assets/Scene1", "Assets/Scene2" };

        //Build player.
        BuildPipeline.BuildPlayer(levels, path + "/BuiltGame.exe", BuildTarget.StandaloneOSX, BuildOptions.None);

        // Copy a file from the project folder to the build folder, alongside the built game.
        FileUtil.CopyFileOrDirectory("Assets/Templates/Readme.txt", path + "Readme.txt");

        // Run the game (Process class from System.Diagnostics).
        Process proc = new Process();
        proc.StartInfo.FileName = path + "/BuiltGame.exe";
        proc.Start(); 
        #endregion
        */
