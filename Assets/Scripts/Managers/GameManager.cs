using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace App.Managers
{
    public class GameManager : IManager
    {
        public UnityEvent OnGameStart { get; private set; } = new UnityEvent();
        public UnityEvent OnGameOver { get; private set; } = new UnityEvent();
        
        public bool IsRunning { get; private set; }

        public GameManager()
        {
            App.Instance.OnInitializeComplete.AddListener(OnAppInitializeComplete);
        }
        
        public void Update()
        {
            if (Keyboard.current[Key.Space].wasPressedThisFrame)
            {
                ProcessInputSpace();
            }
            
            // Cheat
            if (Keyboard.current[Key.Enter].wasPressedThisFrame)
            {
                ProcessGameOver();
            }
        }

        private void OnAppInitializeComplete()
        {
            
        }

        private void ProcessGameOver()
        {
            if (!IsRunning)
            {
                return;
            }

            IsRunning = false;
            OnGameOver.Invoke();
        }

        private void ProcessInputSpace()
        {
            if (IsRunning)
            {
                App.Instance.GameView.Player.Jump();
            }
            else
            {
                IsRunning = true;
                App.Instance.GameView.StartGameText.gameObject.SetActive(false);
                
                OnGameStart.Invoke();
            }
        }
    }
}