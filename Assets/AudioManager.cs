using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField] AudioClip rotationSound;
    [SerializeField] AudioClip filledSound;
    [SerializeField] AudioClip groundSound;
    [Space(10)]
    public AudioSource sfx_source;
    public AudioSource background_source;
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        sfx_source.volume = PlayerPrefs.GetFloat("SFX_slider", 0.5f);
        background_source.volume = PlayerPrefs.GetFloat("background_slider", .25f);
        DontDestroyOnLoad(this);
    }

    public void PlayRotationSound()
    {
        sfx_source.clip = rotationSound;
        sfx_source.Play();
    }

    public void PlayRowFilled()
    {
        sfx_source.clip = filledSound;
        sfx_source.Play();
    }

    public void HitGroundSound()
    {
        sfx_source.clip = groundSound;
        sfx_source.Play();
    }
}
