using UnityEngine;
using UnityEngine.UI;

public class VibrationToggleButton : MonoBehaviour
{
    [SerializeField] private Sprite vibrationOnSprite;
    [SerializeField] private Sprite vibrationOffSprite;

    private Button button;
    private Image buttonImage;

    void Awake()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
        
        
    }

    void Start()
    {
        button.onClick.AddListener(ToggleVibration);
    }

    private void ToggleVibration()
    {
        if (FeedbackManager.Instance != null)
        {
            FeedbackManager.Instance.isVibrationEnabled = !FeedbackManager.Instance.isVibrationEnabled;
            UpdateButtonSprite(FeedbackManager.Instance.isVibrationEnabled);
        }
    }

    private void UpdateButtonSprite(bool isVibrationEnabled)
    {
        buttonImage.sprite = isVibrationEnabled ? vibrationOnSprite : vibrationOffSprite;
    }
}
