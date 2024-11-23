using UnityEngine;

[CreateAssetMenu(fileName = "SoundSO", menuName = "SO/Data/SoundData")]
public class SoundSO : ScriptableObject
{
    public AudioClip clip;
    
    [Range(0, 1f)]
    public float voluem;
    
    [Range(0, 1f)]
    public float pitch;
}
