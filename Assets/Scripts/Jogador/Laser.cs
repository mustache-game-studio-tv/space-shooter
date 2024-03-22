using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public Rigidbody2D rigidbody;
    public float velocidadeY;
    
    private void Start()
    {
        ControladorAudio controladorAudio = GameObject.FindObjectOfType<ControladorAudio>();
        controladorAudio.TocarSomLaser();
        Direcao = this.transform.up;
    }

    private void Update() {
        Camera camera = Camera.main;
        Vector3 posicaoNaCamera = camera.WorldToViewportPoint(this.transform.position);
        // Saiu da tela pela parte superior
        if (posicaoNaCamera.y > 1 || posicaoNaCamera.y < 0 || posicaoNaCamera.x > 1 || posicaoNaCamera.x < 0) {
            // Destrói o próprio laser
            Destroy(this.gameObject);
        }
    }

    public Vector2 Direcao {
        set {
            this.transform.up = value;
            this.rigidbody.velocity = this.transform.up * this.velocidadeY;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Inimigo")) {
            // Destrói o inimigo
            Inimigo inimigo = collider.GetComponent<Inimigo>();
            inimigo.ReceberDano();
            // Destrói o próprio laser
            Destroy(this.gameObject);
        }
    }

}