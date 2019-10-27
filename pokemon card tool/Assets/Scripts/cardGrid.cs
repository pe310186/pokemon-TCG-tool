using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class cardGrid : MonoBehaviour, IPointerClickHandler
{
    public Card card;
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
        this.gameObject.GetComponent<Image>().sprite = _card.img;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            GameObject.Find("CardSelect").gameObject.GetComponent<CardSelect>().add(card);
        }
            
    }
}
