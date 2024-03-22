using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpColetavel : MonoBehaviour {

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float intervaloTempoAntesAutodestruir;


    [SerializeField]
    private int quantidadeTotalPiscadas;

    [SerializeField]
    private float intervaloTempoEntrePiscadas;

    [SerializeField]
    private float reducaoTempoEntrePiscadas;

    [SerializeField]
    private float duracaoEmSegundos;


    private float contagemTempoAntesAutodestruir;
    private bool autodestruindo;


    public abstract EfeitoPowerUp EfeitoPowerUp { get; }



    public void Start() {
        this.autodestruindo = false;
        this.contagemTempoAntesAutodestruir = 0;
    }

    public void Update() {
        // Caso n�o esteja autodestruindo
        if (!this.autodestruindo) {
            // Executa a contagem de tempo antes de iniciar a autodestruição
            this.contagemTempoAntesAutodestruir += Time.deltaTime;
            if (this.contagemTempoAntesAutodestruir >= this.intervaloTempoAntesAutodestruir) {
                // Iniciar a autodestruição
                IniciarAutodestruicao();
            }
        }
    }

    public float DuracaoEmSegundos {
        get {
            return this.duracaoEmSegundos;
        }
    }

    public void Coletar() {
        ControladorAudio controladorAudio = GameObject.FindObjectOfType<ControladorAudio>();
        controladorAudio.TocarSomPowerUpColetado();
        Destroy(this.gameObject);
    }

    private void IniciarAutodestruicao() {
        this.autodestruindo = true;
        StartCoroutine(Autodestruir());
    }

    private IEnumerator Autodestruir() {
        int contadorPiscadas = 0;
        do {
            this.spriteRenderer.enabled = !this.spriteRenderer.enabled;
            // Esperar um intervalo de tempo
            yield return new WaitForSeconds(this.intervaloTempoEntrePiscadas);
            contadorPiscadas++;
            this.intervaloTempoEntrePiscadas -= contadorPiscadas * this.reducaoTempoEntrePiscadas;          
        } while (contadorPiscadas < this.quantidadeTotalPiscadas);

        Destroy(this.gameObject);
    }


}
