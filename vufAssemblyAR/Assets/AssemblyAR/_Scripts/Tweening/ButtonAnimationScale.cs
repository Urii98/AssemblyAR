using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonAnimationScale : UIBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float scaleMultiplier = 1.1f;
    [SerializeField] private float time = 0.25f;
    [SerializeField] private Ease ease = Ease.OutBack;
    private Vector3 baseScale;

    protected override void Start()
    {
        baseScale = transform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(baseScale * scaleMultiplier, time).SetEase(ease);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(baseScale, time).SetEase(ease);
    }


}
