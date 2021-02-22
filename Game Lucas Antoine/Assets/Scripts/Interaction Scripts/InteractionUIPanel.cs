using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionUIPanel : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI toolTipText;

    public void SetToolTip(String toolTip)
    {
        toolTipText.SetText(toolTip);
    }

    public void UpdateProgressBar(float fillAmount)
    {
        progressBar.fillAmount = fillAmount;
    }

    public void ResetUI()
    {
        progressBar.fillAmount = 0f;
        toolTipText.SetText("");
    }
}

