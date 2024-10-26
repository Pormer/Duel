using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class DataItem : MonoBehaviour
{
    private Label _nameLabel;
    private Button _deleteBtn;
    private VisualElement _rootElem;

    public CharacterDataSO charItemData;
    public GunDataSO gunItemData;

    public event Action<DataItem> OnSelectEvent;
    public event Action<DataItem> OnDeleteEvent;


    public string Name
    {
        get => _nameLabel.text;
        set => _nameLabel.text = value;
    }

    public bool IsActive
    {
        get => _rootElem.ClassListContains("active");
        set
        {
            if (value)
            {
                _rootElem.AddToClassList("active");
            }
            else
            {
                _rootElem.RemoveFromClassList("active");
            }
        }
    }

    public DataItem(VisualElement root, CharacterDataSO itemData)
    {
        charItemData = itemData;

        DataClickSetting(root, itemData);
        gunItemData = null;
    }

    public DataItem(VisualElement root, GunDataSO itemData)
    {
        gunItemData = itemData;

        DataClickSetting(root, itemData);
        charItemData = null;
    }

    private void DataClickSetting(VisualElement root, CharacterDataSO itemData)
    {
        _rootElem = root.Q("DataItem");
        _nameLabel = root.Q<Label>("ItemName");
        _deleteBtn = root.Q<Button>("DeleteBtn");
        _deleteBtn.RegisterCallback<ClickEvent>(evt =>
        {
            if (EditorUtility.DisplayDialog("Delete", $"{itemData.itemName}을(를) 진짜 지우시겠습니까?", "Yes", "No"))
            {
                OnDeleteEvent?.Invoke(this);
                evt.StopPropagation();
            }
        });

        _rootElem.RegisterCallback<ClickEvent>(evt =>
        {
            OnSelectEvent?.Invoke(this);
            evt.StopPropagation();
        });
    }
    
    private void DataClickSetting(VisualElement root, GunDataSO itemData)
    {
        _rootElem = root.Q("DataItem");
        _nameLabel = root.Q<Label>("ItemName");
        _deleteBtn = root.Q<Button>("DeleteBtn");
        _deleteBtn.RegisterCallback<ClickEvent>(evt =>
        {
            if (EditorUtility.DisplayDialog("Delete", $"{itemData.itemName}을(를) 진짜 지우시겠습니까?", "Yes", "No"))
            {
                OnDeleteEvent?.Invoke(this);
                evt.StopPropagation();
            }
        });

        _rootElem.RegisterCallback<ClickEvent>(evt =>
        {
            OnSelectEvent?.Invoke(this);
            evt.StopPropagation();
        });
    }
}