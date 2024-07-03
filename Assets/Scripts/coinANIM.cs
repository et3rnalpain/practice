
using UnityEngine;

public class coinANIM : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(Vector3.forward, 150 * Time.deltaTime);
    }
}
