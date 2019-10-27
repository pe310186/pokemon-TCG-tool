using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeckGrid : MonoBehaviour
{
    public string deckName;
    public string code;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void init(string _name,string _code)
    {
        deckName = _name;
        code = _code;
    }

    public void btnInfo_Click()
    {

    }

    public void decode()
    {
        //encode
        //Hash128 hash = Hash128.Parse(code);

        //Debug.Log(hash);

        ////decode
        //string test = hash.ToString();
    }
}
