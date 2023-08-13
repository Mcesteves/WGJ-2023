using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaderninhoManager : MonoBehaviour
{
    public GameObject caderninho;
    private bool wasCaderninhoHit = false;

    public void OnCaderninhoHit ()
    {
        if (wasCaderninhoHit == false)
        {
            caderninho.SetActive(true);
            wasCaderninhoHit = true;
        }
        else if (wasCaderninhoHit == true)
        {
            caderninho.SetActive(false);
            wasCaderninhoHit = false;
        }
    }
}
