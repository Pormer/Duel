using System;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkUI : MonoBehaviour
{
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button clientBtn;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] Button startBtn;
    [SerializeField] TMP_Text joinCodeText;

    private void Awake()
    {
        startBtn.onClick.AddListener(() =>
        {
            GameManager.Instance.OnGameStart?.Invoke();
        });
        
        hostBtn.onClick.AddListener(DOCall);
        clientBtn.onClick.AddListener(() =>
        {
            RelayManager.Instance.JoinRelay(inputField.text);
        });
    }

    private async void DOCall()
    {
        string code = await RelayManager.Instance.CreateRelay();
        joinCodeText.text = code;
    }
}