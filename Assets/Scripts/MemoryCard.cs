using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class MemoryCard : MonoBehaviour
{
        [SerializeField] GameObject backCard;
        [SerializeField] GameManager gameManager;

        int id;
        SpriteRenderer spriteRenderer;

        void Awake()
        {
                spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void OnMouseDown()
        {
                if (backCard.activeSelf && gameManager.CanReveal())
                {
                        backCard.SetActive(false);
                        gameManager.CardRevealed(this);
                }
        }

        public void SetCard(int id, Sprite sprite)
        {
                this.id = id;
                spriteRenderer.sprite = sprite;
        }

        public void Hide()
        {
                backCard.SetActive(true);
        }

        public int GetId() => id;
}
