using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager2 : MonoBehaviour
{
    public static bool gameOver;
    public bool assureonetime;
    public GameObject gameOverPanel;
    public GameObject WinPanel;
    public GameObject startingText;
    public static bool isGameStarted;
    public static int numberOfCoins;
    public static int numberOfBlueCoins;
    public static int numberOfyellowCoins;
    public Text coinsText;
    public Text bluecoinsText;
    public Text yellowcoinsText;
    public Timer1 Timer1;
    public GameObject Player;
    public GameObject Camera;
    public int Wincoin = 5;

    void Start()
    {
        gameOver = false;
        isGameStarted = false;
        assureonetime = true;
        numberOfCoins = 0;
        numberOfBlueCoins = 0;
        numberOfyellowCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {

        
        coinsText.text = ":" + numberOfCoins;
        bluecoinsText.text = ":" + numberOfBlueCoins;
        yellowcoinsText.text = ":" + numberOfyellowCoins;

        if (SwipeManager1.tap)
        {
            isGameStarted = true;
            Destroy(startingText);
        }
            
            if ((numberOfCoins >= Wincoin) && (numberOfBlueCoins >= Wincoin) && (numberOfyellowCoins >= Wincoin))
            {
                if(assureonetime == true)
                {
				    FindObjectOfType<AudioManager2>().PlaySound("GameWin");
                    assureonetime = false;
			    }
			    WinPanel.SetActive(true);
			    Player.SetActive(false);
		    }
            if (gameOver)
            {
			    gameOverPanel.SetActive(true);
                Player.SetActive(false);
			    
		    }

    }
}
