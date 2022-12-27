using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    AudioClip[] MusicFiles;
    AudioSource source;
    int last = -1;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        MusicFiles = Resources.LoadAll<AudioClip>("Music");
        source = GetComponent<AudioSource>();
        last = Random.Range(0, MusicFiles.Length);
        source.PlayOneShot(MusicFiles[last]);
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            int newTrack = Random.Range(0, MusicFiles.Length);

            while (newTrack == last)
            {
                newTrack = Random.Range(0, MusicFiles.Length);
            }
            last = newTrack;
            source.PlayOneShot(MusicFiles[newTrack]);
        }
    }
}
