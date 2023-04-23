using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsMenuScript : MonoBehaviour
{
    UIDocument ui;
    VisualElement main;
    SliderInt sens;
    SliderInt fov;
    bool settingsEnabled = false;
    void Start()
    {
        ui = GetComponent<UIDocument>();
        ui.rootVisualElement.RegisterCallback<GeometryChangedEvent>(UiReady);
    }

    private void UiReady(GeometryChangedEvent evt)
    {
        var root = ui.rootVisualElement;
        main = root.Q("Main");
        sens = root.Q<SliderInt>("SensitivitySlider");
        fov = root.Q<SliderInt>("FovSlider");
        fov.RegisterValueChangedCallback(FovChanged);
        sens.RegisterValueChangedCallback(SensChanged);
        root.Q<Button>("BackButton").clickable.clicked += Back;
        Show(false);
    }

    private void FovChanged(ChangeEvent<int> evt)
    {
        transform.parent.GetComponentInChildren<Camera>().fieldOfView = evt.newValue;
    }

    private void SensChanged(ChangeEvent<int> evt)
    {
        transform.parent.GetComponentInChildren<MouseLook>().mouseSensitivity = evt.newValue;
    }

    public void Show(bool b)
    {
        main.visible = b;
        sens.visible = b;
        fov.visible = b;
        settingsEnabled = b;
    }

    void Back()
    {
        Show(false);
        transform.parent.GetComponentInChildren<MainMenu>().Show(true);
    }
}
