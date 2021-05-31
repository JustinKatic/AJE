using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableSoundObjNonOneShot : ScriptableObject
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] AudioClipVariable toPlay;
    [SerializeField] GameEvent PlayClip;
    [SerializeField] GameEvent pauseOneShot;


    public void Play()
    {
        toPlay.Value = clips[Random.Range(0, clips.Length)];
        PlayClip.Raise();
    }

}
