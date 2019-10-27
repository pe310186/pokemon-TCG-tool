using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelect : MonoBehaviour
{
    public GameObject pnlInfo;
    public GameObject Container;
    public Text numberText;
    List<GameObject> Cards;
    public GameObject CardSelectPreb;
    int number;

    // Start is called before the first frame update
    void Start()
    {
        Cards = new List<GameObject>();
        number = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void add(Card _card)
    {
        int count = 0;
        int index = -1;
        for(int i = 0; i < Cards.Count;i++)
        {
            if (Cards[i].GetComponent<CardSelectGrid>().card.card_name == _card.card_name)
                count += Cards[i].GetComponent<CardSelectGrid>().count;
            if (Cards[i].GetComponent<CardSelectGrid>().card.id == _card.id && Cards[i].GetComponent<CardSelectGrid>().card.card_name == _card.card_name)
            {
                index = i;
            }
                
        }
        if(index == -1)//不在list new obj
        {
            //同名卡判別
            if (count < 4)
            {
                GameObject obj = Instantiate(CardSelectPreb);
                obj.GetComponent<CardSelectGrid>().init(_card);
                obj.GetComponent<Button>().onClick.AddListener(() => {
                    btnSelect_Click(obj.GetComponent<CardSelectGrid>().card);
                });
                obj.transform.parent = Container.transform;
                Cards.Add(obj);
            } 
        }
        else
        {
            //同名卡判別
            if (count< 4 || _card.type == (int) Illustration.TYPE.energy)
            {
                Cards[index].GetComponent<CardSelectGrid>().set(1);
            }
        }
        ViewUpdate();

    }

    public void remove(Card _card)
    {
        foreach(GameObject c in Cards)
        {
            if(c.GetComponent<CardSelectGrid>().card.id == _card.id)
            {
                c.GetComponent<CardSelectGrid>().set(-1);
                if(c.GetComponent<CardSelectGrid>().count == 0)
                {
                    Cards.Remove(c);
                    GameObject.Destroy(c);

                }
                break;
            }
        }
        ViewUpdate();
    }

    void ViewUpdate()
    {
        number = 0;
        foreach (GameObject c in Cards)
        {
            number += c.GetComponent<CardSelectGrid>().count;
        }
        numberText.text = number.ToString() + "/60";

        //sort
        for (int i = 0; i < Cards.Count - 1; i++)
        {
            for (int j = i + 1; j < Cards.Count; j++)
            {
                if (Cards[i].GetComponent<CardSelectGrid>().card.set > Cards[j].GetComponent<CardSelectGrid>().card.set)
                {
                    GameObject tmp = Cards[i];
                    Cards[i] = Cards[j];
                    Cards[j] = tmp;
                }
                else if (Cards[i].GetComponent<CardSelectGrid>().card.set == Cards[j].GetComponent<CardSelectGrid>().card.set)
                {
                    if (int.Parse(Cards[i].GetComponent<CardSelectGrid>().card.id) > int.Parse(Cards[j].GetComponent<CardSelectGrid>().card.id))
                    {
                        GameObject tmp = Cards[i];
                        Cards[i] = Cards[j];
                        Cards[j] = tmp;
                    }
                }
            }
        }

        for (int i = 0; i < Cards.Count; i++)
        {
            Cards[i].transform.SetSiblingIndex(i);
        }
    }

    public void btnSelect_Click(Card _card)
    {
        pnlInfo.SetActive(true);
        pnlInfo.transform.GetChild(0).GetComponent<Image>().sprite = _card.img;
    }
}
