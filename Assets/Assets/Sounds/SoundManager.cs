using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    AudioSource audioSource;
    [SerializeField] AudioClip bounceSound;
    [SerializeField] AudioClip goalSound;
    [SerializeField] AudioClip clappingSound;
    bool isPlaying = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMusic();
    }

    public void PlayMusic()
    {
        isPlaying = true;
        if (!isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        isPlaying = false;
        if (isPlaying)
        {
            audioSource.Stop();
        }
    }

    void Update()
    {


    }

    public void Bounce()
    {
        audioSource.PlayOneShot(bounceSound);
    }

    public void GoalSound()
    {
        audioSource.PlayOneShot(goalSound);
    }

    public void ClapSound()
    {
        audioSource.PlayOneShot(clappingSound);
    }

}
