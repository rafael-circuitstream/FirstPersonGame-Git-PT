using System;
using UnityEngine;

public class InteractionModule : MonoBehaviour
{
    [SerializeField] private Transform rayOriginTransform;
    [SerializeField] private float interactionRange;
    [SerializeField] private LayerMask interactableLayer;

    public Action<GameObject> OnNewInteractionFound;

    private GameObject highlightedInteraction;
    private Interactable pickedUpInteraction;

    // Update is called once per frame
    void Update()
    {
        Ray imaginaryLine = new Ray(rayOriginTransform.position, rayOriginTransform.forward * interactionRange);
        
        RaycastHit hitInfo;

        if( Physics.Raycast(imaginaryLine, out hitInfo, interactionRange, interactableLayer) )
        {
            Debug.Log("Press F to interact");

            highlightedInteraction = hitInfo.collider.gameObject;
            highlightedInteraction.layer = 7;
            //NEW INTERACTION FOUND
            OnNewInteractionFound?.Invoke( highlightedInteraction );
        }
        else
        {
            highlightedInteraction.layer = 6;
            highlightedInteraction = null;

            //NO INTERACTION FOUND
            OnNewInteractionFound?.Invoke(null);
            

        }

        Debug.DrawRay(rayOriginTransform.position, rayOriginTransform.forward * interactionRange, Color.blue);
    }

    public void StartInteraction()
    {
        if( highlightedInteraction != null)
        {
            Debug.Log(Vector3.Distance(transform.position, highlightedInteraction.transform.position)); 

            Interactable interaction = highlightedInteraction.GetComponent<Interactable>();
            interaction.OnStartInteraction.Invoke();

            if(interaction is PickUpInteractable)
            {
                pickedUpInteraction = interaction;
                pickedUpInteraction.transform.SetParent(rayOriginTransform);
            }
        }
        
    }

    public void StopInteraction()
    {
        if(pickedUpInteraction != null)
        {
            pickedUpInteraction.OnStopInteraction.Invoke();
            pickedUpInteraction.transform.SetParent(null);
            pickedUpInteraction = null;
        }
    }
}
