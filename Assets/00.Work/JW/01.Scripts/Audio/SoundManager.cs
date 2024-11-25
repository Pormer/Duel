using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

public class SoundManager : MonoSingleton<SoundManager>
{
    private List<AudioSource> _sources;
    [SerializeField] private int audioSourceCount = 5;

    [SerializeField] AudioMixerGroup mixerGroup;
    private GameObject sfxPlayer;

    private void Awake()
    {
        _sources = new List<AudioSource>();

        sfxPlayer = new GameObject() { name = "SFX Player" };
        sfxPlayer.transform.SetParent(transform);

        for (int i = 0; i < audioSourceCount; i++)
        {
            var item = sfxPlayer.AddComponent<AudioSource>();
            item.playOnAwake = false;
            item.loop = false;
            item.volume = 0.5f;
            item.outputAudioMixerGroup = mixerGroup;
            _sources.Add(item);
        }
    }

    public SoundSO PlaySFX(SoundSO soundData)
    {
        if (TryGetValue(_sources, out AudioSource source))
        {
            source.clip = soundData.clip;
            source.volume = soundData.voluem;
            source.pitch = soundData.pitch;
            source.Play();
        }
        else
        {
            var item = sfxPlayer.AddComponent<AudioSource>();
            item.playOnAwake = false;
            item.loop = false;
            item.volume = soundData.voluem;
            item.pitch = soundData.pitch;
            item.outputAudioMixerGroup = mixerGroup;
            _sources.Add(item);

            item.clip = soundData.clip;
            item.Play();
        }

        return soundData;
    }

    private static bool TryGetValue(List<AudioSource> list, out AudioSource value)
    {
        foreach (var item in list)
        {
            if (item.isPlaying) continue;

            value = item;
            return true;
        }

        value = null;
        return false;
    }
}