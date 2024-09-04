using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeCanvas : MonoBehaviour
{
	public Button[] buttons;

	public void EnableButtons()
	{
		foreach (Button button in buttons)
		{
			button.interactable = true;
			button.transition = Selectable.Transition.ColorTint;
		}
	}

}
