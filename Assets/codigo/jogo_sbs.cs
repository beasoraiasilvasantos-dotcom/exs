using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class jogo_sbs : MonoBehaviour
{
    public float forcaFrente = 30f;
    public float forcaLado = 30f;
    public float velocidadeMaxima = 10f;
    public float alturaQueda = -5f;      // abaixo disto, caiu da plataforma

    public TMP_Text textoVida;
    public TMP_Text textoDinheiro;

    private int vida = 10;
    private int dinheiro = 0;

    private Rigidbody variavel;

    void Start()
    {
        variavel = GetComponent<Rigidbody>();

        if (variavel == null)
        {
            Debug.LogError("Falta o Rigidbody!");
            return;
        }

        AtualizarTextos();
    }

    void FixedUpdate()
    {
        if (variavel == null) return;

        // Avança sozinho
        variavel.AddForce(0, 0, forcaFrente);

        // Setas esquerda/direita
        if (Keyboard.current.leftArrowKey.isPressed)
            variavel.AddForce(-forcaLado, 0, 0);

        if (Keyboard.current.rightArrowKey.isPressed)
            variavel.AddForce(forcaLado, 0, 0);

        // Limita a velocidade horizontal
        Vector3 velocidade = variavel.linearVelocity;
        Vector3 horizontal = new Vector3(velocidade.x, 0f, velocidade.z);

        if (horizontal.magnitude > velocidadeMaxima)
        {
            horizontal = horizontal.normalized * velocidadeMaxima;
            variavel.linearVelocity = new Vector3(horizontal.x, velocidade.y, horizontal.z);
        }

        // Caiu da plataforma
        if (transform.position.y < alturaQueda)
        {
            reiniciar();
        }
    }

    private void OnCollisionEnter(Collision quem)
    {
        // Bateu na parede: reinicia
        if (quem.gameObject.name == "parede")
        {
            reiniciar();
            return;
        }

        // Barreiras: perdem 1 de vida
        if (quem.gameObject.tag == "mau")
        {
            vida--;
            AtualizarTextos();
            Destroy(quem.gameObject);

            if (vida <= 0)
            {
                reiniciar();
            }
        }
    }

    private void OnTriggerEnter(Collider quem)
    {
        if (quem.gameObject.tag == "bom")
        {
            dinheiro += 10;
            AtualizarTextos();
            Destroy(quem.gameObject);
        }
    }

    public void reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void AtualizarTextos()
    {
        if (textoVida != null)
            textoVida.text = "Vida: " + vida;

        if (textoDinheiro != null)
            textoDinheiro.text = "Dinheiro: " + dinheiro;
    }
}