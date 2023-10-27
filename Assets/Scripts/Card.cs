
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Card : MonoBehaviour
{
    [SerializeField] private Sprite _backSprite;
    [SerializeField] private Sprite _frontSprite;
    [SerializeField] private Sprite _winSprite;

    [SerializeField] private int _number;

    public bool Down => this.GetComponent<Image>().sprite == _frontSprite;
    public int Number => _number;
    public void OnMouseDown()
    {
        if(!Down)
        {
            this.GetComponent<Image>().sprite = _frontSprite;
            Game.Instance.OpenCards();
        }
      
    }

    public void SetFront(Sprite image)
    {
        _frontSprite = image;
        //_winSprite = image;
    }

    public void SetBack(Sprite image)
    {
        _backSprite = image;
    }

    public void SetNumber(int _number)
    {
        this._number = _number;
    }

    public void NoFindCard()
    {
        this.GetComponent<Image>().sprite = _backSprite;
    }
    public void FindCard()
    {
        this.GetComponent<Image>().sprite = _winSprite;
    }
}