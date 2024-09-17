using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RPSLS.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        private static readonly List<InputType> AiInputList =
            Enum.GetValues(typeof(InputType)).OfType<InputType>().ToList();

        private int _highScore;
        private int _currentScore = 0;
        private Result _result;

        private void Awake()
        {
            if (PlayerPrefs.GetInt(GameConstants.HasKey) == 0)
            {
                PlayerPrefs.SetInt(GameConstants.HasKey, 1);
                PlayerPrefs.SetInt(GameConstants.HighScore, 0);
            }

            _result = Result.None;
            _highScore = PlayerPrefs.GetInt(GameConstants.HighScore);
        }

        private void OnEnable()
        {
            EventManager.OnPlayerHandPlayed += OnPlayerHandPlayed;
            EventManager.OnGameOver += OnGameOver;
        }

        private void OnDisable()
        {
            EventManager.OnPlayerHandPlayed -= OnPlayerHandPlayed;
            EventManager.OnGameOver -= OnGameOver;
        }

        private void OnPlayerHandPlayed(InputType playerInput)
        {
            int index = Random.Range(0, AiInputList.Count);
            var aiInput = AiInputList[index];
            EventManager.RaiseAIHandPlayed(aiInput);
            EventManager.RaiseStopTimer();
            GetWinner(playerInput, aiInput);
        }

        private void GetWinner(InputType playerHand, InputType aiHand)
        {
            if (playerHand == aiHand)
            {
                _result = Result.Draw;
                SetResult();
                return;
            }

            if (IsWinningChoice(playerHand,aiHand))
            {
                _currentScore += 10;
                if (_currentScore > _highScore)
                {
                    _highScore = _currentScore;
                }
                _result = Result.Win;
            }
            else
            {
                _result = Result.Loose;
            }

            SetResult();
        }
        
        private bool IsWinningChoice(InputType playerChoice, InputType opponentChoice)
        {
            return playerChoice switch
            {
                InputType.Rock => opponentChoice is InputType.Lizard or InputType.Scissors,
                InputType.Paper => opponentChoice is InputType.Rock or InputType.Spock,
                InputType.Scissors => opponentChoice is InputType.Lizard or InputType.Paper,
                InputType.Lizard => opponentChoice is InputType.Paper or InputType.Spock,
                InputType.Spock => opponentChoice is InputType.Scissors or InputType.Rock,
                _ => false
            };
        }
        
        private void SetResult()
        {
            if (_result == Result.Loose)
            {
                EventManager.RaiseSetResult(_result);
                Invoke("SetGameOver", 1f);
            }
            else
            {
                EventManager.RaiseSetResult(_result);
                Invoke("ContinueGame", 1f);
            }
        }


        private void SetGameOver()
        {
            EventManager.RaiseGameOver();
        }

        private void OnGameOver()
        {
            _currentScore = 0;
            _result = Result.None;
            PlayerPrefs.SetInt(GameConstants.HighScore, _highScore);
        }
        
        private void ContinueGame()
        {
            EventManager.RaiseContinueGame();
            EventManager.RaiseStartTimer();
        }
    }
}