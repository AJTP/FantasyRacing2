using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Musica : MonoBehaviour
{
    private static Musica instancia = null;

    public static Musica GetInstance() { return instancia; }
    AudioSource _audioSource;
    public AudioClip[] musica = new AudioClip[3];
    private void Awake()
    {
        if (instancia == null)
            instancia = this;
        else if (instancia != this)
            Destroy(gameObject);
            

        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        switch (arg0.name) {
            case "Ovalo":
                _audioSource.clip = musica[0];
                break;
            case "Karting":
                _audioSource.clip = musica[1];
                break;
            case "Castillo":
                _audioSource.clip = musica[2];
                break;
        }
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (_audioSource != null) {
            if (_audioSource.isPlaying) return;
            _audioSource.Play();
        }
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }

}
