
using UnityEngine;
using TMPro;

public class Settings : MonoBehaviour
{
    [SerializeField] private TMP_Text volumeText;
    
    public bool isOn;
    void Start()
    {
        if (AudioListener.volume == 1f) 
        {
            isOn = true;
            if (volumeText) volumeText.text = "Музыка: вкл";
        }
        if (AudioListener.volume == 0f) 
        {
            isOn = false;
            if (volumeText) volumeText.text = "Музыка: выкл";
        }
    }

    public void MusicOnOff()
    {
        if(!isOn)
        {
            AudioListener.volume = 1f;
            isOn = true;
            volumeText.text = "Музыка: вкл";
        }
        else if(isOn)
        {
            AudioListener.volume = 0f;
            isOn = false;
            volumeText.text = "Музыка: выкл";
        }
    }


}
