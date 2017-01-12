using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameLoader : MonoBehaviour {

    private bool loadScene = false;
	public GameObject[] loadingBar;
	private AsyncOperation async = null;

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
        async = Application.LoadLevelAsync("MainScene");;

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone) {
            yield return null;
        }

    }

	void OnGUI() {
		if (async != null) {
			if (async.progress >= 0.125f) {
				loadingBar [0].SetActive(true);
			}
			if (async.progress >= 0.250f) {
				loadingBar [1].SetActive(true);
			}

			if (async.progress >= 0.500f) {
				loadingBar [2].SetActive (true);
			}

			if (async.progress >= 0.625f) {
				loadingBar [3].SetActive (true);
			}

			if (async.progress >= 0.755f) {
				loadingBar [4].SetActive(true);
			}
			if (async.progress >= 0.95f) {
				loadingBar [5].SetActive(true);
			}

		}
	}

}