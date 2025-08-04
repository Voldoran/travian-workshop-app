using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace App̈.Elements
{
    public class Player : MonoBehaviour
    {
        public BoxCollider2D BoxCollider2D;
        public RectTransform RectTransform;

        public void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("OnTriggerEnter2D");
        }

        public void Jump()
        {
            RectTransform.DOAnchorPosY(100.0f, 0.5f).SetLoops(2, LoopType.Yoyo);
        }
    }
}