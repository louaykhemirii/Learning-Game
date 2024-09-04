using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPassword : MonoBehaviour
{
	public InputField field;
	public Toggle toggle;

	private void Start()
	{
		toggle.onValueChanged.AddListener(OnToggleValueChanged);
	}

	private void OnToggleValueChanged(bool isOn)
	{
		if (isOn)
		{
			field.contentType = InputField.ContentType.Standard;
		}
		else
		{
			field.contentType = InputField.ContentType.Password;
		}

		field.ForceLabelUpdate();
	}
}
