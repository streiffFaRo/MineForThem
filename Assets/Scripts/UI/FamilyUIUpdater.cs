using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyUIUpdater : MonoBehaviour
{
    
    public HomeModeController homeModeController;
    
    void Awake()
    {
        homeModeController = FindObjectOfType<HomeModeController>();
    }

    public void FamilyHappiness()
    {
        homeModeController.SetFamilyHappiness();
    }
    


}
