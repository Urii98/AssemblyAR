using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class InstructionsControllerImages : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private Image fullStepImageUI;

    [Header("Instruction Steps Images")]
    [SerializeField] private Sprite[] stepImages;

    [Header("Animation Controllers")]
    [SerializeField] private StepAnimationController animationController, animationControllerAR;

    [Header("Current Step Text")]
    [SerializeField] private TextMeshProUGUI _stepText;

    [SerializeField] private BackButtonWarningPanel backButtonWarningPanel;
    [SerializeField] private float _timeToWaitCongratsPanel;

    private int currentStepIndex = 0;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (stepImages.Length > 0)
        {
            UpdateUI();
            animationController.ActivateStepObject(currentStepIndex);
            animationControllerAR.ActivateStepObject(currentStepIndex);
        }
    }

    public void NextStep()
    {
        if (currentStepIndex + 1 < stepImages.Length)
        {
            currentStepIndex++;
            UpdateUI();
            animationController.ActivateStepObject(currentStepIndex);
            animationControllerAR.ActivateStepObject(currentStepIndex);
            CheckFinalStep();
        }

    }

    public void PreviousStep()
    {
        if (currentStepIndex > 0)
        {
            currentStepIndex--;
            UpdateUI();
            animationController.ActivateStepObject(currentStepIndex);
            animationControllerAR.ActivateStepObject(currentStepIndex);
        }
    }

    private void UpdateUI()
    {
        fullStepImageUI.sprite = stepImages[currentStepIndex];
        _stepText.text = (currentStepIndex+1).ToString() + " / 7";
    }

    private void CheckFinalStep()
    {
        if (currentStepIndex == stepImages.Length - 1)
        {
            StartCoroutine(FinalStepRoutine());
        }
    }

    private IEnumerator FinalStepRoutine()
    {
        int lastIndex = currentStepIndex;
        yield return new WaitForSeconds(_timeToWaitCongratsPanel);

        if (currentStepIndex == lastIndex)
        {
            ShowPanel();
        }
    }

    private void ShowPanel()
    {
        backButtonWarningPanel.ShowWarningPopup();
        _audioSource.Play();
    }
}
