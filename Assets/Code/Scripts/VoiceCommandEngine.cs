using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceCommandEngine : MonoBehaviour
{
    public string[] phrases;
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    protected string word = "right";
    private KeywordRecognizer recognizer;

    private void Start()
    {
        recognizer = new KeywordRecognizer(phrases, confidence);
        recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
        recognizer.Start();
    }
    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args.text);
    }
    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
}
