using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numbersInserting : MonoBehaviour
{
	public Text[] textObjects = new Text[6];
	public int[] randomNumbers = new int[6];
	public Text ActiveText ;
	public int ActiveTextId = 0;
	System.Random random = new System.Random();

	string aux;
	string NumbertoInput;
	string InputResult;

	public GameObject canva;
	public GameObject canvaValid;
	public GameObject canvaNotValid;

	void Start()
	{
		generateRandom();
	}

	public void generateRandom()
	{
		NumbertoInput = "";
		InputResult = "";
		ActiveTextId = 0;
		for (int i = 0; i<6 ; i++)
		{
			randomNumbers[i]= random.Next(0, 10);
			textObjects[i].text = "";
			NumbertoInput += randomNumbers[i].ToString();
		}

		Debug.Log(NumbertoInput);

	}

	public void VerifyRandom()
	{
		for (int i = 0; i < 6; i++)
		{
			InputResult += textObjects[i].text;
		}
		if(NumbertoInput == InputResult) 
		{
			canva.SetActive(false);
			canvaValid.SetActive(true);
			canvaNotValid.SetActive(false);
		}
		else
		{
			canva.SetActive(false);
			canvaValid.SetActive(true); //rechange after building to false
			canvaNotValid.SetActive(false); //true
		}

	}

	public void add1() 
	{
		if (ActiveTextId >= 0 && ActiveTextId <= 5)
		{
			ActiveText = textObjects[ActiveTextId];
			ActiveTextId++;
			ActiveText.text += "1";
		}
	}
	public void add2() 
	{
		if (ActiveTextId >= 0 && ActiveTextId <= 5)
		{
			ActiveText = textObjects[ActiveTextId];
			ActiveTextId++;
			ActiveText.text += "2";
		}
	}
	public void add3() 
	{
		if (ActiveTextId >= 0 && ActiveTextId <= 5)
		{
			ActiveText = textObjects[ActiveTextId];
			ActiveTextId++;
			ActiveText.text += "3";
		}
	}
	public void add4() 
	{
		if (ActiveTextId >= 0 && ActiveTextId <= 5)
		{
			ActiveText = textObjects[ActiveTextId];
			ActiveTextId++;
			ActiveText.text += "4";
		}
	}
	public void add5() 
	{
		if (ActiveTextId >= 0 && ActiveTextId <= 5)
		{
			ActiveText = textObjects[ActiveTextId];
			ActiveTextId++;
			ActiveText.text += "5";
		}
	}
	public void add6() 
	{
		if (ActiveTextId >= 0 && ActiveTextId <= 5)
		{
			ActiveText = textObjects[ActiveTextId];
			ActiveTextId++;
			ActiveText.text += "6";
		}
	}
	public void add7() 
	{
		if (ActiveTextId >= 0 && ActiveTextId <= 5)
		{
			ActiveText = textObjects[ActiveTextId];
			ActiveTextId++;
			ActiveText.text += "7";
		}
	}
	public void add8() 
	{
		if (ActiveTextId >= 0 && ActiveTextId <= 5)
		{
			ActiveText = textObjects[ActiveTextId];
			ActiveTextId++;
			ActiveText.text += "8";
		}
	}
	public void add9() 
	{
		if (ActiveTextId >= 0 && ActiveTextId <= 5)
		{
			ActiveText = textObjects[ActiveTextId];
			ActiveTextId++;
			ActiveText.text += "9";
		}
	}
	public void add0() 
	{
		if(ActiveTextId>=0 && ActiveTextId<=5)
		{
			ActiveText = textObjects[ActiveTextId];
			ActiveTextId++;
			ActiveText.text += "0";
		}
		
	}
	public void remove()
	{
		if (ActiveTextId > 0 && ActiveTextId <= 6)
		{

			ActiveTextId--;
			ActiveText = textObjects[ActiveTextId];
			aux = ActiveText.text;
			aux = aux.Substring(0, aux.Length - 1);
			ActiveText.text = aux;
			
			
		}

	}
}
