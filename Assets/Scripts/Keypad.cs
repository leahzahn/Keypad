using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public KeypadBackground Background;

    private List<int> buttonsEntered;
    private Combination combination;

    // Start is called before the first frame update
    void Start()
    {
        ResetButtonEntries();
        combination = new Combination();
    }

    public void RegisterButtonClick(int buttonValue)
    {
        buttonsEntered.Add(buttonValue);
        print(String.Join(", ", buttonsEntered));
    }

    public void TryToUnlock()
    {
        if (IsCorrectCombination())
        {
            Unlock();
        }
        else
        {
            FailToUnlock();
        }

        ResetButtonEntries();
    }

    private bool IsCorrectCombination()
    {
        if (HaveNoButtonsBeenClicked())
        {
            return false;
        }
        if (HaveWrongNumberOfButtonsBeenClicked())
        {
            return false;
        }
        return CheckCombination();
    }

    private bool HaveNoButtonsBeenClicked()
    {
        if (buttonsEntered.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool HaveWrongNumberOfButtonsBeenClicked()
    {
        if (buttonsEntered.Count == combination.GetCombinationLength())
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool CheckCombination()
    {
        for (int buttonIndex = 0; buttonIndex < buttonsEntered.Count; ++buttonIndex)
        {
            if (IsCorrectButton(buttonIndex) == false)
            {
                return false;
            }
        }
        return true;
    }

    private bool IsCorrectButton(int buttonIndex)
    {
        if (IsWrongEntry(buttonIndex))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool IsWrongEntry(int buttonIndex)
    {
        if (buttonsEntered[buttonIndex] == combination.GetCombinationDigit(buttonIndex))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void Unlock()
    {
        Background.HideUnlockButton();
        Background.ChangeToSuccessColor();

    }

    private void FailToUnlock()
    {
        Background.ChangeToFailedColor();
        StartCoroutine(ResetBackgroundColor());
    }

    private void ResetButtonEntries()
    {
        buttonsEntered = new List<int>();
    }

    private IEnumerator ResetBackgroundColor()
    {
        yield return new WaitForSeconds(0.25f);
        Background.ChangeToDefaultColor();
    }
}
