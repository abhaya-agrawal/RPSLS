using System;
using TMPro;
using UnityEngine;

namespace RPSLS.Gameplay.UI
{
    public class UIMainMenu : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;

        private UIManager UIManager => UIManager.GetInstance();

        private void OnEnable()
        {
            _scoreText.text = PlayerPrefs.GetInt(GameConstants.HighScore).ToString();
        }

        public void OnClickPlay()
        {
            UIManager.ActivateGamePlay();
            UIManager.DeActivateMainMenu();
            EventManager.RaiseStartTimer();
        }
    }
}