using UnityEngine;
using UnityEngine.UI;

public class TabSwitcher : MonoBehaviour
{
    [System.Serializable]
    public class Tab
    {
        public Toggle toggle;         // Toggle �������
        public GameObject content;    // �������, ��������� � ��������
    }

    public Tab[] tabs;

    void Start()
    {
        // ��������� �������
        foreach (var tab in tabs)
        {
            tab.toggle.onValueChanged.AddListener((isOn) => OnTabToggled(tab, isOn));
        }

        // ���������� ��������� ���������
        UpdateTabs();
    }

    void OnTabToggled(Tab toggledTab, bool isOn)
    {
        if (isOn)
            UpdateTabs();
    }

    void UpdateTabs()
    {
        foreach (var tab in tabs)
        {
            tab.content.SetActive(tab.toggle.isOn);
        }
    }
}
