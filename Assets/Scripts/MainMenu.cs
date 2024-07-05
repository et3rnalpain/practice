
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        int coins = PlayerPrefs.GetInt("coins");
        coinsText.text = coins.ToString();
        int score = PlayerPrefs.GetInt("score");
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("coins") != int.Parse(coinsText.text)) coinsText.text = PlayerPrefs.GetInt("coins").ToString();
        if (PlayerPrefs.GetInt("score") != int.Parse(scoreText.text)) scoreText.text = PlayerPrefs.GetInt("score").ToString();
    }
}
