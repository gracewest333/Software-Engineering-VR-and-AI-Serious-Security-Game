using System;
using IBM.Cloud.SDK;
using IBM.Cloud.SDK.Authentication;
using IBM.Cloud.SDK.Connection;
using IBM.Cloud.SDK.Utilities;
using IBM.Watson.SpeechToText.V1.Model;

// string apikey =  '3laWrSNmrlUX1Mni6NeELadSJ3ylTbUrcwoRX6S0vyrm';
// string url =  'https://api.eu-gb.speech-to-text.watson.cloud.ibm.com/instances/d2689ab0-e078-41ac-8ad2-4897036fd93d';
// var authenticator = IAMAuthenticator(apikey);
// var stt = SpeechToTextV1(authenticator = authenticator);

// namespace SpeechToText
// {
//     public class Program
//     {
//         public static void Main(string[] args)
//         {
//             var speech = SpeechClient.Create();
//             var config = new RecognitionConfig
//             {
//                 Encoding = RecognitionConfig.Types.AudioEncoding.Flac,
//                 SampleRateHertz = 16000,
//                 LanguageCode = LanguageCodes.English.UnitedStates
//             };
//             // needs to be connected to the Oculus headset
//             var audio = RecognitionAudio.FromStorageUri("gs://cloud-samples-tests/speech/brooklyn.flac");         
            
//             var response = speech.Recognize(config, audio);

//             foreach (var result in response.Results)
//             {
//                 foreach (var alternative in result.Alternatives)
//                 {
//                     Console.WriteLine(alternative.Transcript);
//                 }
//             }
//         }
//     }
// }

var authenticator = new IamAuthenticator(
    apikey: "3laWrSNmrlUX1Mni6NeELadSJ3ylTbUrcwoRX6S0vyrm"
);

while (!authenticator.CanAuthenticate())
    yield return null;

var speechToText = new SpeechToTextService(authenticator);
speechToText.SetServiceUrl("https://api.eu-gb.speech-to-text.watson.cloud.ibm.com/instances/d2689ab0-e078-41ac-8ad2-4897036fd93d");

SpeechRecognitionResults recognizeResponse = null;
speechToText.Recognize(
    callback: (DetailedResponse<SpeechRecognitionResults> response, IBMError error) =>
    {
        Log.Debug("SpeechToTextServiceV1", "Recognize result: {0}", response.Response);
        recognizeResponse = response.Result;
    },
    audio: new MemoryStream(File.ReadAllBytes("audio-file2.flac")),
    contentType: "audio/flac",
    wordAlternativesThreshold: 0.9f,
    keywords: new List<string>()
    {
        "colorado",
        "tornado",
        "tornadoes"
    },
    keywordsThreshold: 0.5f
);

while (recognizeResponse == null)
{
    yield return null;
}    