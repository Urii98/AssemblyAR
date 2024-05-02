using UnityEngine;

public class HorizontalScroll : MonoBehaviour
{
    [SerializeField]
    private RectTransform content;  

    [SerializeField]
    private RectTransform scrollbarImage;  

    [SerializeField]
    private float maxContentPos = -7060f;

    [SerializeField]
    private float minImageX;
    [SerializeField]
    private float maxImageX;  


    void Update()
    {
        if (content != null && scrollbarImage != null)
        {
            UpdateScrollbarImagePosition();
        }
    }

    void UpdateScrollbarImagePosition()
    {
        
        float contentPos = content.anchoredPosition.x;  

        
        float scrollbarImagePosX = Mathf.InverseLerp(maxContentPos, 0, contentPos);

        
        scrollbarImagePosX = Mathf.Lerp(maxImageX, minImageX, scrollbarImagePosX);

        
        scrollbarImage.anchoredPosition = new Vector2(scrollbarImagePosX, scrollbarImage.anchoredPosition.y);
    }
}
