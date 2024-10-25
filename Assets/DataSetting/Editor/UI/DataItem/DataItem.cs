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
    public ItemDataSO itemData;

    public event Action OnSelectEvent;
    public event Action OnDeleteEvent;


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

    public DataItem(VisualElement root, ItemDataSO itemData)
    {
        this.itemData = itemData;

        _rootElem = root.Q("DataItem");
        _nameLabel = root.Q<Label>("ItemName");
        _deleteBtn = root.Q<Button>("DeleteBtn");
        _deleteBtn.RegisterCallback<ClickEvent>(evt =>
        {
            if (EditorUtility.DisplayDialog("Delete", $"{itemData.itemName}을(를) 진짜 지우시겠습니까?", "Yes", "No"))
            {
                OnDeleteEvent?.Invoke();
                evt.StopPropagation();
            }
        });

        _rootElem.RegisterCallback<ClickEvent>(evt =>
        {
            OnSelectEvent?.Invoke();
            evt.StopPropagation();
        });

    }
}