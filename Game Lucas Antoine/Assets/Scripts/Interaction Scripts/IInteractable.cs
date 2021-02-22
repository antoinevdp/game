using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    #region Variables
        // Get Properties of InterctionInputData
        float HoldDuration { get; }
        
        // Hold to interact or just click
        bool HoldInteract { get; }
        // Interactable used multiple time (ex : light interuptor)
        bool MultipleUse { get; }
        // is the object interactable (ex : need a key to open
        bool IsInteractable { get; }
        
        string ToolTipMessage { get; }
        
    #endregion

    #region Methods

        void OnInterract();

    #endregion
}
