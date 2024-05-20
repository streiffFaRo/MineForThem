using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class EndingText : MonoBehaviour
{

    public int endingNR;
    public GameObject pictureGood;
    public GameObject pictureDeadAlone;
    public GameObject pictureDead;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;


    private void Awake()
    {
        endingNR = GameManager.instance.GetComponent<EndingManager>().endingNR;
    }

    private void Start()
    {
        InitEndingText(endingNR);
    }

    public void InitEndingText(int ending)
    {
        
        switch (ending)
        {
            case 0:
                //KilledForeMan
                pictureGood.SetActive(true);
                title.text = "Safe and sound";
                description.text = "After you helped your friend kill the foreman, he gave you the promised share of the money. You and your family escaped and are now living a carefree life!";
                break;
            case 1:
                //BetrayedFriend
                pictureDead.SetActive(true);
                title.text = "Betrayal!";
                description.text = "Because of your actions, Davy was hanged. Three months after this incident, you died in the mine due to the poor working conditions. Despite your righteous behaviour, you are not granted a carefree life.";
                break;
            case 2:
                //Survived
                pictureDead.SetActive(true);
                title.text = "Survived...";
                description.text = "Despite the miserable working conditions, you toil day after day for the mining company. After another three months, your job takes its toll. You has died in the mine and has been replaced by a new, even lower-paid worker.";
                break;
            case 3:
                //FamilyLeft
                pictureDeadAlone.SetActive(true);
                title.text = "Abandoned";
                description.text = "Because you didn't take care of your family, Dolores came to the conclusion that she and your son had to leave you in order to survive.";
                break;
            case 4:
                //OutOfMoney
                pictureDeadAlone.SetActive(true);
                title.text = "Bankrupt";
                description.text = "Due to your incompetence in handling your financial resources and your lack of effort during the working days, you now have no more money. Confronted with reality, Dolores has left you with your son. You didn't manage to find a new job and died of a fever shortly afterwards.";
                break;
            case 5:
                //DiedInMine
                pictureDead.SetActive(true);
                title.text = "Death";
                description.text = "You were forgotten and left behind. You got lost in the darkness and died - but don't worry, someone else will work for the company in your place.";
                break;
            case 6:
                //Escaped
                pictureDead.SetActive(true);
                title.text = "Escape";
                description.text = "In view of the gallows the sheriff must have suspected you too. Without hesitation, you returned to Dolores and your son and fled with them to the next town. Three months later, you died from the miserable working conditions in the next mine. You never heard from Davy or the sheriff again until you died.";
                break;
            case 7:
                //BlowUp
                pictureDead.SetActive(true);
                title.text = "Death";
                description.text = "Because of your recklessness, you were torn to pieces by a blast you initiated. You are dead!";
                break;
            default:
                Debug.LogWarning("Ending ID out of bounds");
                break;
        }
    }
}
