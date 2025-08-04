using System.Collections.Generic;
using UnityEngine;

namespace App.Managers
{
    public class ObstacleManager : IManager
    {
        private List<GameObject> obstaclePool = new List<GameObject>();
        
        public ObstacleManager()
        {
            App.Instance.OnInitializeComplete.AddListener(OnAppInitialized);    
        }
        
        public void Update()
        {
            
        }

        private void OnAppInitialized()
        {
            App.Instance.GameManager.OnGameStart.AddListener(OnGameStart);
        }

        private void OnGameStart()
        {
            foreach (var obstacle in obstaclePool)
            {
                obstacle.SetActive(false);
            }
        }
    }
}