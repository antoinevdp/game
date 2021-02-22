using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    #region Variables

        [Header("Data")] 
        public InteractionInputData interactionInputData;
        public InteractionData interactionData;

        [Space] [Header("Ray Settings")] 
        public float rayDistance;
        public float raySpehereRadius;
        public LayerMask interactableLayer;

        private Camera m_cam;

        private bool m_interacting;
        private float m_holdTimer = 0f;

        #endregion

    #region Built In Methods

        private void Awake()
        {
            m_cam = FindObjectOfType<Camera>();
        }

        private void Update()
        {
            CheckForInteractable();
            CheckForInteractableInput();
        }

    #endregion

    #region Custom Methods

        void CheckForInteractable()
        {
            Ray _ray = new Ray(m_cam.transform.position + new Vector3(0f, 0.1f, 0f), m_cam.transform.forward);
            RaycastHit _hitInfo;

            bool _hitSomething = Physics.SphereCast(_ray, raySpehereRadius, out _hitInfo, rayDistance, interactableLayer);

            if (_hitSomething)
            {
                
                InteractableBase _interactable = _hitInfo.transform.GetComponent<InteractableBase>();
                // check if the object has an interactable script
                if (_interactable != null)
                {
                    // If we have a slot
                    if (interactionData.IsEmpty())
                    {
                        // We assign this interactable to our inter data
                        interactionData.Interactable = _interactable;
                    }
                    else // If not => means there is an int in out data
                    {
                        //Then check if its the same int as previous
                        if (!interactionData.IsSameInteractable(_interactable))
                        {
                            interactionData.Interactable = _interactable;
                        }
                    }
                }
            }
            else
            {
                // If dont hit anything => reset data
                interactionData.ResetData();
            }
            
            Debug.DrawRay(_ray.origin, _ray.direction * rayDistance,_hitSomething ? Color.green : Color.red);
        }

        void CheckForInteractableInput()
        {
            if (interactionData.IsEmpty())
                return;

            if (interactionInputData.InteractedClicked)
            {
                m_interacting = true;
                m_holdTimer = 0f;
            }

            if (interactionInputData.InteractedRelease)
            {
                m_interacting = false;
                m_holdTimer = 0f;
            }

            if (m_interacting)
            {
                if (!interactionData.Interactable.IsInteractable)
                    return;

                if (interactionData.Interactable.holdInteract)
                {
                    m_holdTimer += Time.deltaTime;

                    if (m_holdTimer >= interactionData.Interactable.HoldDuration)
                    {
                        interactionData.Interract();
                        m_interacting = false;
                    }
                }
                else
                {
                    interactionData.Interract();
                    m_interacting = false;
                }
            }
        }

    #endregion

        
}
