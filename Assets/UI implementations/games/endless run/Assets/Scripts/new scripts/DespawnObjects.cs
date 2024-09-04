using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnObjects : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("test collider");
		Destroy(other.gameObject);
	}
}
