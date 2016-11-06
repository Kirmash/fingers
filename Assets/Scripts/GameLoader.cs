﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameLoader : MonoBehaviour {

    private bool loadScene = false;

    [SerializeField]
    private int scene;


    // Updates once per frame
    void Update() {

        // If the player has pressed the space bar and a new scene is not loading yet...
        if ( loadScene == false) {

            // ...set the loadScene boolean to true to prevent loading a new scene more than once...
            loadScene = true;
           

            // ...and start a coroutine that will load the desired scene.
            StartCoroutine(LoadNewScene());

        }

   

    }


    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    IEnumerator LoadNewScene() {

        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation async = Application.LoadLevelAsync("MainScene");;

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone) {
            yield return null;
        }

    }

}