using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShareIkeaProduct : MonoBehaviour, IPointerUpHandler
{
    
    public void OnPointerUp(PointerEventData eventData)
    {
        ShareProductInfo();
    }

    private void ShareProductInfo()
    {
        string productName = "SANDSBERG";
        string productUrl = "https://www.ikea.com/es/es/p/sandsberg-silla-negro-tinte-marron-70412960/";
        string message = "¡Echa un vistazo a esta silla de IKEA llamada " + productName + "! Puedes verla aquí: " + productUrl;

        new NativeShare()
            .SetSubject("Producto IKEA: " + productName)
            .SetText(message)
            .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();
    }
}
