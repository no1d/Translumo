using SpeechLib;

namespace Translumo.TTS.Engines;

public sealed class SAPI5TTSEngine : ITTSEngine
{
    private readonly SpeechVoiceSpeakFlags _spFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;
    private SpVoice _voice;


    public SAPI5TTSEngine(int rate)
    {
        _voice = new() { Rate = rate };
    }


    public void SpeechText(string text)
    {
        _voice.Skip("SENTENCE", 1);
        _voice.Speak(text, _spFlags);
    }

    public string[] GetVoices()
        => _voice.GetVoices().OfType<ISpeechObjectToken>().Select(v => v.GetDescription()).ToArray();

    public void SetVoice(string voice)
    {
        var voices = _voice.GetVoices();
        int index = 0;
        int count = 0;
        foreach (var v in voices.OfType<ISpeechObjectToken>())
        {
            if (v.GetDescription() == voice)
            {
                index = count;
                break;
            }
            count++;
        }
        _voice.Voice = voices.Item(index);
    }

    public void SetRate(int rate) => _voice.Rate = rate;


    public void Dispose()
    {
        _voice = null;
    }
}