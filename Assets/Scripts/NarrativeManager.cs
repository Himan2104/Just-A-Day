using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

[System.Serializable] public struct OptionData
{
    public string OptionAText;
    public UnityEngine.Events.UnityAction OptionAAction;

    public string OptionBText;
    public UnityEngine.Events.UnityAction OptionBAction;
}

public class NarrativeManager : MonoBehaviour
{
    [Header("Text Area")]
    [SerializeField] GameObject TextAreaObject;
    [SerializeField] TMP_Text TextArea;

    [Header("Option A")]
    [SerializeField] GameObject OptionAObject;
    [SerializeField] Button OptionAButton;
    [SerializeField] TMP_Text OptionA;

    [Header("Option B")]
    [SerializeField] GameObject OptionBObject;
    [SerializeField] Button OptionBButton;
    [SerializeField] TMP_Text OptionB;

    [Header("Misc")]
    [SerializeField] Animator TextAreaAnimator;
    [SerializeField] Animator OptionsAnimator;
    
    public void SetText(string Text)
    {
        TextArea.text = Text;
    }  
    
    public void SetOptions(OptionData optionData)
    {
        OptionAButton.onClick.RemoveAllListeners();
        OptionBButton.onClick.RemoveAllListeners();
        
        OptionA.text = optionData.OptionAText;
        OptionB.text = optionData.OptionBText;

        OptionAButton.onClick.AddListener(optionData.OptionAAction);
        OptionBButton.onClick.AddListener(optionData.OptionBAction);
    }
    
    public void HideFullInterface()
    {
        HideTextInterface();
        HideOptionsInterface();
    }

    public void HideTextInterface()
    {
        TextAreaAnimator.SetTrigger("Hide");
    }
    
    public void HideOptionsInterface()
    {
        OptionsAnimator.SetTrigger("Hide");
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void ShowTextInterface()
    {
        TextAreaAnimator.SetTrigger("Show");
    }
    
    public void ShowOptionsInterface()
    {
        OptionsAnimator.SetTrigger("Show");
    }

    public void SetButtonState(bool value)
    {
        OptionAButton.interactable = value;
        OptionBButton.interactable = value;
    }
}
