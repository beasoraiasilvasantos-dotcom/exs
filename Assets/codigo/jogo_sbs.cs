
using UnityEngine;

public class jogo_sbs : MonoBehaviour
{
    private Rigidbody variavel;

    void Start()
    {
        variavel = GetComponent<Rigidbody>();

        if (variavel == null)
        {
            Debug.LogError("Falta o Rigidbody!");
            return;
        }

        // Movimento horizontal, sem salto
        variavel.AddForce(0, 0, 800);
    }

    void FixedUpdate()
    {
        if (variavel == null) return;

        // Impede o cubo de subir ou descer
        Vector3 velocidade = variavel.linearVelocity;
        velocidade.y = 0f;

        // Mantém a velocidade horizontal
        if (velocidade.magnitude > 0f)
        {
            velocidade = velocidade.normalized * 10f;
        }

        variavel.linearVelocity = velocidade;
    }
}