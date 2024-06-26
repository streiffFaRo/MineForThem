using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{

    public int endingNR;
    
    public void InitEnding(int ending)
    {
        SceneManager.LoadScene("End_Scene");
        
        switch (ending)
        {
            case 0:
                KilledForeMan();
                break;
            case 1:
                BetrayedFriend();
                break;
            case 2:
                Survived();
                break;
            case 3:
                FamilyLeft();
                break;
            case 4:
                OutOfMoney();
                break;
            case 5:
                DiedInMine();
                break;
            case 6:
                Escaped();
                break;
            case 7:
                BlowUp();
                break;
            default:
                Debug.LogWarning("Ending ID out of bounds");
                break;
        }

        endingNR = ending;
    }

    private void KilledForeMan()
    {
        GameManager.instance.scoreFromEnding = 500;
    }

    private void BetrayedFriend()
    {
        GameManager.instance.scoreFromEnding = 100;
    }

    private void Survived()
    {
        GameManager.instance.scoreFromEnding = 0;
    }

    private void FamilyLeft()
    {
        GameManager.instance.scoreFromEnding = -100;
    }

    private void OutOfMoney()
    {
        GameManager.instance.scoreFromEnding = -200;
    }

    private void DiedInMine()
    {
        GameManager.instance.scoreFromEnding = -300;
    }

    private void Escaped()
    {
        GameManager.instance.scoreFromEnding = 0;
    }
    
    private void BlowUp()
    {
        GameManager.instance.scoreFromEnding = -400;
    }
}
