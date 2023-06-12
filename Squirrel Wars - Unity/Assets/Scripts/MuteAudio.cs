using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAudio : MonoBehaviour
{
    public void MuteToggle(bool muted)
    {
        //Checks if the bgm should be muted
        if (muted)
        {
            AudioListener.volume = 0; //Mutes audio
        }
        else
        {
            AudioListener.volume = 1; //Unmutes audio
        }
    }
        
    
}
