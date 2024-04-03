using UnityEngine;
using UnityEngine.UI;

public class FirstSelected : MonoBehaviour
{
    //Attach to every Menu and assign the button manually

    public Button firstSelected;

    private Button previouslySelected;

    void OnEnable()
    {   
        if(previouslySelected != null)
        {
            previouslySelected.Select();
        }
        else
        {
            firstSelected.Select();
        }
    }

    private void OnDisable()
    {
        if (UnityEngine.EventSystems.EventSystem.current != null)
        {
            var currentSelected = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject?.GetComponent<Button>();
            if (currentSelected != null)
            {
                previouslySelected = currentSelected;
            }
        }
        else
        {
            previouslySelected = null;
        }
    }

    public void SelectOnStart(Button button)
    {
        firstSelected = button;
    }
}