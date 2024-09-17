using UnityEngine;

namespace RPSLS.Gameplay.UI
{
    public class UIPlayerInput : MonoBehaviour
    {
        [SerializeField] private InputType _inputType;

        public void OnClicked()
        {
            EventManager.RaisePlayerHandPlayed(_inputType);
        }
    }
}