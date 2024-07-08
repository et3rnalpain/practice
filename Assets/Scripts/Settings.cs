
using UnityEngine;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] private TMP_Text volumeText;
    [SerializeField] private GameObject[] skins;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject tg;
    [SerializeField] private GameObject CoinAndText1;
    [SerializeField] private GameObject CoinAndText2;
    [SerializeField] private GameObject score_text;
    [SerializeField] private TMP_Text points_text;
    public int current_skin_id = 0;
    public bool isOn;
    private int coins;
    private bool Esli1skinKyplen = false;
    private bool Esli2skinKyplen = false;
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
        if (Input.GetKeyDown(KeyCode.L))
        {
            coins = PlayerPrefs.GetInt("coins");
            coins += 25;
            PlayerPrefs.SetInt("coins", coins);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            coins = PlayerPrefs.GetInt("coins");
            coins = 0;
            PlayerPrefs.SetInt("coins", coins);
        }
    }

    public void CheckSwapSkin(int index)
    {
        if (index == 1 && Esli1skinKyplen == false)
        {
            Esli1skinKyplen = true;
            coins = PlayerPrefs.GetInt("coins");
            if(coins >= 100)
            {
                coins -= 100;
                PlayerPrefs.SetInt("coins", coins);     
                //CoinAndText1.SetActive(false); 
                swapSkin(index);
            }
        }
        if(index == 2 && Esli2skinKyplen == false)
        {
            Esli2skinKyplen = true;
            coins = PlayerPrefs.GetInt("coins");
            if(coins >= 250)
            {
                coins -= 250;
                PlayerPrefs.SetInt("coins", coins);
                //CoinAndText2.SetActive(false); 
                swapSkin(index);
            }
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
