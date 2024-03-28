using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{

    public void InitEnding(int ending)
    {
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
                GotShot();
                break;
            case 7:
                break;
            default:
                Debug.LogWarning("Ending ID out of bounds");
                break;
        }
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

    private void GotShot()
    {
        GameManager.instance.scoreFromEnding = -500;
    }
}
