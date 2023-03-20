using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    // Public members can be linked to certain objects from within the unity editor
    // This links to the canvas object
    public UIDocument m_document;
    
    void Start()
    {
        // Link button clicked events
        var rootElement = m_document.rootVisualElement;
        Button tutorialButton = rootElement.Query<Button>("Tutorial");
        tutorialButton.clickable.clicked += TutorialClicked;

        Button battleButton = rootElement.Query<Button>("Battle");
        battleButton.clickable.clicked += BattleClicked;

        Button optionsButton = rootElement.Query<Button>("Options");
        optionsButton.clickable.clicked += OptionsClicked;

        Button quitButton = rootElement.Query<Button>("Quit");
        quitButton.clickable.clicked += QuitClicked;
    }

    private void TutorialClicked()
    {
        // Begin tutorial
        Debug.Log("Clicked tutorial");
    }

    private void OptionsClicked()
    {
        // Show options menu
        Debug.Log("Clicked options");
    }

    private void BattleClicked()
    {
        // Show battle setup menu
        Debug.Log("Clicked battle");
    }

    private void QuitClicked()
    {
        // Exit game
        Debug.Log("Clicked quit");
        Application.Quit(1);
    }
}
