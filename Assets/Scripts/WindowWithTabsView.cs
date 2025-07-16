using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WindowWithTabsView : MonoBehaviour
{

    public TMP_InputField m_NameInput;
    public StepperView m_Stepper;
    public Toggle m_CheckBox;
    public TMP_Dropdown m_Dropdown;
    public Slider m_Slider1;
    public Slider m_Slider2;
    public Button m_CancelButton;
    public Button m_AcceptButton;
    public Button m_CloseButton;

    private SettingsData m_currentSettingData = new SettingsData();

    private void Awake()
    {
        m_NameInput.onValueChanged.AddListener(NameOnValueChanged);
        m_Stepper.OnValueChange += StepperOnValueChange;
        m_CheckBox.onValueChanged.AddListener(CheckBoxOnValueChanged);
        m_Dropdown.onValueChanged.AddListener(DropdownOnValueChanged);
        m_Slider1.onValueChanged.AddListener(Slider1OnValueChanged);
        m_Slider2.onValueChanged.AddListener(Slider2OnValueChanged);

        m_CancelButton.onClick.AddListener(CancelButtonClick);
        m_AcceptButton.onClick.AddListener(AcceptButtonClick);

        m_CloseButton.onClick.AddListener(() => { Debug.Log("Кнопка зарытия нажата"); });

        FillDropdown();
    }

    private void FillDropdown()
    {
        m_Dropdown.ClearOptions();

        var options = new System.Collections.Generic.List<string>();
        for (int i = 1; i <= 30; i++)
        {
            options.Add($"Option {i}");
        }

        m_Dropdown.AddOptions(options);
    }

    private void NameOnValueChanged(string arg0)
    {
        UpdateAcceptButtonState();
    }

    private void StepperOnValueChange()
    {
        UpdateAcceptButtonState();
    }

    private void CheckBoxOnValueChanged(bool arg0)
    {
        UpdateAcceptButtonState();
    }

    private void DropdownOnValueChanged(int arg0)
    {
        UpdateAcceptButtonState();
    }

    private void Slider1OnValueChanged(float arg0)
    {
        UpdateAcceptButtonState();
    }

    private void Slider2OnValueChanged(float arg0)
    {
        UpdateAcceptButtonState();
    }

    private void CancelButtonClick()
    {
        Debug.Log("Кнопка отмены нажата");
    }

    private void AcceptButtonClick()
    {
        m_currentSettingData = GetCurrentUIData();
        UpdateAcceptButtonState();
        Debug.Log("Новые настройки применены");
    }

    private void UpdateAcceptButtonState()
    {
        var newData = GetCurrentUIData();
        m_AcceptButton.interactable = newData != m_currentSettingData;
    }

    private SettingsData GetCurrentUIData()
    {
        var currentData = new SettingsData()
        {
            playerName = m_NameInput.text,
            stepperValue = m_Stepper.Value,
            isCheckboxChecked = m_CheckBox.isOn,
            selectedOption = m_Dropdown.value,
            slider1Value = m_Slider1.value,
            slider2Value = m_Slider2.value
        };

        return currentData;
    }
}
