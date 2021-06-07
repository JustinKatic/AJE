using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMusic : MonoBehaviour
{
    public string musicName;

    void Start()
    {
        MusicAudioManager.instance.Play(musicName);
    }
}
