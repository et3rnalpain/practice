
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class shopmenu : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    // Start is called before the first frame update
    void Start()
    {
        int coins = PlayerPrefs.GetInt("coins");
        coinsText.text = coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("coins") != int.Parse(coinsText.text)) coinsText.text = PlayerPrefs.GetInt("coins").ToString();
    }
}
