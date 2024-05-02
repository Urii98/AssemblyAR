using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class SceneNavigation : MonoBehaviour
{
    [SerializeField]
    private string sceneName; 

    void Awake()
    {
      
        Button button = GetComponent<Button>();
        if (button != null)
        {
            
            button.onClick.AddListener(NavigateToScene);
        }

    }

    private void NavigateToScene()
    {

        SceneManager.LoadScene(sceneName);
    }
}
