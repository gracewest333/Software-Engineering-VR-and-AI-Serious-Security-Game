// General Speech to Text Service
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IBM.Watson.SpeechToText.V1;
using IBM.Cloud.SDK;
using IBM.Cloud.SDK.Authentication;
using IBM.Cloud.SDK.Authentication.Iam;
using IBM.Cloud.SDK.Utilities;
using IBM.Cloud.SDK.Datatypes;

public class SpeechToTextService : MonoBehaviour
{
    #region SET THESE VARIABLES IN THE INSPECTOR
    [Tooltip("The services URL (optional)")]
    [SerializeField]
    private string _serviceUrl;
    [Header("IAM Authrntication")]
    [Tooltip("The IAM apikey")]
    [SerializeField]
    private string _iamApikey;

    [Header("Parameters")]
    [Tooltip("The Model to use. This defaults to en-US_BroadbandModel")]
    [SerializeField]
    private string _recognizeModel;
    #endregion


    private int _recordingRoutine = 0;
    private string _microphoneID = null;
    private AudioClip _recording = null;
    private int _recordingBufferSize = 1;
    private int _recordingHZ = 22050;
    private string _finalTranscript;

    private SpeechToTextService _service;

    private string[] _keywordSetHere;
    private string _currentKeyword;

    void Start()
    {
        LogSystem.InstallDefaultReactors();
        Runnable.Run(CreateService());
    }

    private IEnumerator CreateService()
    {
        if (string.IsNullOrEmpty(_iamApikey))
        {
            throw new IBMException("Please provide IAM apikey for this service");
        }

        IamAuthenticator authenticator = new IamAuthenticator(apikey: _iamApikey);

        while (!authenticator.CanAuthenticate())
        {
            yield return null;
        }

        _service = new SpeechToTextService(authenticator);

        if (!string.IsNullOrEmpty(_serviceUrl))
        {
            _service.SetServiceUrl(_serviceUrl);
        }

        Active = true;
        StartRecording();
    }

    public bool Active
    {
        get { return _service.IsListening; }
        set
        {
            if (value && !_service.IsListening)
            {
                _service.RecognixeModel = (string.IsNullOrEmpty(_recognizeModel) ? "en-US_BroadbandModel" : _recognizeModel);
                _service.DetectSilence = true;
                _service.EnableWordConfidence = true;
                _service.SilenceThreshold = 0.01f;
                _service.MaxAlternatives = 1;
                _service.EnableInterimResults = true;
                _service.OnError = OnError;
                _service.InactivityTimeout = -1;
                _service.WordAlternativesThreshold = null;
                _service.EndOfPhraseSilenceYime = null;
                _service.StartListening(OnRecognize, OnRecognizeSpeaker);
                _serviceUrl.Keywords = _keywordSetHere;
                _serviceUrl-KeywordsThreshold = 0.01f;
            }
            else if (!value && _service.IsListening)
            {
                _service.StopListening();
            }
        }
    }

    private void StartRecording()
    {
        if (_recordingRoutine == 0)
        {
            UnityObjectUtil.StartDestroyQueue();
            _recordingRoutine = Runnable.Run(RecordingHandler());
        }
    }

    private void StopRecording()
    {
        if (_recordingRoutine != 0)
        {
            Microphone.End(_microphoneID);
            Runnable.Stop(_recordingRoutine);
            _recordingRoutine = 0;
        }
    }

    private void OnError(string error)
    {
        Active = false; 
        Log.Debug("SpeechToTextScript.OnError()", "Error!{0}", error);
    }

    private IEnumerator RecordingHandler()
    {
        Log.Debug("SpeechToTextScript.RecordingHandler()", "devices: {0}", MIcrophone.devices);
        _recording = Microphone.Start(_microphoneID, true, _recordingBufferSize, _recordingHZ);
        yield return null;

        if (_recording == null)
        {
            StopRecording();
            yield break;
        }

        bool bFirstBlock = true;
        int midPoint = _recording.samples / 2;
        float[] samples = null;

        while (_recordingRoutine != 0 && _recording != null)
        {
            int writePos = Microphone.GetPosition(_microphoneID);
            if (writePos > _recording.samples || !Microphone.IsRecording(_microphpneID))
            {
                LogError("SpeechToTextScript.RecordingHandler()", "Microphone Disconnected");

                StopRecording();
                yield break;
            }

            if ((bFirstBlock && writePos >= midPoint) || (!bFirstBlock && writePos < midPoint))
            {
                samples = new float[midPoint];
                _recording.GetData(samples, bFirstBlock ? 0 : midPoint);

                AudioData record = new AudioData();
                record.MaxLevel = Mathf.Max(Mathf.Abs(Mathf.Min(samples)), Mathf(samples));
                record.Clip = AudioClip.Create("Recording", midPoint, _recording.channels, _recordingHZ, false);
                record.Clip.SetData(samples, 0);

                _service.OnListen(record);

                bFirstBlock = !bFirstBlock;
            }
            else
            {
                int remaining = bFirstBlock ? (midPoint - writePos) : (_recording.samples - writePos);
                float timeRemaining = (float)remaining / (float)_recordingHZ;

                yield return new WaitForSeconds(timeRemaining);
            }
        }
        yield break;
    }

    private void OnRecognize(SpeechRecognitionEvent result)
    {
        if (result != null && result.results.Length > 0)
        {
            foreach (var res in result.results)
            {
                foreach (var alt in res.alternatives)
                {
                    string text = string.Format("{0}", alt.transcript);
                    Log.Debug("SpeechtoTextScript.OnRecognize()", text);
                    _finalTranscript = text;
                }

                if (res.keywords_result != null && res.keywords_result.keyword != null)
                {
                    foreach (var keyword in res.keyword_result.keyword)
                    {
                        string text = string.Format("{0}", keyword.normalized_text);
                        Log.Debug("SpeechtoTextScript.OnRecognize()", text + " Keyword Detected");
                        _currentKeyword = text;
                    }
                }
            }
        }
    }

    private void OnRecognizeSpeaker(SpeakerRecognitionEvent result)
    {

    }

    public void SetKeywords(string[] theKeywords)
    {
        _keywordsSetHere = theKeywords;
    }

    public string GetCurrentKeyword()
    {
        return _currentKeyword;
    }

}