using UnityEngine;

public class SettingsData
{
    public string playerName;
    public int stepperValue;
    public bool isCheckboxChecked;
    public int selectedOption;
    public float slider1Value;
    public float slider2Value;

    public override bool Equals(object obj)
    {
        if (obj is not SettingsData other) return false;

        return playerName == other.playerName &&
               stepperValue == other.stepperValue &&
               isCheckboxChecked == other.isCheckboxChecked &&
               selectedOption == other.selectedOption &&
               Mathf.Approximately(slider1Value, other.slider1Value) &&
               Mathf.Approximately(slider2Value, other.slider2Value);
    }

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + (playerName?.GetHashCode() ?? 0);
        hash = hash * 23 + stepperValue.GetHashCode();
        hash = hash * 23 + isCheckboxChecked.GetHashCode();
        hash = hash * 23 + selectedOption.GetHashCode();
        hash = hash * 23 + slider1Value.GetHashCode();
        hash = hash * 23 + slider2Value.GetHashCode();
        return hash;
    }

    public bool EqualsTo(SettingsData other)
    {
        if (other == null) return false;

        return playerName == other.playerName &&
               stepperValue == other.stepperValue &&
               isCheckboxChecked == other.isCheckboxChecked &&
               selectedOption == other.selectedOption &&
               Mathf.Approximately(slider1Value, other.slider1Value) &&
               Mathf.Approximately(slider2Value, other.slider2Value);
    }

    public static bool operator ==(SettingsData a, SettingsData b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.EqualsTo(b);
    }

    public static bool operator !=(SettingsData a, SettingsData b)
    {
        return !(a == b);
    }
}