using System.Collections;
using UnityEngine;

public class FadeTime : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToActivate; 
    void Start()
    {
        
        StartCoroutine(ActivateAfterDelay(5.0f));
    }

    IEnumerator ActivateAfterDelay(float delay)
    {
        
        yield return new WaitForSeconds(delay);

        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }
}
