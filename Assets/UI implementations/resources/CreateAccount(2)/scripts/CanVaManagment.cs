using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanVaManagment : MonoBehaviour
{
    public GameObject canva1;
    public GameObject canva2;
	public GameObject canva3;
	public GameObject canva4;
	public GameObject canva5;
	public GameObject canva6;

	public int canvasID = 0;

	public GameObject[] days = new GameObject[6];
	public GameObject[] months = new GameObject[6];
	public GameObject[] years = new GameObject[6];
	public Text day;
	public Text month;
	public Text year;


	public void toCanvas1()
	{
		canva1.SetActive(true);
		canva2.SetActive(false);
		canva4.SetActive(false);
	}
	public void toCanvas2()
	{
		canva2.SetActive(true);
		canva1.SetActive(false);
		canva3.SetActive(false);
	}
	public void toCanvas3()
	{
		canva3.SetActive(true);
		canva2.SetActive(false);
		canva4.SetActive(false);
	}
	public void toCanvas4()
	{
		canva4.SetActive(true);
		canva1.SetActive(false);
		canva3.SetActive(false);
		canva5.SetActive(false);
	}
	public void toCanvas5()
    {
		
		canva5.SetActive(true);
		canva4.SetActive(false);
		canva6.SetActive(false);
	}
	public void toCanvas6()
    {
		canvasID = 0;
		CheckDate(canvasID);
		canva6.SetActive(true);
        canva5.SetActive(false);

	}
	public void CreateAccount()
	{
		canvasID = 3;
		CheckDate(canvasID);
		Debug.Log("insert here creation logic");
	}

	public void CheckDate(int ID)
	{
		CheckActiveDateElements(ID);
		if (month.text == "2")
		{
			int yearValue;
			int.TryParse(year.text, out yearValue);
			if (yearValue % 4 == 0)
			{
				Debug.Log("29 day month");
			}
			else
			{
				Debug.Log("28 day month");
			}
		}
		else if ((month.text == "4") || (month.text == "6") || (month.text == "9") || (month.text == "11"))
		{
			Debug.Log("30 day month");
		}
		else
		{
			Debug.Log("31 day month");
		}

		Debug.Log("your birth date is"+day.text+"/"+month.text + "/" + year.text);
	}//this code will control the date insertion

	public void CheckActiveDateElements(int ID)
	{
		for (int i = ID; i < 3+ID; i++)
		{
			if (days[i].transform.position.y < 400 && days[i].transform.position.y > 350)
			{
				day = days[i].GetComponentInChildren<Text>();
			}
			if (months[i].transform.position.y < 400 && months[i].transform.position.y > 350)
			{
				month = months[i].GetComponentInChildren<Text>();
			}
			if (years[i].transform.position.y < 400 && years[i].transform.position.y > 350)
			{
				year = years[i].GetComponentInChildren<Text>();
			}
		}
	}//this code will check when to get elements from canvas 2 or canvas 3
}	
