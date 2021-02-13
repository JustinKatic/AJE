using UnityEngine;
public class AudioController : MonoBehaviour
{
    [SerializeField] AudioClipVariable oneShotClip;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] FloatVariable master, sfx, music;
    private void OnEnable()
    {
        UpdateVolume();
        musicSource.Play();
    }
    public void UpdateVolume()
    {
        SFXSource.volume = master.Value * sfx.Value;
        musicSource.volume = master.Value * music.Value;
    }
    public void PlayClip()
    {
        SFXSource.PlayOneShot(oneShotClip.Value);
    }
    public void ChangeMusicClip()
    {
        musicSource.clip = oneShotClip.Value;
        musicSource.Play();
    }
}
