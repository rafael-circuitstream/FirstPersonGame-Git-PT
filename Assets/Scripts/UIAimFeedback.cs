using TMPro;
using UnityEngine;

public class UIAimFeedback : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI aimFeedbackText;
    [SerializeField] private InteractionModule interactionModule;

    private void Start()
    {
        interactionModule.OnNewInteractionFound += DisplayInteractionText;
        HideInteractionText();
    }

    private void DisplayInteractionText(GameObject interaction)
    {
        if(interaction == null)
        {
            HideInteractionText();
        }
        else
        {
            aimFeedbackText.enabled = true;
            aimFeedbackText.text = "PRESS RMB TO INTERACT WITH " + interaction.name;
        }


    }

    private void HideInteractionText()
    {
        aimFeedbackText.enabled = false;
    }
}
