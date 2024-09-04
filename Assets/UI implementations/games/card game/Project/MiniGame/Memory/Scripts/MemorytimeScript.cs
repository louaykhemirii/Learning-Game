using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MemorytimeScript : MonoBehaviour {
	
	[SerializeField] GameObject winner_UI;
	[SerializeField] GameObject Loser_UI;
	public Text counterText;
	public bool timeCounter = true;
	public float seconds, minutes;
	[SerializeField] int Game_limit = 10;
	private int GameTime;
	// Use this for initialization
	void Start () {
		counterText = GetComponent<Text> () as Text;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeCounter) {
			seconds = (int)(Time.timeSinceLevelLoad);
			GameTime = Game_limit - (int)seconds;
			
			if(GameTime<1)
            {
				counterText.text = "00";
				counterText.color = Color.yellow;
				timeCounter = false;
				StartCoroutine(you_lose());
				
            }
			counterText.text =  GameTime.ToString ("00");
		}
	}

	public void endGame() {
		timeCounter = false;
		counterText.color = Color.yellow;
		StartCoroutine(winner_diplay());
		
	}
	public IEnumerator winner_diplay()
    {
		yield return new WaitForSeconds(1f);
		winner_UI.SetActive(true);
	}
	public IEnumerator you_lose()
	{
		yield return new WaitForSeconds(1.5f);
		Loser_UI.SetActive(true);
	}
}
