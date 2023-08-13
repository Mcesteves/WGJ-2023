using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    private bool wasClicked = false;

    public void OnPauseButtonHit ()
    {
        if (wasClicked == false)
        {
            pausePanel.SetActive(true);
            wasClicked = true;    
        }
        else if (wasClicked == true)
        {
            pausePanel.SetActive(false);
            wasClicked = false;
        }
    }

}
