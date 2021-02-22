using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBase : MonoBehaviour, IInteractable
{
    #region Variables

        [Header("Interactable Settings")]   
        [SerializeField] private float holdDuration = 0f;

        public bool holdInteract = false;
        [SerializeField] private bool multipleUse = false;
        [SerializeField] private bool isInteractable = true;

        [SerializeField] private string toolTipMessage = "Interact [E]";

    #endregion

    #region Properties

        public float HoldDuration => holdDuration;
        
        public bool HoldInteract => holdInteract;
        public bool MultipleUse => multipleUse;
        public bool IsInteractable => isInteractable;

        public string ToolTipMessage => toolTipMessage;

        #endregion

    #region methods

        public virtual void OnInterract()
        {
                Debug.Log("Interacted " + gameObject.name);
        }

    #endregion
    
}

