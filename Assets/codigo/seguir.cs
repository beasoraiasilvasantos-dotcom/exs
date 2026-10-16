using UnityEngine;

public class seguir : MonoBehaviour
{
    public Transform cubo;
    public Vector3 chao_sbs;

    void Update()
    {
        transform.position = cubo.position + chao_sbs;
    }
}
