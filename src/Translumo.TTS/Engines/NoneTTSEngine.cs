namespace Translumo.TTS.Engines;

public class NoneTTSEngine : ITTSEngine
{
    public NoneTTSEngine()
    {
    }

    public void Dispose()
    {
    }

    public string[] GetVoices() => new[] { "None" };

    public void SetVoice(string voice)
    {
    }

    public void SetRate(int rate)
    {
    }

    public void SpeechText(string text)
    {
    }
}