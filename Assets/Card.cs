
using UnityEngine;
using UnityEngine.UI;


public class Card : MonoBehaviour
{
    [SerializeField] private Sprite _backSprite;
    [SerializeField] private Sprite _frontSprite;
    [SerializeField] private Sprite _winSprite;

    [SerializeField] private int _number;

    public bool Down => this.GetComponent<Image>().sprite == _frontSprite;

    public void OnMouseDown()
    {
        if(!Down)
        {
            this.GetComponent<Image>().sprite = _frontSprite;
        }
        else
        {
            NoFindCard();
        }
    }
    public void NoFindCard()
    {
        this.GetComponent<Image>().sprite = _backSprite;
    }
}
