using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyGirlChecking : MonoBehaviour
{
	public GameObject femaleON;
	public GameObject maleON;
	public GameObject femaleOFF;
	public GameObject maleOFF;

    public void hideMale()
    {
		if (gameObject.activeSelf)
		{
			maleON.SetActive(false);
			maleOFF.SetActive(true);
		}
	}
	public void selectMale()
	{
		if (gameObject.activeSelf)
		{
			maleON.SetActive(true);
			femaleOFF.SetActive(true);
			femaleON.SetActive(false);
			maleOFF.SetActive(false);
		}

	}
	public void hideFemale()
	{
		if (gameObject.activeSelf)
		{
			femaleON.SetActive(false);
			femaleOFF.SetActive(true);
		}
	}
	public void selectFemale()
	{
		if (gameObject.activeSelf)
		{
			femaleON.SetActive(true);
			maleON.SetActive(false);
			maleOFF.SetActive(true);
			femaleOFF.SetActive(false);
		}
	}
}
