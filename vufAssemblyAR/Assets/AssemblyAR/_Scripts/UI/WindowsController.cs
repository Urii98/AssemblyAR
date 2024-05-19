using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsController : MonoBehaviour
{
    [Header("Windows")]
    [SerializeField] private GameObject _arPlaneWindow;
    [SerializeField] private GameObject _tutorialWindow;

  
    public void ChangeToTutorialWindow()
    {
        _arPlaneWindow.SetActive(false);
        _tutorialWindow.SetActive(true);

    }
}
