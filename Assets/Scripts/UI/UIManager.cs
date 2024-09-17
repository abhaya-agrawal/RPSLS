using System;
using RPSLS.Common;
using UnityEngine;

namespace RPSLS.Gameplay.UI
{
    public class UIManager : GenericSingletonClass<UIManager>
    {
        public UIGameplay uiGameplay;
        public UIMainMenu uiMainMenu;

        private void Start()
        {
            ActivateMainMenu();
            DeActivateGamePlay();
        }

        public void ActivateGamePlay()
        {
            uiGameplay.gameObject.SetActive(true);
        }

        public void DeActivateGamePlay()
        {
            uiGameplay.gameObject.SetActive(false);
        }

        public void ActivateMainMenu()
        {
            uiMainMenu.gameObject.SetActive(true);
        }

        public void DeActivateMainMenu()
        {
            uiMainMenu.gameObject.SetActive(false);
        }
    }
}