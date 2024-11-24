using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class Setting : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private TextMeshProUGUI volumeText;

    private int volume = 5;
    private int maxVolume = 5;
    private int minVolume = 0;

    private void Awake()
    {
        volumeText.text = volume.ToString();
    }

    public void VolumeUp()
    {
        if (volume < maxVolume)
        {
            volume++;
            volumeText.text = volume.ToString();
            VolumeChange();
        }
    }

    public void VolumeDown()
    {
        if (volume > minVolume)
        {
            volume--;
            volumeText.text = volume.ToString();
            VolumeChange();
        }
    }

    private void VolumeChange()
    {
        
        float normalizedVolume = (float)volume / maxVolume;
        float mixerVolume = Mathf.Log10(Mathf.Clamp(normalizedVolume, 0, 1f)) * 20f;

        audioMixer.SetFloat("MasterVolume", mixerVolume);
    } // ¢Í¢Í¢Í
}
