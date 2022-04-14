using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// VILDE TO CHNAGE THIS, ONCE WORKING PLS CAN YOU COMMENT THE CODE!! :)


public class Change_gun : MonoBehaviour
{
    public string selected_gun= "AccessManagement";
    public GameObject STT;
    private SpeechToTextScript _theSpeechToText;
    private Renderer _renderer;
    private string finalTranscript;

    private string[] keywordStrings;
    private string theActiveKeyword;

    public string GetFinalTranscript()
    {
        return _finaltranscript;
    }

    public LineRenderer Object;

    public Material pink;
    public Material green;
    public Material blue;
    public Material orange;
    public Material purple;
    
    void Update(){

        _theSpeechToText = STT.GetComponent<SpeechToTextScript>();
        _renderer = this.GetComponent<Renderer>();

        finalTranscript = _theSpeechToText.GetFinalTranscript();
        keywordStrings = new string[6] {"Access Management", "AntiMalware", "Encrypter", "Firewall", "Webfiltering", "Pointer"};

        _theSpeechToText.SetKeywords(keywordStrings);

        theActiveKeyword = _theSpeechToText.GetCurrentKeyword();

        if (string.Equals(theActiveKeyword, keywordStrings[0])){
            Object.GetComponent<LineRenderer> ().material = pink;
            selected_gun= "AccessManagement";
            }

        if (string.Equals(theActiveKeyword, keywordStrings[1])){
            Object.GetComponent<LineRenderer> ().material = green;
            selected_gun= "AntiMalware";            
            }

        if (string.Equals(theActiveKeyword, keywordStrings[2])){
            Object.GetComponent<LineRenderer> ().material = blue;
            selected_gun= "encrypter";            
            }

        if (string.Equals(theActiveKeyword, keywordStrings[3])){
            Object.GetComponent<LineRenderer> ().material = orange;
            selected_gun= "firewall";            
            }

        if (string.Equals(theActiveKeyword, keywordStrings[4])){
            Object.GetComponent<LineRenderer> ().material = purple;
            selected_gun= "WebFiltering";            
            }
        if (string.Equals(theActiveKeyword, keywordStrings[5])){
            selected_gun= "pointer";            
            }
 
    }


}
