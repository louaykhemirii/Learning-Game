using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text seconds;
    [SerializeField] private TMP_Text minutes;
    [SerializeField] private int _startingTimeMinutes;
    private float _currentTimeMinutes;
    private float _currentTimeSeconds;
    public bool _gameEnded=false;

    void Awake()
    {
        _currentTimeMinutes = _startingTimeMinutes;
        _currentTimeSeconds = 0;
        UpdateTimerDisplay();
    }

    void Update()
    {
        Timer();
    }

    void Timer()
    {   if (!_gameEnded){
        _currentTimeSeconds-= 1* Time.deltaTime;
        UpdateTimerDisplay();
        }

        if (_currentTimeSeconds <= 0 && _currentTimeMinutes <= 0)
        {
            _currentTimeSeconds=0;
            _currentTimeMinutes=0;
            minutes.text = _currentTimeMinutes.ToString("0");
            seconds.text = "00";
            _gameEnded=true;
            _currentTimeSeconds=1;
            
        }

        if (_currentTimeSeconds < 0)
        {
            _currentTimeSeconds = 59;
            _currentTimeMinutes--;
            UpdateTimerDisplay();
        }

        
    }

    void UpdateTimerDisplay()
    {
        minutes.text = _currentTimeMinutes.ToString("0");
        if (_currentTimeSeconds <10 && _currentTimeSeconds > 0){
            seconds.text = "0" + _currentTimeSeconds.ToString("0");
        }
        else{
        seconds.text = _currentTimeSeconds.ToString("0");
        }
    }
}
