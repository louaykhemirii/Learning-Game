using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreCounter : MonoBehaviour
{
    float _score=200;
    [SerializeField] TMP_Text scoreText;

    void Update()
    {
        CountScore();
            }
    void CountScore(){
        _score-= 2 * Time.deltaTime;
        scoreText.text=_score.ToString("0");
    }
}
