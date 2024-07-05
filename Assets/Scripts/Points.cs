
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private TMP_Text pointText;
    private int total;
    public int pointMultiplier;

    public bool isGameStarted;


    private void FixedUpdate()
    {
        if(isGameStarted)
        {
            total += pointMultiplier;
            pointText.text = total.ToString();
        }
    }
}