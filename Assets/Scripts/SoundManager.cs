using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SoundManager : MonoBehaviour {

    private const float TRANSITION_TIME = 0.01f;

    public AudioMixerSnapshot[] saturationStates;

    public AudioSource sfxSource;

    public AudioClip jumpSound;
    public AudioClip storyBoffSound;
    public AudioClip[] voiceSounds;
    public AudioClip[] checkpointSounds;

    void OnEnable()
    {
        EventManager.transitionMusic += TransitionMusic;
        EventManager.jump += Play_JumpSound;
        EventManager.boffSound += Play_BoffSound;
        EventManager.updateCheckpoint += Play_CheckpointSound;
        EventManager.voiceSound += Play_VoiceSound;
    }

    void OnDisable()
    {
        EventManager.transitionMusic -= TransitionMusic;
        EventManager.jump -= Play_JumpSound;
        EventManager.boffSound -= Play_BoffSound;
        EventManager.updateCheckpoint -= Play_CheckpointSound;
        EventManager.voiceSound -= Play_VoiceSound;
    }


    void Start () {
        saturationStates[0].TransitionTo(TRANSITION_TIME);
    }

    void TransitionMusic(int index)
    {
        saturationStates[index].TransitionTo(TRANSITION_TIME);
    }

    void Play_JumpSound()
    {
        sfxSource.PlayOneShot(jumpSound);
    }

    void Play_BoffSound()
    {
        sfxSource.PlayOneShot(storyBoffSound);
    }

    void Play_VoiceSound()
    {
        int RNGsus = Mathf.FloorToInt(Random.value * voiceSounds.Length);
        sfxSource.PlayOneShot(voiceSounds[RNGsus]);
    }

    void Play_CheckpointSound(Vector3 unused)
    {
        int RNGsus = Mathf.FloorToInt(Random.value * checkpointSounds.Length);
        sfxSource.PlayOneShot(checkpointSounds[RNGsus]);
    }



}
