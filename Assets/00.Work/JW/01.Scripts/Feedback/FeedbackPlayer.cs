using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FeedbackPlayer : MonoBehaviour
{
    private List<IFeedback> feedbackList;
    private void Awake()
    {
        feedbackList = GetComponentsInChildren<IFeedback>().ToList();
    }

    public void PlayFeedbacks()
    {
        feedbackList.ForEach(f => f.PlayFeedback());
    }
}
