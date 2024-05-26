using System.Collections;
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
                StartCoroutine(DisableIndicatorPeriodically());
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

    IEnumerator DisableIndicatorPeriodically()
    {
        while (true) 
        {
            yield return new WaitForSeconds(3);

            
            GameObject[] indicatorObjects = GameObject.FindGameObjectsWithTag("Indicator");
            foreach (GameObject indicator in indicatorObjects)
            {
                if (indicator != null)
                {
                    indicator.SetActive(false);  
                    
                }
            }
        }
    }
}
