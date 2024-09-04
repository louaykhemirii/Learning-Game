using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introAnimation : MonoBehaviour
{
	public GameObject Hero;
	public GameObject Eclipse;
	public GameObject ToHideHero;

	public Transform HeroTransform;
	public Transform EclipseTransform;
	public Transform ToHideHeroTransform;

	public Vector3 Starting;
	public Vector3 Ending;
	public Vector3 Ending2;

	public float ScreenX;
	public float ScreenY;

	void Start()
	{
		EclipseTransform = Eclipse.GetComponent<Transform>();
		ToHideHeroTransform = ToHideHero.GetComponent<Transform>();
		ScreenX = ((float)Screen.width / 1080);//calculating relative screen size to make it responsive
		ScreenY = ((float)Screen.height/ 1920);//calculating relative screen size to make it responsive
		StartCoroutine(MoveObject());
		
	}

	private IEnumerator MoveObject()
	{   
		Starting = EclipseTransform.position;
		Ending = Vector3.zero + new Vector3(540f * ScreenX, 700f * ScreenY, 0f);
		float elapsedTime = 0f;
		yield return new WaitForSeconds(0.75f);
		//moving the circle
		while (elapsedTime < 2f)
		{
			EclipseTransform.position = Vector3.Lerp(Starting, Ending, elapsedTime / 2f);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		EclipseTransform.position = Ending;//assuring position is good
		ToHideHeroTransform.position = Ending;
		//preparing for hero movement
		ToHideHero.SetActive(true);
		elapsedTime = 0f;
		Starting = HeroTransform.position;
		Ending = Vector3.zero + new Vector3(540f * ScreenX, 1050f * ScreenY, 0f);

		//moving the hero
		yield return new WaitForSeconds(1f);
		while (elapsedTime < 0.5f)
		{
			HeroTransform.position = Vector3.Lerp(Starting, Ending, elapsedTime / 0.5f);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		ToHideHero.SetActive(false);
		HeroTransform.position = Ending;//assuring position is good
		yield return new WaitForSeconds(3f);//waiting 3 seconds before going to the next scene
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//must fix this to load a scene depends on last active scene !
	}
}
