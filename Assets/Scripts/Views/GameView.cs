using App̈.Elements;
using TMPro;
using UnityEngine;

namespace App.Views
{
    public class GameView : MonoBehaviour
    {
        public GameObject ObstaclePrefab;
        public Player Player;
        public RectTransform ObstacleSpawnRectTransform;
        public TextMeshProUGUI ScoreText;
        public TextMeshProUGUI StartGameText;
    }
}