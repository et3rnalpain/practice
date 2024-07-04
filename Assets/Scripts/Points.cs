
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private TMP_Text pointText;


    private void Update()
    {
        pointText.text = ((int)(player.position.z / 2)).ToString();
    }
}