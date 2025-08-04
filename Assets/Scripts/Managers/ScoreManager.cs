using UnityEngine;
using UnityEngine.Events;

namespace App.Managers
{
    public class ScoreManager : IManager
    {
        public UnityEvent<int> OnScoreChanged { get; private set; } = new UnityEvent<int>();

        private int currentScore;
        private float startTime;

        public ScoreManager()
        {
            App.Instance.OnInitializeComplete.AddListener(OnAppInitializeComplete);
        }

        private void OnAppInitializeComplete()
        {
            App.Instance.GameManager.OnGameStart.AddListener(OnGameStart);
            App.Instance.GameManager.OnGameOver.AddListener(OnGameOver);
        }

        private void OnGameOver()
        {
            // ToDo Anything on Game Over?
            App.Instance.GameView.StartGameText.text = $"You scored {currentScore} Points!";
            App.Instance.GameView.StartGameText.gameObject.SetActive(true);
        }

        private void OnGameStart()
        {
            currentScore = 0;
            startTime = Time.unscaledTime;

            App.Instance.GameView.ScoreText.text = currentScore.ToString();
        }

        public void Update()
        {
            if (!App.Instance.GameManager.IsRunning)
            {
                return;
            }

            var newScore = Mathf.FloorToInt((Time.unscaledTime - startTime) * 10.0f);

            if (newScore == currentScore)
            {
                return;
            }
            
            currentScore = Mathf.FloorToInt((Time.unscaledTime - startTime) * 10.0f);
            OnScoreChanged.Invoke(currentScore);
            
            // ToDo Should be handled by view
            App.Instance.GameView.ScoreText.text = currentScore.ToString();
        }
    }
}