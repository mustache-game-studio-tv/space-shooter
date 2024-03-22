using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.MustacheGameStudioTV.SpawnPoints;

public class Inimigo : InimigoBase {

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody;
    public ParticleSystem particulaExplosaoPrefab;    

    private int vidas;
    private PropriedadesInimigo propriedadesInimigo;
    private ControladorMovimentacaoInimigo controladorMovimentacao;


    void Start() {
        Vector2 posicaoAtual = this.transform.position;
        float metadeLargura = Largura / 2f;

        float pontoReferenciaEsquerda = posicaoAtual.x - metadeLargura;
        float pontoReferenciaDireita = posicaoAtual.x + metadeLargura;

        Camera camera = Camera.main;
        Vector2 limiteInferiorEsquerdo = camera.ViewportToWorldPoint(Vector2.zero); // (0, 0)
        Vector2 limiteSuperiorDireito = camera.ViewportToWorldPoint(Vector2.one); // (1, 1)

        if (pontoReferenciaEsquerda < limiteInferiorEsquerdo.x) {
            // Inimigo saiu pela esquerda
            float posicaoX = limiteInferiorEsquerdo.x + metadeLargura;
            this.transform.position = new Vector2(posicaoX, posicaoAtual.y);
        } else if (pontoReferenciaDireita > limiteSuperiorDireito.x) {
            // Inimigo saiu pela direita
            float posicaoX = limiteSuperiorDireito.x - metadeLargura;
            this.transform.position = new Vector2(posicaoX, posicaoAtual.y);
        }
    }


    void Update() {
        this.controladorMovimentacao.Atualizar();
        this.rigidbody.velocity = this.controladorMovimentacao.CalcularVelocidadeAtual();

        Camera camera = Camera.main;
        Vector3 posicaoNaCamera = camera.WorldToViewportPoint(this.transform.position);
        if (posicaoNaCamera.y < 0) {
            // Inimigo saiu da �rea d� c�mera
            NaveJogador jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<NaveJogador>();
            jogador.Vida--;
            Destruir(false);
        }
    }

    public void Configurar(PropriedadesInimigo propriedadesInimigo) {
        this.propriedadesInimigo = propriedadesInimigo;
        this.vidas = this.propriedadesInimigo.QuantidadeMaximaVidas;
        this.controladorMovimentacao = new ControladorMovimentacaoInimigo(this.propriedadesInimigo.ComportamentoMovimentacao);
    }

    public void ReceberDano() {
        this.vidas--;
        if (this.vidas <= 0) {
            Destruir(true);
        }
    }

    private float Largura {
        get {
            Bounds bounds = this.spriteRenderer.bounds;
            Vector3 tamanho = bounds.size;
            return tamanho.x;
        }
    }

    private void Destruir(bool derrotado) {
        Destruir();

        if (derrotado) {
            ControladorPontuacao.Pontuacao++;
            SoltarItemVida();
            SoltarPowerUp();
        }

        ControladorAudio controladorAudio = GameObject.FindObjectOfType<ControladorAudio>();
        controladorAudio.TocarSomExplosaoInimigo();

        ParticleSystem particulaExplosao = Instantiate(this.particulaExplosaoPrefab, this.transform.position, Quaternion.identity);
        Destroy(particulaExplosao.gameObject, 1f); // Destr�i a part�cula ap�s 1 segundo
        Destroy(this.gameObject);
    }

    private void SoltarItemVida() {
        float chanceAleatoria = Random.Range(0f, 100f);
        if (chanceAleatoria <= this.propriedadesInimigo.ChanceSoltarItemVida) {
            // Soltar o item vida
            Instantiate(this.propriedadesInimigo.ItemVidaPrefab, this.transform.position, Quaternion.identity);
        }
    }

    private void SoltarPowerUp() {
        float chanceAleatoria = Random.Range(0f, 100f);
        if (chanceAleatoria <= this.propriedadesInimigo.ChanceSoltarPowerUp) {
            // Criar um power-up
            PowerUpColetavel[] powerUpPrefabs = this.propriedadesInimigo.PowerUpPrefabs;
            int indiceAleatorioPowerUp = Random.Range(0, powerUpPrefabs.Length);
            PowerUpColetavel powerUpPrefab = powerUpPrefabs[indiceAleatorioPowerUp];
            Instantiate(powerUpPrefab, this.transform.position, Quaternion.identity);
        }
    }

}
