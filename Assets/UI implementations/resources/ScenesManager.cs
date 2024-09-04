using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
	private void Start()
	{
		string sceneName = SceneManager.GetActiveScene().name;
		SetSceneOrientation(sceneName);
	}

	public void StartScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
		SetSceneOrientation(sceneName);
	}

	public void restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void toIntro()
	{
		SceneManager.LoadScene("Intro");
		SetSceneOrientation("Intro");
	}

	public void toWelcome()
	{
		SceneManager.LoadScene("Welcome");
		SetSceneOrientation("Welcome");
	}

	public void toCreateAccount()
	{
		SceneManager.LoadScene("createAccount");
		SetSceneOrientation("createAccount");
	}

	public void toLogin()
	{
		SceneManager.LoadScene("Login");
		SetSceneOrientation("Login");
	}

	public void toChooseChild()
	{
		SceneManager.LoadScene("ChooseChild");
		SetSceneOrientation("ChooseChild");
	} 
	public void toHome()
	{
		SceneManager.LoadScene("Home");
		SetSceneOrientation("Home");
	}

	public void toGames()
	{
		SceneManager.LoadScene("Games");
		SetSceneOrientation("Games");
	}

	public void toMathGame()
	{
		SceneManager.LoadScene("MathGame");
		SetSceneOrientation("MathGame");
	}
	
	public void toEndlessRun()
	{
		SceneManager.LoadScene("EndlessRun");
		SetSceneOrientation("EndlessRun");
	}

	public void to2048()
	{
		SceneManager.LoadScene("2048");
		SetSceneOrientation("2048");
	}

	public void topuzzleGame()
	{
		SceneManager.LoadScene("puzzleGame");
		SetSceneOrientation("puzzleGame");
	}

	public void toProfileManager()
	{
		SceneManager.LoadScene("ProfileManager");
		SetSceneOrientation("ProfileManager");
	}

	private void SetSceneOrientation(string sceneName)
	{
		// Set the orientation based on the scene name
		switch (sceneName)
		{
			case "Intro":
			case "Welcome":
			case "createAccount":
			case "Login":

				Screen.orientation = ScreenOrientation.Portrait;
				Screen.autorotateToLandscapeLeft = false;
				Screen.autorotateToLandscapeRight = false;
				Screen.autorotateToPortrait = false;
				Screen.autorotateToPortraitUpsideDown = false;

				break;
			case "Home":
			case "Games":
			case "ChooseChild":
			case "ProfileManager":
			case "MathGame":
			case "EndlessRun":
			case "puzzleGame":
			case "2048":

				Screen.orientation = ScreenOrientation.LandscapeLeft;
				Screen.autorotateToPortrait = false;
				Screen.autorotateToPortraitUpsideDown = false;
				Screen.autorotateToLandscapeLeft = false;
				Screen.autorotateToLandscapeRight = false;

				break;
			default:

				Screen.orientation = ScreenOrientation.AutoRotation;
				break;

		}
		
	}
}
