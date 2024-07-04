
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private TMP_Text pointText;
    private int total;
    public int pointMultiplier;


    private void FixedUpdate()
    {
        total += pointMultiplier;
        pointText.text = total.ToString();
    }
}