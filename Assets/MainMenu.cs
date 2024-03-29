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
    public GameObject hud;

    private VisualElement rootElement;
    private GameObject player;
    private PlayerGlobals playerGlobals;
    private SettingsMenuScript settingsMenuScript;
    
    void Start()
    {
        // Link button clicked events
        rootElement = m_document.rootVisualElement;
        Button tutorialButton = rootElement.Query<Button>("Tutorial");
        tutorialButton.clickable.clicked += TutorialClicked;

        Button battleButton = rootElement.Query<Button>("Battle");
        battleButton.clickable.clicked += BattleClicked;

        Button optionsButton = rootElement.Query<Button>("Options");
        optionsButton.clickable.clicked += OptionsClicked;

        Button quitButton = rootElement.Query<Button>("Quit");
        quitButton.clickable.clicked += QuitClicked;

        hud.GetComponent<UIDocument>().rootVisualElement.visible = false;
        settingsMenuScript = transform.parent.GetComponentInChildren<SettingsMenuScript>();
    }

    void StartGame()
    {
        player = transform.parent.gameObject;
        playerGlobals = player.GetComponent<PlayerGlobals>();

        player.transform.Find("Camera").GetComponent<MouseLook>().Lock();
        playerGlobals.characterEnabled = true;
        hud.GetComponent<UIDocument>().rootVisualElement.visible = true;
    }

    private void TutorialClicked()
    {
        // Begin tutorial
        Debug.Log("Clicked tutorial");
        Show(false);
        StartGame();
    }

    private void OptionsClicked()
    {
        // Show options menu
        Show(false);
        settingsMenuScript.Show(true);
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

    public void Show(bool b)
    {
        rootElement.visible = b;
    }
}
