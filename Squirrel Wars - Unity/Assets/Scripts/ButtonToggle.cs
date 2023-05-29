using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToggle : MonoBehaviour
{
    //SerializeField makes it editable from the inspector but not from other scripts
    public Sprite[] buttonSprites;
    public Image targetButton;

    public void ToggleImage()
    {
        //Checking if current sprite matches Initial sprite
        if (targetButton.sprite == buttonSprites[0])
        {
            //If it matches, change to next sprite
            targetButton.sprite = buttonSprites[1];
            return; //Exit
        }

        //If sprite does not match, change it to initial sprite
        targetButton.sprite = buttonSprites[0];
    }
}
