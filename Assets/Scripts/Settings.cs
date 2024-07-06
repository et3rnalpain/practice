
using UnityEngine;
using TMPro;

public class Settings : MonoBehaviour
{
    [SerializeField] private TMP_Text volumeText;
    [SerializeField] private GameObject[] skins;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject tg;

    [SerializeField] private GameObject score_text;
    [SerializeField] private TMP_Text points_text;
    public int current_skin_id = 0;
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                swapSkin(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                swapSkin(1);
            }
    }

    public void swapSkin(int index)
    {
        current_skin_id = index;
        CameraController c = cam.GetComponent<CameraController>();
        TileGenerator t = tg.GetComponent<TileGenerator>();

        Destroy(player.transform.GetChild(0).gameObject);

        GameObject obj = Instantiate(skins[index]);
        obj.SetActive(false);
        obj.transform.SetParent(player.transform);

        c.player = obj.transform;
        t.player = obj.gameObject;

        obj.GetComponent<PlayerController>().scoreText = score_text;
        obj.GetComponent<PlayerController>().coinsText = points_text;
        
        
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
