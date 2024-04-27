using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(Image))]
public class FadeIn : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject _objectToHide;
    [SerializeField] private FadeOut _fadeOut;

    [Space()]
    [SerializeField] private GameObject _logo;

    [Header(" Tweening ")]
    [SerializeField] private float _delay = 1.5f;
    [SerializeField] private float _duration = 0.75f;
    [SerializeField] private Ease _fadeEase = Ease.InSine;
    [SerializeField] private float _fadeValue = 1f;

    [Header("Logo Animation")]
    [SerializeField] private Vector3 _logoStartScale = Vector3.zero;
    [SerializeField] private Vector3 _logoEndScale = new Vector3(1, 1, 1);
    [SerializeField] private float _logoScaleDuration = 1f; 
    [SerializeField] private float _scaleMultiplier = 2f; 
    [SerializeField] private Ease _logoScaleEase = Ease.OutBack; 

    private Image _imageToFade;

    void Start()
    {
        _imageToFade = GetComponent<Image>();
        StartCoroutine(AnimateLogo());
    }

    private IEnumerator AnimateLogo()
    {
        _logo.transform.localScale = _logoStartScale; 

        yield return new WaitForSeconds(_delay);

        _logo.transform.DOScale(_logoEndScale * _scaleMultiplier, _logoScaleDuration).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            _logo.transform.DOScale(_logoEndScale, _logoScaleDuration).SetEase(Ease.InQuad).OnComplete(() =>
            {
                StartCoroutine(DoFadeIn());
            });
        });


        //_logo.transform.DOScale(_logoEndScale, _logoScaleDuration).SetEase(_logoScaleEase).OnComplete(() =>
        //{

        //    StartCoroutine(DoFadeIn());
        //});
    }

    private IEnumerator DoFadeIn()
    {
        yield return new WaitForSeconds(_delay);

        _imageToFade.color = new Color(_imageToFade.color.r, _imageToFade.color.g, _imageToFade.color.b, 0); 

        _imageToFade.DOFade(_fadeValue, _duration).SetEase(_fadeEase).OnComplete(() =>
        {
            _objectToHide.SetActive(false);
            _fadeOut.FadeOutFromValue(_fadeValue);
        });
        
    }
}
