using RPSLS.Common;

namespace RPSLS.Gameplay
{
    public static class EventManager
    {
        public delegate void PlayerHandPlayed(InputType playerInput);

        public static event PlayerHandPlayed OnPlayerHandPlayed;

        public static void RaisePlayerHandPlayed(InputType playerInput)
        {
            OnPlayerHandPlayed?.Invoke(playerInput);
        }

        public delegate void AIHandPlayed(InputType aiInput);

        public static event AIHandPlayed OnAIHandPlayed;

        public static void RaiseAIHandPlayed(InputType aiInput)
        {
            OnAIHandPlayed?.Invoke(aiInput);
        }

        public delegate void StartTimer();

        public static event StartTimer OnStartTimer;

        public static void RaiseStartTimer()
        {
            OnStartTimer?.Invoke();
        }

        public delegate void StopTimer();

        public static event StopTimer OnStopTimer;

        public static void RaiseStopTimer()
        {
            OnStopTimer?.Invoke();
        }

        public delegate void GameOver();

        public static event GameOver OnGameOver;

        public static void RaiseGameOver()
        {
            OnGameOver?.Invoke();
        }

        public delegate void ContinueGame();

        public static event ContinueGame OnContinueGame;

        public static void RaiseContinueGame()
        {
            OnContinueGame?.Invoke();
        }

        public delegate void SetResult(Result result);

        public static event SetResult OnSetResult;

        public static void RaiseSetResult(Result result)
        {
            OnSetResult?.Invoke(result);
        }
    }
}