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


        GameObject indicatorObject = GameObject.FindGameObjectWithTag("Indicator");
        if (indicatorObject != null)
        {
            
            MeshRenderer meshRenderer = indicatorObject.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = false;
            }
            else
            {
                Debug.LogWarning("No componente MeshRenderer en el objeto con tag 'Indicator'");
            }
        }
        else
        {
            Debug.LogWarning("No objeto con el tag 'Indicator'");
        }


    }
}
