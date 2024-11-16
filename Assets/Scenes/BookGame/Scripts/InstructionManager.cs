using UnityEngine;
using UnityEngine.UI;

public class InstructionManager : MonoBehaviour
{
    public GameObject instructionPanel; // Reference to the Panel containing instructions

    void Start()
    {
        // Ensure the instruction panel is active at the start
        instructionPanel.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    public void OnOkayButtonClicked()
    {
        // Hide the instruction panel and resume the game
        instructionPanel.SetActive(false);
        Time.timeScale = 1; // Resume the game
    }
}
