// Pause and play using Speech to Text
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IBM.Watson.SpeechToText.V1;
using IBM.Cloud.SDK;
using IBM.Cloud.SDK.Authentication;
using IBM.Cloud.SDK.Authentication.Iam;
using IBM.Cloud.SDK.Utilities;
using IBM.Cloud.SDK.Datatypes;

public class PlayButton : MonoBehaviour
{
    public GameObject STT;
    private SpeechToTextScript _theSpeechToText;
    private Renderer _renderer;
    private string finalTranscript;
    public int pause;

    public void Start()
    {
        _theSpeechToText = STT.GetComponent<SpeechToTextScript>();
        _renderer = this.GetComponent<Renderer>();
    }

    public string GetFinalTranscript()
    {
        return _finalTranscript;
    }

    public void Play()
    {
        finalTranscript = _theSpeechToText.GetFinalTranscript();

        if (string.Equals(finalTranscript, "Play"))
        {
            pause = 0; 
        }
    }

    void Update()
    {
        Play();
    }
}