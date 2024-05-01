using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SwapImages : MonoBehaviour
{
    [SerializeField] private Sprite _sprite1; 
    [SerializeField] private Sprite _sprite2;
    [SerializeField] private Image _buttonImage; 

    private Button _myButton;
    private bool switched = false;

    private void Awake()
    {
        _myButton = GetComponent<Button>();
    }
    void Start()
    {
        _myButton.onClick.AddListener(ToggleImage); 
    }

    void ToggleImage()
    {
        if (!switched)
        {
            _buttonImage.sprite = _sprite2;
            switched = true;
        }
        else
        {
            _buttonImage.sprite = _sprite1;
            switched = false;
        }
    }
}
