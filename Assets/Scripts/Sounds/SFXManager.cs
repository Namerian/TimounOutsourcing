using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SFXManager : MonoBehaviour {
    public static SFXManager instance;

    public List<AudioClip> combatSounds;
    public List<AudioSource> soundsBeingPlayed;

    public float lowPitchRange = .8f;              //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.2f;            //The highest a sound effect will be randomly pitched.


    public float lowVolumeRange = 0.5f;
    public float HighBolumeRange = 1.0f;

    public GameObject speakerPrefab;

    private GameObject _speaker;

    #region Helpers
    public class SFXNames
    {
        public const string Hit_Brutal_Medium = "Hit_Brutal_Medium";
        public const string Hit_Sharp_Medium = "Hit_Sharp_Medium";
        public const string Hit_ArmorBlock_Medium = "Hit_ArmorBlock_Medium";
        public const string Hit_BadTiming = "Hit_BadTiming";
        public const string Armor_Crack = "Armor_Crack";
        public const string Armor_Break = "Armor_Break";
        public const string Armor_Regenerate = "Armor_Regenerate";
        public const string Guard_Up = "Guard_Up";
        public const string Guard_Down = "Guard_Down";
        public const string Guard = "Guard";
        public const string Guard_Perfect = "Guard_Perfect";
        public const string Turn_End = "Turn_End";
        public const string Turn_Start = "Turn_Start";
        public const string Attack_Perfect = "Attack_Perfect";
        public const string Fury_Start = "Fury_Start";
        public const string Fury_Cast = "Fury_Cast";
        public const string Fury_Execute = "Fury_Execute";
        public const string Fury_Final = "Fury_Final";
    } 
    #endregion

    void Awake()
    {
        if (instance == null)
        {
            //DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        FillList();       
        speakerPrefab = (GameObject)Resources.Load("Audio/SpeakerPrefab");
    }

    void FillList()
    {
        Object[] allCombatSFX = Resources.LoadAll("Audio/SFX/Combat", typeof(AudioClip));
        foreach (Object parObject in allCombatSFX)
        {
            combatSounds.Add((AudioClip)parObject);
        }
    }

    public AudioClip FindInCombatList(string soundName)
    {
        AudioClip item = combatSounds.FirstOrDefault(i => i.name == soundName);

        if (item != null)
        {
            return item;
        }
        else
        {
            return null;
        }
    }

    public void PlaySingle(GameObject source, AudioClip clip, bool isRandomPitch = false, bool isRandomVolume = false, float volume = 1)
    {
        _speaker = (GameObject)Instantiate(speakerPrefab, source.transform.position, source.transform.rotation);
        AudioSource audioSource = _speaker.GetComponent<AudioSource>();
        if (isRandomPitch)
        {
            float randomPitch = Random.Range(lowPitchRange, highPitchRange);
            audioSource.pitch = randomPitch;
        }

        if (isRandomVolume)
        {
            volume = Random.Range(Mathf.Max(lowVolumeRange, volume - lowVolumeRange), volume);
            audioSource.volume = volume;
        }
        else
        {
            audioSource.volume = volume;
        }
        audioSource.clip = clip;
        audioSource.Play();
        _speaker.AddComponent<DestroySFXByTime>().delayToDestroy = clip.length;
        soundsBeingPlayed.Add(audioSource);
    }

    public void RandomizeSfx(GameObject source, bool isRandomPitch = false, bool isRandomVolume = false, float volume = 1, params AudioClip[] clips)
    {
        _speaker = (GameObject)Instantiate(speakerPrefab, source.transform.position, source.transform.rotation);
        AudioSource audioSource = _speaker.GetComponent<AudioSource>();
        AudioClip clip = clips[Random.Range(0, clips.Length)];
        if (isRandomPitch)
        {
            float randomPitch = Random.Range(lowPitchRange, highPitchRange);
            audioSource.pitch = randomPitch;
        }

        if (isRandomVolume)
        {
            volume = Random.Range(Mathf.Max(lowVolumeRange, volume - lowVolumeRange), volume);
            audioSource.volume = volume;
        }
        else
        {
            audioSource.volume = volume;
        }
        audioSource.clip = clip;
        audioSource.Play();
        _speaker.AddComponent<DestroySFXByTime>().delayToDestroy = clip.length;
        soundsBeingPlayed.Add(audioSource);
    }

    public void RemoveAudioFromList(AudioSource clip)
    {
        soundsBeingPlayed.RemoveAll(x => x.GetInstanceID() == clip.GetInstanceID());
    }

    public bool IsSoundBeingPlayed(AudioClip clip)
    {
        return soundsBeingPlayed.FirstOrDefault(i => i.clip == clip);
    }

    public void KillAllSoundsOfTYpe(AudioClip clip)
    {
        List<AudioSource> tempAudiosource = soundsBeingPlayed.Where(x => x.clip == clip).ToList();
        foreach(AudioSource audiosource in tempAudiosource)
        {
            Destroy(audiosource.gameObject);
        }
    }

    public void KillSound(AudioClip clip)
    {
        AudioSource tempAudiosource = soundsBeingPlayed.First(x => x.clip == clip);
        Destroy(tempAudiosource.gameObject);
    }
}

