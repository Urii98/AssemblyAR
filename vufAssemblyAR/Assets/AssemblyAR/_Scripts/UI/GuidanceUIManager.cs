using UnityEngine;
using DG.Tweening;

public class GuidanceUIManager : MonoBehaviour
{
    [Header("GuidanceUI")]
    [SerializeField] GameObject GuidanceText;
    [SerializeField] GameObject HelpButton;
    [SerializeField] Ease guidanceEase;
    [SerializeField] float guidanceTweenTime = 0.25f; 

    [Header("HelpPanel")]
    [SerializeField] GameObject HelpPanel;
    [SerializeField] GameObject CloseHelpPanelButton;
    [SerializeField] Ease helpEase;
    [SerializeField] float helpTweenTime = 0.25f; 

    private void Start()
    {
        HelpPanel.transform.localScale = Vector3.zero;
    }

    public void ShowGuidanceUI()
    {

        GuidanceText.transform.DOMoveY(Screen.height - 100, guidanceTweenTime).SetEase(guidanceEase);
        HelpButton.transform.DOMove(new Vector3(Screen.width - 100, Screen.height - 100, 0), guidanceTweenTime).SetEase(guidanceEase);
    }

    public void HideGuidanceUI()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(GuidanceText.transform.DOMoveY(Screen.height + 100, guidanceTweenTime).SetEase(guidanceEase));
        mySequence.Join(HelpButton.transform.DOMove(new Vector3(Screen.width + 100, Screen.height + 100, 0), guidanceTweenTime).SetEase(guidanceEase));
        mySequence.OnComplete(ShowHelpPanel);
    }

    public void ShowHelpPanel()
    {

        HelpPanel.transform.DOScale(1, helpTweenTime).SetEase(helpEase);
    }

    public void HideHelpPanel()
    {
        HelpPanel.transform.DOScale(0, helpTweenTime).SetEase(helpEase).OnComplete(ShowGuidanceUI);
    }



    public Sequence HideEverything()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(HelpPanel.transform.DOScale(0, helpTweenTime).SetEase(helpEase));

        sequence.Join(GuidanceText.transform.DOMoveY(Screen.height + 100, guidanceTweenTime).SetEase(guidanceEase));
        sequence.Join(HelpButton.transform.DOMove(new Vector3(Screen.width + 100, Screen.height + 100, 0), guidanceTweenTime).SetEase(guidanceEase));

        return sequence;
    }

}
