using UnityEngine;

[CreateAssetMenu(fileName = "NewInstructionStep", menuName = "Instruction Step", order = 1)]
public class InstructionStep : ScriptableObject
{
    [TextArea]
    public string explanationText; // Texto explicativo del paso

    public Sprite stepImage; // Imagen del paso

    [TextArea]
    public string requiredItemsText; // Texto de los elementos necesarios para el paso
}
