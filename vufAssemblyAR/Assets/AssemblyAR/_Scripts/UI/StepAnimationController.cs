using UnityEngine;

public class StepAnimationController : MonoBehaviour
{
    [SerializeField] private GameObject[] stepGameObjects;

    void Start()
    {
        
        foreach (GameObject obj in stepGameObjects)
        {
            obj.SetActive(false);
        }
        
        //if (stepGameObjects.Length > 0)
        //    stepGameObjects[0].SetActive(true);
    }

    public void ActivateStepObject(int index)
    {
        
        foreach (GameObject obj in stepGameObjects)
        {
            obj.SetActive(false);
        }

        
        if (index < stepGameObjects.Length)
        {
            stepGameObjects[index].SetActive(true);
        }
    }
}
