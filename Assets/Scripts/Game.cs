using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Game : MonoBehaviour
{
    [SerializeField] private Transform panelCard;
    [SerializeField] private List<Card> cards;
    [SerializeField] private int numberCard;

    // Шаблон проектирования Синглтон
    public static Game Instance;

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);
    }

    public void SetCards()
    {
        cards.Clear();
        for (int i = 0; i < panelCard.childCount; i++)
        {
            cards.Add(panelCard.GetChild(i).GetComponent<Card>());
        }
    }

    public void OpenCards()
    {
        var openCard = 0;
        foreach (Card card in cards)
        {
            if (card.Down)
            {
                if (openCard == 0)
                {
                    numberCard = card.Number;
                }
                openCard++;
            }
        }
        if (openCard == 2)
        {
            CheackCard();
        }
    }
    public void CheackCard()
    {
        var a = 0;
        foreach (Card card in cards)
        {
            if (card.Down && card.Number == numberCard)
            {
                //Debug.Log("A.1");
                a++;
            }
        }
        if (a == 2)
        {
            //Match
            FindCard();
        }
        else
        {
            // UnMatch
            //NoFindCard();
            StartCoroutine(ICloseDelay());
        }
    }
    public void FindCard()
    {
        foreach (Card card in cards)
        {
            if (card.Down)
            {
                card.GetComponent<Card>().FindCard();
            }
        }
       
    }
    public void NoFindCard()
    {
        foreach (Card card in cards)
        {
            if (card.Down)
            {
                card.GetComponent<Card>().NoFindCard();
            }
        }
    }

    public IEnumerator ICloseDelay()
    {
        yield return new WaitForSeconds(1.5f);
        NoFindCard();
    }
}
