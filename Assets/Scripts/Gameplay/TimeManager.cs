using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace RPSLS.Gameplay
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] private Slider _timeSlider;

        [SerializeField] private float _timeDuration = 60f;

        [SerializeField] private TMP_Text _timerText;

        private float _time;
        private bool _isStopTimer = false;


        private void OnEnable()
        {
            EventManager.OnGameOver += OnGameOver;
            EventManager.OnStartTimer += StartTimer;
            EventManager.OnStopTimer += StopTimer;
        }

        private void OnDisable()
        {
            EventManager.OnGameOver -= OnGameOver;
            EventManager.OnStartTimer -= StartTimer;
            EventManager.OnStopTimer -= StopTimer;
        }

        private void Start()
        {
            Reset();
        }

        private void Reset()
        {
            _isStopTimer = false;
            _time = _timeDuration;
            _timeSlider.maxValue = _timeDuration;
            _timeSlider.value = _timeDuration;
            _timerText.text = $"Time: {(int)_time}s";
        }

        private void StartTimer()
        {
            Reset();
            StartCoroutine(StartTime());
        }


        private void StopTimer()
        {
            _isStopTimer = true;
        }

        private IEnumerator StartTime()
        {
            while (!_isStopTimer)
            {
                _time -= Time.deltaTime;
                _timeSlider.value = _time;
                if (_time <= 0)
                {
                    _isStopTimer = true;
                    EventManager.RaiseGameOver();
                }

                yield return null;
            }
        }


        private void OnGameOver()
        {
            StopTimer();
            Reset();
        }
    }
}