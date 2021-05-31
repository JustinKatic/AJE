using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableSoundObj : ScriptableObject
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] AudioClipVariable toPlay;
    [SerializeField] GameEvent playOneShot;


    public void Play()
    {
        toPlay.Value = clips[Random.Range(0, clips.Length)];    
        playOneShot.Raise();
    }

}
