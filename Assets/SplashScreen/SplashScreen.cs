using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// Simple Splash Screen for Unity
// No copyright asserted on this code or included files.  They may be used for any purpose.
// See http://apps.burlock.org/unity-splash-screen/ for instructions on how to use this class
// Written by Neil Burlock
// Version 1.0, 09 Jun 2014

public class SplashScreen : MonoBehaviour {
	public string loadLevelName; // Name of the level to load after the splash screen appears
	private bool isLoading = false;
    public int loadingTime = 2;

    public Texture textureRu;
    public Texture textureEn;
    private GUITexture image;

	public static SplashScreen me;
	void Awake() {
		me = this;
	}
	
	void Start () {
		// Adjust the width of the image to fill the screen while maintaining the image aspect ratio
        if (Application.systemLanguage == SystemLanguage.Russian)
        {
            gameObject.GetComponent<GUITexture>().texture = textureRu;
            image = gameObject.GetComponent<GUITexture>();
        } else
        {
            gameObject.GetComponent<GUITexture>().texture = textureEn;
            image = gameObject.GetComponent<GUITexture>();
        }
		float imageRatio = image.texture.width /image.texture.height;
		float screenRatio =  Screen.width / Screen.height;
		Vector3 scale = Vector3.one;
		if (Screen.width >= Screen.height) scale.x *= imageRatio / screenRatio;
		else scale.y *= screenRatio / imageRatio;
		transform.localScale = scale;
	}
	
	void Update() {
		// Start loading the level on the next frame
		if (!isLoading) {
            isLoading = true;
            StartCoroutine(WaitForLoading(loadingTime));
            new WaitForSeconds(loadingTime);
		}
	}	
	
    IEnumerator WaitForLoading (int loadingTime)
    {
        yield return new WaitForSeconds(loadingTime);
        SceneManager.LoadScene(me.loadLevelName);
    }

	// Call from the loaded level to hide the splash
	public static void Hide() {
		if (me != null) me.gameObject.SetActive(false);
	}
}
