using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(Image))]
public class FadeIn : MonoBehaviour
{
    private Image _imageToFade;
    [SerializeField] private float _delay = 1.5f; 
    [SerializeField] private float _duration = 0.75f; 
    [SerializeField] private Ease _fadeEase = Ease.InSine; 


    void Start()
    {
        _imageToFade = GetComponent<Image>();
        StartCoroutine(DoFadeIn());
    }

    private IEnumerator DoFadeIn()
    {
        yield return new WaitForSeconds(1.5f);

        _imageToFade.color = new Color(_imageToFade.color.r, _imageToFade.color.g, _imageToFade.color.b, 0);


        _imageToFade.DOFade(0.9f, _duration).SetEase(_fadeEase).OnComplete(() =>
        {
            //cambio a escena main menu
            SceneManager.LoadScene("MainMenuScene");
        });
    }



}
