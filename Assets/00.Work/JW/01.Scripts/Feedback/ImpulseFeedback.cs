using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineImpulseSource))]
public class ImpulseFeedback : Feedback
{
    [SerializeField] private float impulseForce;
    private CinemachineImpulseSource _impulseSource;
    public override void PlayFeedback()
    {
        /*_impulseSource.
        _impulseSource.*/
    }
}
