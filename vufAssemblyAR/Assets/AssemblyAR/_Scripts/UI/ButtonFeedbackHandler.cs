using UnityEngine;
using UnityEngine.UI;

public class ButtonFeedbackHandler : MonoBehaviour
{
    private Button button;
    void Start()
    {
        
        button = GetComponent<Button>();

        
        if (button != null && FeedbackManager.Instance != null)
        {
            
            button.onClick.AddListener(FeedbackManager.Instance.PlaySuccessFeedback);
        }
        else
        {
            Debug.LogWarning("ButtonFeedbackHandler: No se encontr� Button o FeedbackManager no est� disponible.");
        }
    }
}
