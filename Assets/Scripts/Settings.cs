
using UnityEngine;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using System.Timers;

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
    [SerializeField] private TMP_Text points_text2;
    [SerializeField] private GameObject [] mo;

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
        if(PlayerPrefs.GetInt("buying")==1)
         {
            Esli1skinKyplen = true;
            if(CoinAndText1)
               CoinAndText1.SetActive(false); 
         }
        if(PlayerPrefs.GetInt("buying2")==1)
        {
            Esli2skinKyplen = true;
             if(CoinAndText1)
                 CoinAndText2.SetActive(false); 
        }
        int ye = PlayerPrefs.GetInt("curent skin");
        //swapSkin(ye);
        for(int i=0; i<3; i++)
        {
            mo[i].SetActive(false);
            if(i==PlayerPrefs.GetInt("curent skin"))
                mo[i].SetActive(true);
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
        if (Input.GetKeyDown(KeyCode.P))
        {
            Esli1skinKyplen=false;
            Esli2skinKyplen=false;
            CoinAndText1.SetActive(true); 
            CoinAndText2.SetActive(true); 
            PlayerPrefs.SetInt("buying",0);
            PlayerPrefs.SetInt("buying2",0);
            PlayerPrefs.SetInt("score",0);
            PlayerPrefs.SetInt("curent skin",0);

        }
    }



    public void CheckSwapSkin(int index)
    {
        if (index == 1)
        {
            if (Esli1skinKyplen == false)
            { 
                coins = PlayerPrefs.GetInt("coins");
                if(coins >= 100)
                {
                    coins -= 100;
                    PlayerPrefs.SetInt("coins", coins);     
                    CoinAndText1.SetActive(false); 
                    swapSkin(index);
                    PlayerPrefs.SetInt("buying",1);
                    PlayerPrefs.SetInt("curent skin",1);
                    Esli1skinKyplen = true;
                }
            }
            else
            {
                swapSkin(index);
            }
        }
        if(index == 2)
        {
            if (Esli2skinKyplen == false)
            {
                
                coins = PlayerPrefs.GetInt("coins");
                if(coins >= 250)
                {
                    coins -= 250;
                    PlayerPrefs.SetInt("coins", coins);
                    CoinAndText2.SetActive(false); 
                    swapSkin(index);
                    PlayerPrefs.SetInt("buying2",1);
                    PlayerPrefs.SetInt("curent skin",2);
                    Esli2skinKyplen = true;

                }
            }
            else
            {
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
        obj.GetComponent<PlayerController>().coinsText = points_text2;
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
