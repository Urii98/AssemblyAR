using UnityEngine;

public class FeedbackManager : MonoBehaviour
{
    public static FeedbackManager Instance { get; private set; }

    [SerializeField] private AudioSource successAudioSource;

    public bool isSoundEnabled = true;
    public bool isVibrationEnabled = true;

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

            if(isSoundEnabled)
            {
                successAudioSource.Play();
            }
            
        }

        
#if UNITY_ANDROID

        if(isVibrationEnabled) 
        {
            Handheld.Vibrate();
        }
        
#endif
    }
}
