using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(Image))]
public class FadeOut : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject _objectToShow;

    [Header(" Tweening ")]
    [SerializeField] private float _delay = 1f;
    [SerializeField] private float _duration = 0.75f;
    [SerializeField] private Ease _fadeEase = Ease.InSine;
    [SerializeField] private float _fadeValue = 1f;

    private Image _imageToFade;
    private CanvasGroup _canvasGroupObjectToShow;


    void Start()
    {
        _canvasGroupObjectToShow = _objectToShow.GetComponent<CanvasGroup>();
        _imageToFade = GetComponent<Image>();

        _canvasGroupObjectToShow.blocksRaycasts = false;
    }


    public void FadeOutFromValue(float value)
    {
        _imageToFade.DOFade(value, 0); 

        _imageToFade.DOFade(0, _duration).SetEase(_fadeEase).OnComplete(() =>
        {
            _imageToFade.raycastTarget = false;

            _canvasGroupObjectToShow.blocksRaycasts = true;

        });
    }

}
