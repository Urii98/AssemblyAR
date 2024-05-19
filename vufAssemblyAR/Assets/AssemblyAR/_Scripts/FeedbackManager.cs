using UnityEngine;

public class FeedbackManager : MonoBehaviour
{
    public static FeedbackManager Instance { get; private set; }

    [SerializeField] private AudioSource successAudioSource;

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySuccessFeedback()
    {
        
        if (successAudioSource != null)
        {
            successAudioSource.Play();
        }

        
#if UNITY_ANDROID
        Handheld.Vibrate();
#endif
    }
}
