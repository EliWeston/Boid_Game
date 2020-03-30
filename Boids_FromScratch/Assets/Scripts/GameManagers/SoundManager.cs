using UnityEngine;

public class SoundManager : MonoBehaviour {

    private AudioSource _sfxSource;
    private AudioSource _bgmSource;


	// Use this for initialization
	void Awake () {

        _sfxSource = gameObject.AddComponent<AudioSource>();
        _bgmSource = gameObject.AddComponent<AudioSource>();
	}

    public void PlayBackgroundClip(AudioClip audioClip)
    {
        _bgmSource.clip = audioClip;
        _bgmSource.Play();
    }

    public void StopBackgrounfClip()
    {
        if (_bgmSource.isPlaying)
        {
            _bgmSource.Stop();
        }
    }

    public void PlaySFXClip(AudioClip audioClip)
    {
        _sfxSource.PlayOneShot(audioClip, 0.02F);
    }
}
