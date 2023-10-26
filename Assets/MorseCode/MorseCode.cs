using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
 
public class MorseCode : MonoBehaviour {
    [SerializeField] private string morseMessage;
    private AudioSource _audioSource;
    private AudioClip _dotSound;
    private AudioClip _dashSound;
    private const float SpaceDelay = 0.05f;
    private const float LetterDelay = 0.008f;

    // International Morse Code Alphabet
    private readonly string[] _alphabet =
    //A     B       C       D      E    F       G
    {".-", "-...", "-.-.", "-..", ".", "..-.", "--.",
    //H       I     J       K      L       M     N
     "....", "..", ".---", "-.-", ".-..", "--", "-.",
    //O      P       Q       R      S      T    U
     "---", ".--.", "--.-", ".-.", "...", "-", "..-",
    //V       W      X       Y       Z
     "...-", ".--", "-..-", "-.--", "--..",
    //0        1        2        3        4        
     "-----", ".----", "..---", "...--", "....-",
    //5        6        7        8        9    
     ".....", "-....", "--...", "---..", "----."};
 
    // Use this for initialization
    private void Start () {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _dotSound = Resources.Load<AudioClip>("Sounds/dot");
        _dashSound = Resources.Load<AudioClip>("Sounds/dash");
        PlayMorseCodeMessage(morseMessage);
    }
    
    public void PlayMorseCodeMessage(string message)
    {
        StartCoroutine(nameof(_PlayMorseCodeMessage), message);
    }

    public void StopMorseCode() {
        StopCoroutine(nameof(_PlayMorseCodeMessage));
        // _audioSource.Stop();
    }
   
    private IEnumerator _PlayMorseCodeMessage(string message)
    {
        // Remove all characters that are not supported by Morse code...
        var regex = new Regex("[^A-z0-9 ]");
        message = regex.Replace(message.ToUpper(), "");
       
        // Convert the message into Morse code audio...
        yield return new WaitForSeconds(0.5f);
        foreach(var letter in message)
        {
            if (letter == ' ')
                yield return new WaitForSeconds(SpaceDelay);
            else
            {
                var index = letter - 'A';
                if (index < 0)
                    index = letter - '0' + 26;
                var letterCode = _alphabet[index];
                foreach(var bit in letterCode)
                {
                    // Dot or Dash?
                    var       sound = _dotSound;
                    if (bit == '-') sound = _dashSound;
                   
                    // Play the audio clip and wait for it to end before playing the next one.
                    _audioSource.PlayOneShot(sound);
                    yield return new WaitForSeconds(sound.length + LetterDelay);
                }
            }
        }
    }
}