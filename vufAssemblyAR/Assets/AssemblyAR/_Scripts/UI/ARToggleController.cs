using UnityEngine;
using UnityEngine.UI;

public class ARToggleController : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite ARon;
    [SerializeField] private Sprite ARoff;

    [Header("GameObjects")]
    [SerializeField] private GameObject AR_Object;
    [SerializeField] private GameObject _3D_Object;

    private Button button;
    private Image buttonImage;
    private bool isAR = true;

    private float a;

    void Awake()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
    }

    void Start()
    {
        UpdateState();
        button.onClick.AddListener(ToggleAR);
    }

    void ToggleAR()
    {
        isAR = !isAR;
        UpdateState();
    }

    private void UpdateState()
    {
        if (isAR)
        {
            buttonImage.sprite = ARon;
            AR_Object.SetActive(true);
            _3D_Object.SetActive(false);
        }
        else
        {
            buttonImage.sprite = ARoff;
            AR_Object.SetActive(false);
            _3D_Object.SetActive(true);
        }
    }
}
