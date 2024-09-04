using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager2 : MonoBehaviour
{
    public int pieceCounter;
    [SerializeField] int puzzleNumberOfPieces;
    [SerializeField] GameObject winCanvas;
    [SerializeField] GameObject loseCanvas;
    [SerializeField] GameObject timer;
    [SerializeField] TMP_Text score;
    [SerializeField] CountDownTimer _timerScript;
    float _finalScore;
    bool _scoreShown;
    void Start()
    {
        
    }

    void Update()
    {
        CheckForWin();
        CheckForLoss();
    }

    void CheckForWin(){
        if(pieceCounter==puzzleNumberOfPieces){
            Debug.Log("won");
            winCanvas.SetActive(true);
            timer.SetActive(false);
            if (!_scoreShown){
            Debug.Log(score.text);
            _scoreShown=true;
            }
            score.gameObject.SetActive(false);
            pieceCounter = 0;
        }
    }

    void CheckForLoss(){
        if (_timerScript._gameEnded){
            loseCanvas.SetActive(true);
            timer.SetActive(false);
            score.gameObject.SetActive(false);
        }

    }
}
