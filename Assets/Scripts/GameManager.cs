using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
        public const int numRows = 2;
        public const int numColumns = 4;
        public const float offsetX = 2f;
        public const float offsetY = 2.5f;

        [SerializeField] MemoryCard originalCard;
        [SerializeField] Sprite[] sprites;
        [SerializeField] TextMesh scoreText;

        MemoryCard firstRevealed;
        MemoryCard secondRevealed;

        int score;

        void Start()
        {
                Vector3 startPosition = originalCard.transform.position;

                int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
                ShuffleArray(numbers);


                for (int i = 0; i < numColumns; ++i)
                {
                        for (int j = 0; j < numRows; ++j)
                        {
                                MemoryCard card = null;
                                if (i == 0 && j == 0)
                                        card = originalCard;
                                else
                                        card = Instantiate(originalCard);

                                int index = j * numColumns + i;
                                int id = numbers[index];
                                card.SetCard(id, sprites[id]);

                                float posX = (offsetX * i) + startPosition.x;
                                float posY = -(offsetY * j) + startPosition.y;
                                card.transform.position = new Vector3(posX, posY, startPosition.z);
                        }
                }
        }

        public static void ShuffleArray(int[] array)
        {
                for (int i = 0; i < array.Length; ++i)
                {
                        int tmp = array[i];
                        int r = Random.Range(i, array.Length);
                        array[i] = array[r];
                        array[r] = tmp;
                }
        }

        public void CardRevealed(MemoryCard card)
        {
                if (firstRevealed == null)
                        firstRevealed = card;
                else
                {
                        secondRevealed = card;
                        StartCoroutine(CheckMatch());
                }
        }

        IEnumerator CheckMatch()
        {
                if (firstRevealed.GetId() == secondRevealed.GetId())
                {
                        ++score;
                        scoreText.text = $"Score: {score}";
                }
                else
                {
                        yield return new WaitForSeconds(1.0f);
                        firstRevealed.Hide();
                        secondRevealed.Hide();
                }
                firstRevealed = secondRevealed = null;
        }

        void Restart()
        {
                SceneManager.LoadScene("SampleScene");
        }

        public bool CanReveal() => secondRevealed == null;
}