using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class VisibilityController : MonoBehaviour
{
    [SerializeField] private GameObject uiCanvas;
    [SerializeField] private GameObject uiElement;

    [Header("Tweening")]
    [SerializeField] private float _time = 1.2f;
    [SerializeField] private Ease _ease = Ease.InOutSine;

    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ToggleUI);

        
        uiCanvas.SetActive(false);
        uiElement.transform.localScale = Vector3.zero;
    }

    public void ToggleUI()
    {
        if (uiCanvas.activeSelf)
        {
            
            uiElement.transform.DOScale(0, _time).SetEase(_ease).OnComplete(() =>
            {
                uiCanvas.SetActive(false);
            });
        }
        else
        {
            uiCanvas.SetActive(true);
            
            uiElement.transform.DOScale(1, _time).SetEase(_ease);
        }
    }
}
