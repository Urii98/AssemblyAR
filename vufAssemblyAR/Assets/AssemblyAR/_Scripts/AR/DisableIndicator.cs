using System.Collections;
using UnityEngine;

public class DisableIndicator : MonoBehaviour
{
    
    public void DisableSpecificIndicator()
    {
        
        GameObject indicatorObject = GameObject.Find("Indicator");
        if (indicatorObject != null)
        {
            indicatorObject.SetActive(false);
            Debug.Log("Indicator específico desactivado: " + indicatorObject.name);
        }
        else
        {
            Debug.LogWarning("No se encontró el GameObject con nombre 'Indicator'");
        }

        
        StartCoroutine(DisableIndicatorPeriodically());
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
