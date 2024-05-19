using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class InstructionsTweening : MonoBehaviour
{
    [Header("Tweening")]
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _button;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _time = 0.5f;
    [SerializeField] private Ease _ease = Ease.Linear;
    [SerializeField] private Ease _easeText = Ease.Linear;
    [SerializeField] private float _amountToMove;

    private CanvasGroup canvasGroup;
    private bool isPanelVisible = false;
    private Vector3 panelInitialLocalPosition;
    private Vector3 buttonInitialLocalPosition;

    void Start()
    {
        canvasGroup = _panel.GetComponent<CanvasGroup>();
        panelInitialLocalPosition = _panel.transform.localPosition;
        buttonInitialLocalPosition = _button.transform.localPosition;
    }

    public void TogglePanel()
    {
        if (isPanelVisible)
        {
            HidePanel();
        }
        else
        {
            ShowPanel();
        }
        isPanelVisible = !isPanelVisible;
    }

    private void ShowPanel()
    {
        _panel.transform.DOLocalMoveX(panelInitialLocalPosition.x - _amountToMove, _time).SetEase(_ease);
        _button.transform.DOLocalMoveX(buttonInitialLocalPosition.x - _amountToMove, _time).SetEase(_ease);
        canvasGroup.DOFade(1, _time).SetEase(_ease);
        _text.DOFade(0, _time/2).SetEase(_easeText);
    }

    private void HidePanel()
    {
        _panel.transform.DOLocalMoveX(panelInitialLocalPosition.x, _time).SetEase(_ease);
        _button.transform.DOLocalMoveX(buttonInitialLocalPosition.x, _time).SetEase(_ease);
        canvasGroup.DOFade(0, _time).SetEase(_ease);
        _text.DOFade(1, _time/2).SetEase(_easeText);
    }
}
