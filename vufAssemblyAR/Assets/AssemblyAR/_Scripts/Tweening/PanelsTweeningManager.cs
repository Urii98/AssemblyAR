using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PanelsTweeningManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private List<GameObject> _panels;

    [Header(" Tweening ")]
    [SerializeField] private float _tweenTime = 0.5f;
    [SerializeField] private Ease _ease = Ease.Linear;

    [SerializeField] private bool startAtLastScren = false;

    private int currentIndex = 0;


    void Start()
    {
        if(startAtLastScren)
        {
            StartAtLastScreen();
        }
        else
        {
            InitializePanelsPosition();

        }
        UpdateCanvasGroups();
    }

    void InitializePanelsPosition()
    {
        for (int i = 0; i < _panels.Count; i++)
        {
            _panels[i].transform.localPosition = new Vector3(1920 * i, 0, 0);
        }
    }

    void StartAtLastScreen()
    {
        currentIndex = 2;
        for (int i = 0; i < _panels.Count; i++)
        {
            _panels[0].transform.localPosition = new Vector3(-1920 * 2, 0, 0);
            _panels[1].transform.localPosition = new Vector3(-1920 * 1, 0, 0);
            _panels[2].transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    public void MovePanelsRight()
    {
        if (currentIndex > 0)
        {
            foreach (var panel in _panels)
            {
                panel.transform.DOLocalMoveX(panel.transform.localPosition.x + 1920, _tweenTime).SetEase(_ease);
            }
            currentIndex--;
            UpdateCanvasGroups();
        }
    }

    public void MovePanelsLeft()
    {
        if (currentIndex < _panels.Count - 1)
        {
            foreach (var panel in _panels)
            {
                panel.transform.DOLocalMoveX(panel.transform.localPosition.x - 1920, _tweenTime).SetEase(_ease);
            }
            currentIndex++;
            UpdateCanvasGroups();
        }
    }

    private void UpdateCanvasGroups()
    {
        for (int i = 0; i < _panels.Count; i++)
        {
            CanvasGroup canvasGroup = _panels[i].GetComponent<CanvasGroup>();
            canvasGroup.blocksRaycasts = (i == currentIndex) ? true : false;
        }
    }
}
