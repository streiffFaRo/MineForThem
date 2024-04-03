using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    
    
    public TextMeshProUGUI goldMinedUI;
    public TextMeshProUGUI blocksInInvUI;
    
    
    private void Start()
    {
        UpdateGoldMined();
        UpdateBlocksInInv();
    }
    

    public void UpdateGoldMined()
    {
        goldMinedUI.SetText(GameManager.instance.goldMined.ToString());
    }
    
    public void UpdateBlocksInInv()
    {
        blocksInInvUI.SetText(GameManager.instance.blocksInInv.ToString());
    }
    

    
    
}
