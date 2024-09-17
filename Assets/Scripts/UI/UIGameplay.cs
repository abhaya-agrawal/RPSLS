using System;
using TMPro;
using UnityEngine;

namespace RPSLS.Gameplay.UI
{
    public class UIGameplay : MonoBehaviour
    {
        [SerializeField] private GameObject
            _aiPanel,
            _playerPanel;

        [SerializeField] private TMP_Text
            _aiHandText,
            _playerHandText,
            _resultText;


        private void OnEnable()
        {
            _resultText.text = $"Last Result: {Result.None}";
            EventManager.OnPlayerHandPlayed += OnPlayerHandPlayed;
            EventManager.OnAIHandPlayed += OnAIHandPlayed;
            EventManager.OnSetResult += OnSetResult;
            EventManager.OnGameOver += OnGameOver;
            EventManager.OnContinueGame += OnContinueGame;
        }

        private void OnDisable()
        {
            EventManager.OnPlayerHandPlayed -= OnPlayerHandPlayed;
            EventManager.OnAIHandPlayed -= OnAIHandPlayed;
            EventManager.OnSetResult -= OnSetResult;
            EventManager.OnGameOver -= OnGameOver;
            EventManager.OnContinueGame -= OnContinueGame;
        }

        private void OnSetResult(Result result)
        {
            _resultText.text = $"Last Result: {result}";
        }

        private void OnPlayerHandPlayed(InputType inputType)
        {
            _playerHandText.text = inputType.ToString();
            _playerPanel.SetActive(true);
        }

        private void OnAIHandPlayed(InputType inputType)
        {
            _aiHandText.text = inputType.ToString();
            _aiPanel.SetActive(true);
        }

        private void OnGameOver()
        {
            Reset();
            UIManager.GetInstance().ActivateMainMenu();
            UIManager.GetInstance().DeActivateGamePlay();
        }

        private void OnContinueGame()
        {
            Reset();
        }

        private void Reset()
        {
            _playerPanel.SetActive(false);
            _aiPanel.SetActive(false);
            _playerHandText.text = "";
            _aiHandText.text = "";
        }
    }
}