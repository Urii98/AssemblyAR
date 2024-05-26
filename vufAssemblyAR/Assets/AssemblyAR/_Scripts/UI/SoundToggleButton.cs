using UnityEngine;
using UnityEngine.UI;

public class SoundToggleButton : MonoBehaviour
{
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;

    private Button button;
    private Image buttonImage;

    void Awake()
    {
        
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();

        
        
    }

    void Start()
    {
        
        button.onClick.AddListener(ToggleSound);
    }

    private void ToggleSound()
    {
        
        if (FeedbackManager.Instance != null)
        {
            FeedbackManager.Instance.isSoundEnabled = !FeedbackManager.Instance.isSoundEnabled;
            
            UpdateButtonSprite(FeedbackManager.Instance.isSoundEnabled);
        }
    }

    private void UpdateButtonSprite(bool isSoundEnabled)
    {
        
        buttonImage.sprite = isSoundEnabled ? soundOnSprite : soundOffSprite;
    }
}
