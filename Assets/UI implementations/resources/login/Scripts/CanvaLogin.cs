using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvaLogin : MonoBehaviour
{
	public GameObject canva1;
	public GameObject canva2;
	/*public GameObject canva3;
	public GameObject canva4;*/

	public void toCanvas1()
	{
		canva1.SetActive(true);
		canva2.SetActive(false);
		/*canva3.SetActive(false);
		canva4.SetActive(false);*/
	}
	public void toCanvas2()
	{
		canva1.SetActive(false);
		canva2.SetActive(true);
		/*canva3.SetActive(false);
		canva4.SetActive(false);*/
	}
	/*public void toCanvas3()
	{
		canva1.SetActive(false);
		canva2.SetActive(false);
		canva3.SetActive(true);
		canva4.SetActive(false);
	}
	public void toCanvas4()
	{
		canva1.SetActive(false);
		canva2.SetActive(false);
		canva3.SetActive(false);
		canva4.SetActive(true);
	}*/
	public void LoggingIn()
	{
		Debug.Log("insert here LoggingIn logic");
	}
}
