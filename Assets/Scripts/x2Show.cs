using TMPro;
using UnityEngine;

public class x2Show : MonoBehaviour
{
    [SerializeField] private TMP_Text x2Text;
    private Points point;

    [SerializeField] private GameObject scoreText;

    void Start()
    {
        point = scoreText.GetComponent<Points>();
    }
    void Update()
    {
        if(point.pointMultiplier == 2)
        {
            x2Text.enabled = true;
        }
        else
        {
            x2Text.enabled = false;
        }
    }
}
