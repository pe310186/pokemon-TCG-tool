using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardList : MonoBehaviour
{
    public GameObject pnlInfo,pnlLoading;
    List<Card> cardlists;
    public Toggle[] ToggleGroup;
    public Toggle SelectPokemon;
    public InputField search;
    Illustration Cards;
    public GameObject Container;
    public GameObject cardPreb;
    // Start is called before the first frame update
    void Start()
    {
        Cards = GameObject.Find("CARD").GetComponent<Illustration>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator updateView()
    {
        //pnlLoading.SetActive(true);
        foreach (Transform obj in Container.transform)
        {
            GameObject.Destroy(obj.gameObject);
        }

        if(Cards == null)
            Cards = GameObject.Find("CARD").GetComponent<Illustration>();
        foreach (Card c in Cards.cards)
        {
            if (check(c))
            {
                GameObject obj = GameObject.Instantiate(cardPreb);
                obj.GetComponent<cardGrid>().init(c);
                obj.GetComponent<Button>().onClick.AddListener(() => {
                    btnSelect_Click(obj.GetComponent<cardGrid>().card);
                });
                obj.transform.parent = Container.transform;
            }
        }
        
        yield return null;
    }

    bool check(Card c)
    {
        if (c.card_name != string.Empty && c.card_name.IndexOf(search.text) == -1)
            return false;

        if (ToggleGroup[11].isOn)//物品
            if (c.type == (int)Illustration.TYPE.item)
                return true;
        if (ToggleGroup[12].isOn)//訓練家
            if (c.type == (int)Illustration.TYPE.trainer)
                return true;
        if (ToggleGroup[13].isOn)//場地
            if (c.type == (int)Illustration.TYPE.site)
                return true;
        if (ToggleGroup[14].isOn)//能量
            if (c.type == (int)Illustration.TYPE.energy)
                return true;


        if (ToggleGroup[15].isOn)//GX
            if (c.gx == false)
                return false;

        if (ToggleGroup[0].isOn)//草
            if (c.type == (int)Illustration.TYPE.grass)
                return true;
        if (ToggleGroup[1].isOn)//火
            if (c.type == (int)Illustration.TYPE.fire)
                return true;
        if (ToggleGroup[2].isOn)//水
            if (c.type == (int)Illustration.TYPE.water)
                return true;
        if (ToggleGroup[3].isOn)//雷
            if (c.type == (int)Illustration.TYPE.electricity)
                return true;
        if (ToggleGroup[4].isOn)//超能力
            if (c.type == (int)Illustration.TYPE.superpower)
                return true;
        if (ToggleGroup[5].isOn)//格鬥
            if (c.type == (int)Illustration.TYPE.fight)
                return true;
        if (ToggleGroup[6].isOn)//惡
            if (c.type == (int)Illustration.TYPE.evil)
                return true;
        if (ToggleGroup[7].isOn)//鋼
            if (c.type == (int)Illustration.TYPE.steel)
                return true;
        if (ToggleGroup[8].isOn)//妖精
            if (c.type == (int)Illustration.TYPE.fairy)
                return true;
        if (ToggleGroup[9].isOn)//一般
            if (c.type == (int)Illustration.TYPE.norm)
                return true;
        if (ToggleGroup[10].isOn)//龍
            if (c.type == (int)Illustration.TYPE.dragon)
                return true;
        return false;
    }


    public void setPokemonToggle_Click()
    {
        bool setBool = SelectPokemon.isOn;
        for (int i = 0; i < 11; i++)
        {
            ToggleGroup[i].isOn = setBool;
        }
        updateView();
    }

    public void toggle_Click()
    {
        //pnlLoading.SetActive(true);
        StartCoroutine(updateView());
        
    }

    public void btnSelect_Click(Card _card)
    {
        pnlInfo.SetActive(true);
        pnlInfo.transform.GetChild(0).GetComponent<Image>().sprite = _card.img;
    }

    public void btnClose_Click()
    {
        pnlInfo.SetActive(false);
    }
}
