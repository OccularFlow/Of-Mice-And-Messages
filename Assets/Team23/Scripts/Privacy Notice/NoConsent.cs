using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NoConsent : MonoBehaviour
{
    public void OnMouseDown()
    {
        Application.Quit();
    }

}
