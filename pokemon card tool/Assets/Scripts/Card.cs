using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card
{
    public string id;
    public string card_name;
    public int type;
    public int set;
    public bool gx;
    public Sprite img;

    public Card(string _id, int _set,string _name, int _type, Sprite _img)
    {
        id = _id;
        set = _set;
        card_name = _name;
        type = _type;
        if (card_name.IndexOf("GX") == -1)
            gx = false;
        else
            gx = true;
        img = _img;
    }
}
