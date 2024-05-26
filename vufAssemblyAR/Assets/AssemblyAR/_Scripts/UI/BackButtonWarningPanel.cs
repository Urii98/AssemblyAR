using UnityEngine;
using DG.Tweening;
public class BackButtonWarningPanel : MonoBehaviour
{
    [Header("Warning Popup")]
    [SerializeField] private GameObject _warningPopup;
    [SerializeField] private CanvasGroup _warningPopupCanvasGroup;
    [SerializeField] private Ease _popupEase;
    [SerializeField] private float _popupTime;
    
    public void ShowWarningPopup()
    {
        _warningPopup.transform.DOLocalMoveY(0, _popupTime).SetEase(_popupEase);
        _warningPopupCanvasGroup.DOFade(1f, _popupTime).SetEase(_popupEase);

    }
    public void HideWarningPopup()
    {
        _warningPopup.transform.DOLocalMoveY(1250, _popupTime).SetEase(_popupEase);
        _warningPopupCanvasGroup.DOFade(0f, _popupTime).SetEase(_popupEase);

    }
}
