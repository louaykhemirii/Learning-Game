using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Birdy : MonoBehaviour
{
    public float launchPow;

    private Vector3 initialPosition;
    private bool launched=false;
    private bool touched = false;
    private float timer;
    private Rigidbody2D rig;
    public Rigidbody2D rb;
	private Vector3 line2, line3;
    public LineRenderer Trajectory;
    [SerializeField] private GameObject birdy;
    [SerializeField] private GameObject wrongPanel;
    [SerializeField] private GameObject correctPanel;
	[SerializeField] private GameObject WinLoseCanvas;


	public Text scoreText;
    [SerializeField] int highScore;
	//[SerializeField] ScoreSystem ScoreSystem;

    private void Awake()
    {
        initialPosition = transform.position;
    }
    void Start()
	{
        //ScoreSystem = FindObjectOfType<ScoreSystem>();
        highScore = 0;
		scoreText.text = highScore + "";
	}
    private void Update()
    {
        
        GetComponent<LineRenderer>().SetPosition(1,initialPosition);
        GetComponent<LineRenderer>().SetPosition(0,transform.position);
        if (launched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1 )
        {
            timer += Time.deltaTime;
        }

        if (transform.position.y > 33 ||
            transform.position.x > 38 ||
            transform.position.y < -29 ||
            transform.position.x < -33 ||
            timer > 0.2)
        {
            if (launched)
            {
                birdy.SetActive(false);
                birdy.GetComponent<Rigidbody2D>().gravityScale = 0;
                birdy.transform.position = initialPosition;
                launched = false;
                birdy.SetActive(true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                timer = 0;
                touched = false;
                wrongPanel.SetActive(false);
                if(Vector3.Distance(transform.position, initialPosition) > 1f)
                {
					birdy.GetComponent<Rigidbody2D>().gravityScale = 0;
					birdy.transform.position = initialPosition;
					Trajectory.enabled = false;
					launched = false;
					birdy.GetComponent<Rigidbody2D>().simulated = true;
				}
            }

        }
    }

    private void OnMouseDown()
    {
        if(launched)
        {
            Debug.Log("testing");
			Trajectory.enabled = false;
            GetComponent<LineRenderer>().enabled = false; 
		}
        if (!launched)
        {
			Trajectory.enabled = true;
			GetComponent<LineRenderer>().enabled = true;
            GetComponent<SpriteRenderer>().color = Color.red;
            birdy.GetComponent<Rigidbody2D>().simulated = false;
        }
    }

    private void OnMouseUp()
    {
        if (!launched)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            Vector2 directionToIitialPosition = initialPosition - transform.position;
            if (Vector3.Distance(transform.position, initialPosition) > 1f)
            {
                GetComponent<Rigidbody2D>().AddForce(directionToIitialPosition * launchPow);
                GetComponent<Rigidbody2D>().gravityScale = 1;
                GetComponent<LineRenderer>().enabled = false;
                Trajectory.enabled = false;
                birdy.GetComponent<Rigidbody2D>().simulated = true;
                launched = true;

			}
        }
    }

    private void OnMouseDrag()
    {
        
        if (!launched)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(newPosition.x, newPosition.y);
			Trajectory.enabled = true;
			launched = false;
            
            float pullDistance = Vector3.Distance(newPosition, initialPosition);
            showTrajectory(newPosition , pullDistance);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Answer" && !touched)
        {
            collision.gameObject.SetActive(false);
            touched = true;
			launched = false;
			WinLoseCanvas.SetActive(true);
			wrongPanel.SetActive(true);
        }

        if (collision.gameObject.tag == "Correct" && !touched)
        {
			collision.gameObject.SetActive(false);
			touched = true;
			launched = false;
			WinLoseCanvas.SetActive(true);
			correctPanel.SetActive(true);
            highScore+=10;

			//ScoreSystem.SaveScore(highScore);
			scoreText.text=highScore.ToString();
            
        }
    }
	public void OnBadChoice()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
		rb.velocity = Vector3.zero;
        rb.gravityScale = 0;
		touched = false;
		birdy.transform.position = initialPosition;
		WinLoseCanvas.SetActive(false);
		wrongPanel.SetActive(false);
	}

	void showTrajectory(Vector3 newPos, float distance)
    {
        Vector3 diff = initialPosition -newPos;
        int segmentCount = 25;
        Vector2[] segments = new Vector2[segmentCount];
        segments[0] = newPos;

        Vector2 segVelocity = new Vector2(diff.x, diff.y) * launchPow/50;

        for (int i = 1; i< segmentCount; i++)
        {
            float timeCurve = (i * Time.fixedDeltaTime * 5);
            segments[i] = segments[0] + segVelocity * timeCurve + 0.5f * Physics2D.gravity * Mathf.Pow(timeCurve, 2);
        }
        Trajectory.positionCount = segmentCount;
        for (int j = 0; j<segmentCount ; j++)
        {
            Trajectory.SetPosition(j, segments[j]);
        }
    }
}
