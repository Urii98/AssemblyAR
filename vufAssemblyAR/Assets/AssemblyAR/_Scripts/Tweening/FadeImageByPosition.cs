using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeImageByPosition : MonoBehaviour
{
    private Image imageComponent;

    [SerializeField] private Transform _positionYToTrack;
    

    void Start()
    {
        imageComponent = GetComponent<Image>();
    }

    void Update()
    {
        
        float alpha = Mathf.InverseLerp(850, 0, _positionYToTrack.localPosition.y);

        
        imageComponent.color = new Color(imageComponent.color.r, imageComponent.color.g, imageComponent.color.b, alpha);
    }
}
