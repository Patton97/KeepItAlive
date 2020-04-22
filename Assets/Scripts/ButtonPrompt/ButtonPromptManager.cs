using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPromptManager : MonoBehaviour
{
    public enum ButtonPrompt : short
    {
        KBM_F,
        PS_Triangle,
        PS_Square,
        PS_Circle,
        PS_Cross
    }

    [Header("Keyboard & Mouse")]
    [SerializeField] GameObject KBM_F;

    [Header("PlayStation")]
    [SerializeField] GameObject PS_Triangle;
    [SerializeField] GameObject PS_Square;
    [SerializeField] GameObject PS_Circle;
    [SerializeField] GameObject PS_Cross;

    public static Dictionary<ButtonPrompt, GameObject> Keyboard { get; private set; }
    public static Dictionary<ButtonPrompt, GameObject> Playstation { get; private set; }

    void Awake()
    {
        InitialisePrompts();
    }

    void InitialisePrompts()
    {
        InitialiseKeyboardPrompts();
        InitialisePlaystationPrompts();        
    }

    void InitialiseKeyboardPrompts()
    {
        Keyboard = new Dictionary<ButtonPrompt, GameObject>
        {
            { ButtonPrompt.KBM_F, KBM_F }
        };

        ValidatePrompts(Keyboard);
    }

    void InitialisePlaystationPrompts()
    {
        Playstation = new Dictionary<ButtonPrompt, GameObject>
        {
            { ButtonPrompt.PS_Triangle, PS_Triangle },
            { ButtonPrompt.PS_Square, PS_Square },
            { ButtonPrompt.PS_Circle, PS_Circle },
            { ButtonPrompt.PS_Cross, PS_Cross }
        };

        ValidatePrompts(Playstation);
    }

    void ValidatePrompts(Dictionary<ButtonPrompt, GameObject> prompts)
    {
        foreach (var prompt in prompts)
        {
            if (prompt.Value == null) { Debug.LogWarning("Missing " + prompt.Key + " prompt"); }
        }
    }
}
