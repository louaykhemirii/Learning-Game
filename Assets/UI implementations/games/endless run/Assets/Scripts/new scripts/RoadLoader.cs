using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLoader : MonoBehaviour
{
	public Vector3 position;
	public Transform parent;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("RoadCheck"))
		{
			parent = other.transform.parent;
			parent.position += new Vector3(0f, 0f, 200f);
		}
	}
}
