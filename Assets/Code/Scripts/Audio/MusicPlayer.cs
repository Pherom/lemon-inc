using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip [] songs;

    private int currentSongIndex = 0;
    // Start is called before the first frame update


    public void Play()
    {
        AudioClip currentSong = songs[currentSongIndex];
        source.Stop();
        if (currentSong == null) return;
        source.PlayOneShot(currentSong);
    }

    public void PlayNextSong()
    {
        currentSongIndex = (currentSongIndex+1) % songs.Length;
        Play();
    }


    public void Stop()
    {
        source.Stop();
    }

}
