using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Interaction Data", menuName = "Interaction System/Interaction Data")]
public class InteractionData : ScriptableObject
{
    private InteractableBase m_interactable;

    public InteractableBase Interactable
    {
        get => m_interactable;
        set => m_interactable = value;
    }

    public void Interract()
    {
        m_interactable.OnInterract();
        ResetData();
    }

    public bool IsSameInteractable(InteractableBase _newInteractable) => m_interactable == _newInteractable;
    
    public bool IsEmpty() => m_interactable == null;
    public void ResetData() => m_interactable = null;
    
}
