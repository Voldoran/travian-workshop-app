using System;
using System.Collections;
using App.ELements;
using App.Managers;
using App.Views;
using UnityEngine;
using UnityEngine.Events;

namespace App
{
    public class App : MonoBehaviour
    {
        public static App Instance;

        public bool IsInitialized { get; private set; }
        public GameView GameView;
        public UnityEvent OnInitializeComplete { get; } = new UnityEvent();
        
        public GameManager GameManager { get; private set; }
        public ObstacleManager ObstacleManager { get; private set; }
        public ScoreManager ScoreManager { get; private set; }

        public void Awake()
        {
            Instance = this;

            GameManager = new GameManager();
            ObstacleManager = new ObstacleManager();
            ScoreManager = new ScoreManager();
            
            OnInitializeComplete.Invoke();
            OnInitializeComplete.RemoveAllListeners();

            IsInitialized = true;
            
            StartCoroutine(CoroutineUpdate());
        }

        private IEnumerator CoroutineUpdate()
        {
            while (true)
            {
                GameManager.Update();
                ScoreManager.Update();
                ObstacleManager.Update();

                yield return null;
            }
        }
    }
}