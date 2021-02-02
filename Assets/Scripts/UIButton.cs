using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class UIButton : MonoBehaviour
{
        [SerializeField] GameObject targetObject;
        [SerializeField] string targetMessage;

        public Color highlightColor = Color.cyan;

        SpriteRenderer spriteRenderer;

        void Awake()
        {
                spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void OnMouseEnter()
        {
                spriteRenderer.color = highlightColor;
        }

        void OnMouseExit()
        {
                spriteRenderer.color = Color.white;
        }

        void OnMouseDown()
        {
                transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        }

        void OnMouseUp()
        {
                transform.localScale = Vector3.one;
                if (targetObject != null)
                        targetObject.SendMessage(targetMessage);
        }

}
