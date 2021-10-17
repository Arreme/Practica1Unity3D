using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioClip[] _audioList;
    [SerializeField] private AudioSource _source;
    public void playAudio(int i)
    {
        _source.clip = _audioList[i];
        _source.Play();
    }
}
