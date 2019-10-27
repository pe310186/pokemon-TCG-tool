using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EditManager : MonoBehaviour
{
    List<GameObject> cardDecks;
    public GameObject cardDeckPreb;
    public GameObject container;


    [SerializeField]
    TextAsset CARDDECKS;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateView()
    {
        StreamReader Reader = new StreamReader("./Assets/Resources/CARDDECKS.txt");

        while (!Reader.EndOfStream)
        {
            string str = Reader.ReadLine().ToString();
            string[] strList = str.Split(' ');
            List<string> data = new List<string>();
            foreach (string s in strList)
                data.Add(s);

            GameObject obj = Instantiate(cardDeckPreb);
            obj.GetComponent<CardDeckGrid>().init(data[0], data[1]);
            obj.transform.parent = obj.transform;
        }

    }

    public void btnClose_Click()
    {
        this.gameObject.SetActive(false);
    }
}
