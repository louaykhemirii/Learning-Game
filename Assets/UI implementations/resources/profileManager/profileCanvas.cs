using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class profileCanvas : MonoBehaviour
{
	public GameObject canva1;
	public GameObject canva2;
	public GameObject canva3;

	public void toCanvas1()
	{
		canva1.SetActive(true);
		canva2.SetActive(false);
		canva3.SetActive(false);
	}
	public void toCanvas2()
	{
		canva1.SetActive(false);
		canva2.SetActive(true);
		canva3.SetActive(false);
	}
	public void toCanvas3()
	{
		canva1.SetActive(false);
		canva2.SetActive(false);
		canva3.SetActive(true);
	}
}
