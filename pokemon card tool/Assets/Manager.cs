using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject pnlMenu, pnlGroupCard;
    public GameObject pnlEdit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btnCreate_Click()
    {
        pnlGroupCard.SetActive(true);
        GameObject.Find("CardList").gameObject.GetComponent<cardList>().toggle_Click();
    }

    public void btnEdit_Click()
    {
        pnlEdit.SetActive(true);
     }
    
    public void btnExit_Click()
    {
        Application.Quit();
    }
}
