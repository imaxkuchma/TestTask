using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StepperView : MonoBehaviour
{
    [SerializeField] private Button m_DecButtton;
    [SerializeField] private TMP_InputField m_InputField;
    [SerializeField] private Button m_IncButtton;

    [SerializeField] private int m_MinValue;
    [SerializeField] private int m_MaxValue;
    [SerializeField] private int m_Step;

    private int m_Value;

    public int Value => m_Value;

    public event Action OnValueChange;

    private void Awake()
    {
        m_DecButtton.onClick.AddListener(DecButttonClick);
        m_IncButtton.onClick.AddListener(IncButttonClick);

        m_InputField.text = $"{m_Value}/{m_MaxValue}";
    }

    private void DecButttonClick()
    {
        if (m_Value > m_MinValue)
        {
            m_Value -= m_Step;

            ValueChange();
        }
    }

    private void IncButttonClick()
    {
        if (m_Value < m_MaxValue)
        {
            m_Value += m_Step;

            ValueChange();
        }
    }

    private void ValueChange()
    {
        m_Value = Mathf.Clamp(m_Value, m_MinValue, m_MaxValue);

        m_InputField.text = $"{m_Value}/{m_MaxValue}";

        OnValueChange?.Invoke();
    }
}
