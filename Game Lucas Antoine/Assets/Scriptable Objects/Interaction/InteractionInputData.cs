using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Interaction Input Data", menuName = "Interaction System/Input Data")]
public class InteractionInputData : ScriptableObject
{
    // Responsible for the interaction inputs

    #region Bool

        private bool m_interactedClicked;
        private bool m_interactedRelease;
        
        //Properties
        public bool InteractedClicked
        {
            get => m_interactedClicked;
            set => m_interactedClicked = value;
        }
        public bool InteractedRelease
        {
            get => m_interactedRelease;
            set => m_interactedRelease = value;
        }

        public void ResetInput()
        {
            m_interactedClicked = false;
            m_interactedRelease = false;
        }

        #endregion
}
