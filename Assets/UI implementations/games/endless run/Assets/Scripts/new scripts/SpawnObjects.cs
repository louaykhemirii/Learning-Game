using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
	public GameObject ToSpawn;
	public GameObject Player;
	public GameObject newObject;
	public GameObject[] Objects = new GameObject[6];

	public string[] tags = { "Spawn1", "Spawn2", "Spawn3" };
	public string randomTag = "Spawn1";

	void Start()
    {
		Objects[0] = GameObject.Find("Banana");
		Objects[1] = GameObject.Find("Blue");
		Objects[2] = GameObject.Find("Green");
		Objects[3] = GameObject.Find("Stone");
		Objects[4] = GameObject.Find("LowBarrier");
		Objects[5] = GameObject.Find("HighBarrier");

		StartCoroutine(SpawnObjectCounter());
		StartCoroutine(SpawnBarrier());
	}
    
	public IEnumerator SpawnObjectCounter()
	{
		while (true)
		{
			if (PlayerManager2.isGameStarted && gameObject.CompareTag(randomTag) && (int)transform.position.z != 64)
			{
				int Index = Random.Range(0, 4);
				newObject = Instantiate(Objects[Index], transform.position, Quaternion.identity);
				Destroy(newObject, 6f);
			}
			randomTag = tags[Random.Range(0, tags.Length)];
			yield return new WaitForSeconds(2f);
		}
	}

	public IEnumerator SpawnBarrier()
	{
		while (true)
		{
			if (PlayerManager2.isGameStarted && gameObject.CompareTag("Spawn1") && (int)transform.position.z != 64)
			{
				int Index = Random.Range(4, 6);
				newObject = Instantiate(Objects[Index], transform.position, Quaternion.identity);
				Destroy(newObject, 6f);
			}
			yield return new WaitForSeconds(3f);
		}
	}

	
}
