using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CardSelectGrid : MonoBehaviour, IPointerClickHandler
{
    public Card card;
    public int count;
    public Text countText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void init(Card _card)
    {
        card = _card;
        count = 1;
        countText.text = count.ToString();
        this.gameObject.GetComponent<Image>().sprite = _card.img;
    }

    public void set(int delta_count)
    {
        count += delta_count;
        countText.text = count.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            GameObject.Find("CardSelect").gameObject.GetComponent<CardSelect>().remove(card);
        }

    }
}
