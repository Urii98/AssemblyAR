using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DelayedSound : MonoBehaviour
{
    [SerializeField] private float delayInSeconds = 5f;  
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke(nameof(PlaySound), delayInSeconds);
    }

    private void PlaySound()
    {
        Debug.Log(audioSource.clip.length);

        if (audioSource.clip != null)
        {
            audioSource.Play();
            audioSource.DOFade(0f, audioSource.clip.length/1.5f).SetEase(Ease.Linear);

        }
    }
}
