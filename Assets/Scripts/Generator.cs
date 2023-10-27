using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject panel;
    [SerializeField] private List<GameObject> cards;
    [SerializeField] private List<Sprite> front;
    [SerializeField] private Sprite back;
    [SerializeField] private int numOfCards;
   
    private void RedrawCards()
    {
        for  (int i = 0; i < cards.Count; i++)
        {
            GameObject tmp = Instantiate(cards[i], panel.transform);
            DestroyImmediate(cards[i]);
            tmp.GetComponent<Image>().enabled = true;
            tmp.GetComponent<BoxCollider2D>().enabled = true;
            cards[i] = tmp;
        }
    }

    private void Shuffle()
    {
        System.Random rng = new System.Random();

        for (int i = cards.Count-1; i >= 0; i--)
        {
            int k = rng.Next(i);
            GameObject tmp = cards[k];
            cards[k] = cards[i];
            cards[i] = tmp;
        }
    }

    private void Generate()
    {
        for (int i = 0; i < numOfCards; i++)
        {
            if (i >= front.Count)
                return;
            GameObject card = Instantiate(cardPrefab, panel.transform);
            Card cardScript = card.GetComponent<Card>();
            cardScript.SetFront(front[i]);
            cardScript.SetBack(back);
            cardScript.SetNumber(i);
            cards.Add(card);
            cards.Add(Instantiate(card, panel.transform));
        }
    }

    void Start()
    {
        Generate();
        Shuffle();
        RedrawCards();
        Game.Instance.SetCards();
    }


    void Update()
    {
        
    }
}
