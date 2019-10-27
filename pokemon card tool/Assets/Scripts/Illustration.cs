using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Illustration : MonoBehaviour
{
    public enum TYPE { grass,fire,water,electricity,superpower,fight,evil,steel,fairy,norm,dragon,item,trainer,site,energy}
    //草,火,水,電,超能力,格鬥,惡,鋼,妖精,一般,龍,物品,訓練家,場地,能量

    [SerializeField]
    TextAsset SETS; //卡組一覽
    
    public List<Card> cards;

    // Start is called before the first frame update
    void Start()
    {
        cards = new List<Card>();
        load();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void load()
    {
        int set = 0;
        StreamReader setReader = new StreamReader("./Assets/Resources/SETS.txt");
        while(!setReader.EndOfStream)
        {
            string s = setReader.ReadLine().ToString();
            string path = "./Assets/Resources/Cards/" + s + "/" + s + ".txt";
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                string cardData = reader.ReadLine();
                if (cardData == "")
                    continue;
                string[] strList = cardData.Split(' ');
                List<string> data = new List<string>();
                foreach (string str in strList)
                    data.Add(str);
                Card card = new Card(data[0], set, data[1], stringToType(data[2]), (Sprite)Resources.Load<Sprite>("Cards/" + s + "/" + data[0]));
                cards.Add(card);
            }
            reader.Close();
            set++;
        }
        setReader.Close();
        //GameObject.Find("CardList").gameObject.GetComponent<cardList>().toggle_Click();
    }

    int stringToType(string _type)
    {
        switch (_type)
        {
            case "草":
                return (int)TYPE.grass;
            case "火":
                return (int)TYPE.fire;
            case "水":
                return (int)TYPE.water;
            case "電":
                return (int)TYPE.electricity;
            case "超能力":
                return (int)TYPE.superpower;
            case "格鬥":
                return (int)TYPE.fight;
            case "惡":
                return (int)TYPE.evil;
            case "鋼":
                return (int)TYPE.steel;
            case "妖精":
                return (int)TYPE.fairy;
            case "一般":
                return (int)TYPE.norm;
            case "龍":
                return (int)TYPE.dragon;
            case "I":
                return (int)TYPE.item;
            case "T":
                return (int)TYPE.trainer;
            case "St":
                return (int)TYPE.site;
            case "E":
                return (int)TYPE.energy;
            default:
                return -1;
        }
    }
}
