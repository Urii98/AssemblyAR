using UnityEngine;
using UnityEngine.UI; 

public class ChairSpriteChanger : MonoBehaviour
{
    [SerializeField]
    private Image targetImage; 

    [SerializeField]
    private Sprite newSprite; 

    void Awake()
    {

        Button button = GetComponent<Button>();
        if (button != null)
        {

            button.onClick.AddListener(ChangeImageSprite);
        }

    }

    private void ChangeImageSprite()
    {
        if (targetImage != null)
        {
            targetImage.sprite = newSprite;
        }

    }
}
