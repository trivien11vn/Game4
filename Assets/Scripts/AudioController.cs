using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Ins;
    [Range(0,1)]
    public float musicVolume;
    [Range(0,1)]
    public float soundVolume;

    public AudioSource musicSource;
    public AudioSource soundSource;
    public AudioClip[] backgroundMusic;
    public AudioClip trueAnswer;
    public AudioClip loseAnswer;
    public AudioClip win;

    private void Awake(){
        MakeSingleton();
    }
    void Start(){
        PlayBackgroundMusic();
    }

    private void Update(){
        if(musicSource && soundSource){
            musicSource.volume = musicVolume;
            soundSource.volume = soundVolume;
        }
    }
    void PlayBackgroundMusic(){
        if(musicSource && backgroundMusic!=null && backgroundMusic.Length > 0){
            int randomm = Random.Range(0, backgroundMusic.Length);
            if(backgroundMusic[randomm] != null){
                musicSource.clip = backgroundMusic[randomm];
                musicSource.Play();
                musicSource.volume = musicVolume;
            }
        }
    }
    public void PlaySound(AudioClip sound){
        if(soundSource && sound){
            soundSource.volume = soundVolume;
            soundSource.PlayOneShot(sound);
        }
    }
    public void PlayRightSound(){
        PlaySound(trueAnswer);
    }
    public void PlayLoseSound(){
        PlaySound(loseAnswer);
    }
    public void PlayWinSound(){
        PlaySound(win);
    }
    public void StopMusic(){
        if(musicSource) musicSource.Stop();
    }
    void MakeSingleton(){
        if(Ins == null){
            Ins = this;
        }
        else{
            Destroy(gameObject);
        }
    }
}
