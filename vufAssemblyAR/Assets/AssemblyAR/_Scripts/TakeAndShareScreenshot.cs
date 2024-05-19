using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
using System.IO;

public class TakeAndShareScreenshot : MonoBehaviour, IPointerUpHandler
{


    [SerializeField] private Image _flash;
    [SerializeField] private CanvasGroup _canvasGroup;


    private void TurnOffUIContent()
    {
        _canvasGroup.alpha = 0f;
        
    }

    private void TurnOnUIContent()
    {
        _canvasGroup.alpha = 1f;
        
    }



    private IEnumerator TakeScreenshotAndShare()
    {
        TurnOffUIContent();

        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        _flash.DOFade(0.25f, 0.25f);

        //save screenshoot
        string productInfo = "SANDSBERG";
        string screenshotName = string.Format("{0}_Capture_{1}_{2}.png", Application.productName, productInfo, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
        NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(ss, Application.productName + " Captures", screenshotName);

        yield return new WaitForSeconds(0.25f);
        TurnOnUIContent();

        yield return new WaitForEndOfFrame();
        _flash.DOFade(0.0f, 0.25f);


        //share screenshot
        yield return new WaitForSeconds(0.25f);

        string filePath = Path.Combine(Application.temporaryCachePath, screenshotName);
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        new NativeShare().AddFile(filePath)
           .SetSubject("").SetText(screenshotName)
           .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
           .Share();

        
        Destroy(ss);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(TakeScreenshotAndShare());
    }
}
