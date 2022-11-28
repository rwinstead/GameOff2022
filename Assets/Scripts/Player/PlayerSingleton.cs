using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSingleton : MonoBehaviour
{
    public static PlayerSingleton instance;
    public TextMeshProUGUI tooltip;

    private void Awake()
    {
        if (instance == null) instance = this;
        else DestroyImmediate(this);
    }

    public void SetTooltip(string text)
    {
        tooltip.text = text;
    }

}
