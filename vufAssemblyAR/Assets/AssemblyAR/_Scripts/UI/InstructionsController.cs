using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstructionsController : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private TextMeshProUGUI titleTextUI;
    [SerializeField] private TextMeshProUGUI explanationTextUI;
    [SerializeField] private Image stepImageUI;
    [SerializeField] private TextMeshProUGUI requiredItemsTextUI;
    [SerializeField] private TextMeshProUGUI stepTextUI;

    [Header("Instruction Steps")]
    [SerializeField] private InstructionStep[] instructionSteps;

    [Header("Animation Controller")]
    [SerializeField] private StepAnimationController animationController, animationControllerAR;

    private int currentStepIndex = 0;

    void Start()
    {
        if (instructionSteps.Length > 0)
        {
            UpdateUI(instructionSteps[currentStepIndex]);
            animationController.ActivateStepObject(currentStepIndex);
            animationControllerAR.ActivateStepObject(currentStepIndex);
        }
    }

    public void NextStep()
    {
        if (currentStepIndex + 1 < instructionSteps.Length)
        {
            currentStepIndex++;
            UpdateUI(instructionSteps[currentStepIndex]);
            animationController.ActivateStepObject(currentStepIndex);
            animationControllerAR.ActivateStepObject(currentStepIndex); 
        }
    }

    public void PreviousStep()
    {
        if (currentStepIndex > 0)
        {
            currentStepIndex--;
            UpdateUI(instructionSteps[currentStepIndex]);
            animationController.ActivateStepObject(currentStepIndex);
            animationControllerAR.ActivateStepObject(currentStepIndex);
        }
    }

    private void UpdateUI(InstructionStep step)
    {
        titleTextUI.text = "PASO " + (currentStepIndex + 1);
        explanationTextUI.text = step.explanationText;
        stepImageUI.sprite = step.stepImage;
        requiredItemsTextUI.text = step.requiredItemsText;

        stepTextUI.text = (currentStepIndex + 1) + " / 7";
    }
}
