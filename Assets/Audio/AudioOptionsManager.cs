using UnityEngine;
using TMPro;

public class AudioOptionsManager : MonoBehaviour
{
    public static float musicVolume { get; private set; }
    public static float soundEffectsVolume { get; private set; }

    [SerializeField] private TextMeshProUGUI musicSliderText;
    [SerializeField] private TextMeshProUGUI soundEffectsSliderText;

    public void OnMusicSliderValueChange(float value)
    {
        musicVolume = value == 0 ? 0.0001f : value / 100;
        
        musicSliderText.text = ((int)(value)).ToString();
        AudioManager.Instance.UpdateMixerVolume();
    }

    public void OnSoundEffectsSliderValueChange(float value)
    {
        soundEffectsVolume = value == 0 ? 0.0001f : value / 100;
        
        soundEffectsSliderText.text = ((int)(value)).ToString();
        AudioManager.Instance.UpdateMixerVolume();
    }
}