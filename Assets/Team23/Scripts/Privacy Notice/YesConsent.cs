using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesConsent : MonoBehaviour
{
    public PrivacyNotifcation privacy;
    
    void Awake() {
        privacy = GetComponentInParent<PrivacyNotifcation>();
    }
    void OnMouseDown() {
        PlayerPrefs.SetInt("consent",1);
        privacy.consented();
    }

}
