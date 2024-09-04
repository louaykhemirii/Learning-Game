using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MemorycardScript : MonoBehaviour {
	public float rotationSpeed = 180f;
	public float targetAngle = 180f;
	public static bool DO_NOT = false;
	
	[SerializeField]
	private int _state;
	[SerializeField]
	private int _cardValue;
	[SerializeField]
	private bool _initialized = false;

	private Sprite _cardBack;
	private Sprite _cardFace;

	private GameObject _manager;

	void Start(){
		_state = 1;
		_manager = GameObject.FindGameObjectWithTag ("Manager");
	}

	public void setupGraphics() {
		_cardBack = _manager.GetComponent<MemorygameManager> ().getCardBack ();
		_cardFace = _manager.GetComponent<MemorygameManager> ().getCardFace (_cardValue);

		flipcard ();
	}

	public void flipcard() {
		if (_state == 0)
			_state = 1;
		else if (_state == 1)
			_state = 0;

		if (_state == 0 && !DO_NOT)
		{
			//GetComponent<Image>().sprite = _cardBack;
			RotateObject(0f);
			StartCoroutine(FlipCardToBack());
		}
		else if (_state == 1 && !DO_NOT)
		{
			//GetComponent<Image>().sprite = _cardFace;
			RotateObject(180f);
			StartCoroutine(FlipCardAfterDelay());
		}
	}

	private IEnumerator FlipCardAfterDelay()
	{
		
		yield return new WaitForSeconds(0.5f); // Delay for 0.5 seconds

		GetComponent<Image>().sprite = _cardFace;
	}
	private IEnumerator FlipCardToBack()
	{

		yield return new WaitForSeconds(0.5f); // Delay for 0.5 seconds

		GetComponent<Image>().sprite = _cardBack;
	}
	public void RotateObject(float angle_y)
	{
		StartCoroutine(RotateObjectCoroutine(angle_y));
	}

	private IEnumerator RotateObjectCoroutine(float angle_y)
	{
		Quaternion startRotation = transform.rotation;
		Quaternion endRotation = Quaternion.Euler(0f, angle_y, 0f);
		float elapsedTime = 0f;

		while (elapsedTime < 1f)
		{
			elapsedTime += Time.deltaTime;
			float t = Mathf.Clamp01(elapsedTime / 1f);

			// Interpolate the rotation between start and end rotation
			transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);

			yield return null;
		}
	}
	public int cardValue {
		get { return _cardValue; }
		set { _cardValue = value; }
	}

	public int state {
		get { return _state; }
		set { _state = value; }
	}

	public bool initialized {
		get { return _initialized; }
		set { _initialized = value; }
	}

	public void falseCheck() {
		StartCoroutine (pause ());
	}

	IEnumerator pause() {
		yield return new WaitForSeconds(1F);
		if (_state == 0)
		//GetComponent<Image>().sprite = _cardBack;
		{
			RotateObject(0f);
			StartCoroutine(FlipCardToBack());
		}
		else if (_state == 1)
		//GetComponent<Image>().sprite = _cardFace;
		{
			RotateObject(180f);
			StartCoroutine(FlipCardAfterDelay());
		}
		DO_NOT = false;
	}
}
