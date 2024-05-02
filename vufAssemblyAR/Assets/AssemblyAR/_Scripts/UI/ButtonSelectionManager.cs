using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonSelectionManager : MonoBehaviour
{
    [System.Serializable]
    public class ButtonEntry
    {
        public Button button;
        public Image selectionIndicator;
    }

    [SerializeField]
    private List<ButtonEntry> buttonEntries;

    private ButtonEntry currentSelected;

    void Awake()
    {
        foreach (var entry in buttonEntries)
        {
            if (entry.selectionIndicator != null)
                entry.selectionIndicator.enabled = false;

            if (entry.button != null)
                entry.button.onClick.AddListener(() => ButtonClicked(entry));
        }
    }

    private void ButtonClicked(ButtonEntry entryClicked)
    {
        if (currentSelected != null)
        {
            currentSelected.selectionIndicator.enabled = false;
        }

        entryClicked.selectionIndicator.enabled = true;
        currentSelected = entryClicked;
    }
}
