using System;
using UnityEngine;
using UnityEngine.UIElements;

public class InGameUI : MonoBehaviour
{
    [SerializeField] VisualElement root  = null;

    private void Awake()
    {
        VisualElement v = root.Q<VisualElement>("root");
    }
}
