using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AnimationAudioTrigger : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    public AudioClip[] growlSounds;
    private AudioSource soundSource;
    void Start()
    {
        soundSource = GetComponent<AudioSource>();      //Etsii AudioSource-komponentteja ja asettaa ne 
                                                        //muuttujaan soundSource
    }

    public void LeftFoot()
    {
        int n = Random.Range(1, footstepSounds.Length); //Arpoo minkä askeleen äänen toistaa
        soundSource.clip = footstepSounds[n];           
        soundSource.PlayOneShot(soundSource.clip);      //Toistaa askel-äänen

        footstepSounds[n] = footstepSounds[0];          //Tällä varmistetaan, ettei ääntä toisteta kuin kerran
        footstepSounds[0] = soundSource.clip;
    }

        public void RightFoot()
    {
        int n = Random.Range(1, footstepSounds.Length); //Arpoo minkä askeleen äänen toistaa
        soundSource.clip = footstepSounds[n];           
        soundSource.PlayOneShot(soundSource.clip);      //Toistaa askel-äänen

        footstepSounds[n] = footstepSounds[0];          //Tällä varmistetaan, ettei ääntä toisteta kuin kerran
        footstepSounds[0] = soundSource.clip;
    }

    public void GrowlSound()
    {
        int n = Random.Range(1, growlSounds.Length);    //Arpoo minkä murina äänen toistaa
        soundSource.clip = growlSounds[n];
        soundSource.PlayOneShot(soundSource.clip);      //Toistaa murina-äänen

        growlSounds[n] = growlSounds[0];                 //Tällä varmistetaan, ettei ääntä toisteta kuin kerran
        growlSounds[0] = soundSource.clip;
    }
}
