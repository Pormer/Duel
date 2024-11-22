using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraZoomFeedback : Feedback
{
    private CinemachineVirtualCamera _cinemachine;
    private float zoomTime;

    private void Awake()
    {
        _cinemachine = FindFirstObjectByType<CinemachineVirtualCamera>();
    }

    public override void PlayFeedback()
    {
        _cinemachine.m_Lens.OrthographicSize = 0.3f;
    }

    IEnumerator ZoomOutTime()
    {
        yield return new WaitForSeconds(zoomTime);
        _cinemachine.m_Lens.OrthographicSize = 0.35f;
    }
}