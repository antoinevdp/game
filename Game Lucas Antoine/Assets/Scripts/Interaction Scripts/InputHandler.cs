using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    #region Data

        public InteractionInputData interactionInputData;

    #endregion

    #region Built In Methods

        // Start is called before the first frame update
        void Start()
        {
            interactionInputData.ResetInput();
        }

        // Update is called once per frame
        void Update()
        {
            GetInteractionInputData();
        }

    #endregion

    #region Custom Methods

        void GetInteractionInputData()
        {
            interactionInputData.InteractedClicked = Input.GetKeyDown(KeyCode.E);
            interactionInputData.InteractedRelease = Input.GetKeyUp(KeyCode.E);
        }

    #endregion
    
}
