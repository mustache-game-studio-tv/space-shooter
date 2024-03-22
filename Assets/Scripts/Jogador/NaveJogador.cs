using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveJogador : MonoBehaviour {

    private const int QuantidadeMaximaVidas = 5000;

    [SerializeField]
    private bool moverComMouseQuandoDisponivel;

    [SerializeField]
    private Rigidbody2D rigidbody;

    [SerializeField]
    private float velocidadeMovimento;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private ControladorArma controladorArma;

    [SerializeField]
    private Escudo escudo;

    private int vidas;
    private FimJogo telaFimJogo;
    private EfeitoPowerUp powerUpAtual;
    private ControladorAudio controladorAudio;
    private IMecanicaMovimentacaoJogador mecanicaMovimentacao;
    

    private void Start()  {
        this.vidas = QuantidadeMaximaVidas;
        ControladorPontuacao.Pontuacao = 0;

        GameObject fimJogoGameObject = GameObject.FindGameObjectWithTag("TelaFimJogo");
        this.telaFimJogo = fimJogoGameObject.GetComponent<FimJogo>();
        this.telaFimJogo.Esconder();

        EquiparArmaDisparoAlternado();
        this.escudo.Desativar();

        this.controladorAudio = GameObject.FindObjectOfType<ControladorAudio>();

#if UNITY_ANDROID || UNITY_IOS
        // Está sendo executado dentro do Android ou iPhone
        this.mecanicaMovimentacao = new MovimentacaoJogadorToque();
#else
        // Executando em qualquer outra plataforma que não é Android, nem iOS
        if (this.moverComMouseQuandoDisponivel) {
            this.mecanicaMovimentacao = new MovimentacaoJogadorMouse();
        } else {            
            this.mecanicaMovimentacao = new MovimentacaoJogadorTeclado();
        }
#endif

        this.mecanicaMovimentacao.Configurar(this.rigidbody, this.transform, this.velocidadeMovimento);
    }

    public void Update() {
        this.mecanicaMovimentacao.Atualizar();

        VerificarLimiteTela();

        if (this.powerUpAtual != null) {
            this.powerUpAtual.Atualizar();
            if (!this.powerUpAtual.Ativo) {
                this.powerUpAtual.Remover(this);
                this.powerUpAtual = null;
            }
        }
    }

    public void EquiparArmaDisparoAlternado() {
        this.controladorArma.EquiparArmaDisparoAlternado();
    }

    public void EquiparArmaDisparoDuplo() {
        this.controladorArma.EquiparArmaDisparoDuplo();
    }

    public void EquiparArmaDisparoEspalhado() {
        this.controladorArma.EquiparArmaDisparoEspalhado();
    }

    public void AtivarEscudo() {
        this.escudo.Ativar();
    }

    public void DesativarEscudo() {
        this.escudo.Desativar();
    }

    private void VerificarLimiteTela() {
        Vector2 posicaoAtual = this.transform.position;

        float metadeLargura = Largura / 2f;
        float metadeAltura = Altura / 2f;

        Camera camera = Camera.main;
        Vector2 limiteInferiorEsquerdo = camera.ViewportToWorldPoint(Vector2.zero); // (0, 0)
        Vector2 limiteSuperiorDireito = camera.ViewportToWorldPoint(Vector2.one); // (1, 1)

        float pontoReferenciaEsquerdo = posicaoAtual.x - metadeLargura;
        float pontoReferenciaDireito = posicaoAtual.x + metadeLargura;

        if (pontoReferenciaEsquerdo < limiteInferiorEsquerdo.x) { // Saindo pela esquerda
            this.transform.position = new Vector2(limiteInferiorEsquerdo.x + metadeLargura, posicaoAtual.y);
        } else if (pontoReferenciaDireito > limiteSuperiorDireito.x) { // Saindo pela direita
            this.transform.position = new Vector2(limiteSuperiorDireito.x - metadeLargura, posicaoAtual.y);
        }

        posicaoAtual = this.transform.position;

        float pontoReferenciaSuperior = posicaoAtual.y + metadeAltura;
        float pontoReferenciaInferior = posicaoAtual.y - metadeAltura;

        if (pontoReferenciaSuperior > limiteSuperiorDireito.y) { // Saindo por cima
            this.transform.position = new Vector2(posicaoAtual.x, limiteSuperiorDireito.y - metadeAltura);
        } else if (pontoReferenciaInferior < limiteInferiorEsquerdo.y) { // Saindo por baixo
            this.transform.position = new Vector2(posicaoAtual.x, limiteInferiorEsquerdo.y + metadeAltura);
        }

    }

    private float Largura {
        get {
            Bounds bounds = this.spriteRenderer.bounds;
            Vector3 tamanho = bounds.size;
            return tamanho.x;
        }
    }

    private float Altura {
        get {
            Bounds bounds = this.spriteRenderer.bounds;
            Vector3 tamanho = bounds.size;
            return tamanho.y;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Inimigo")) {
            Inimigo inimigo = collider.GetComponent<Inimigo>();
            ColidirInimigo(inimigo);
        } else if (collider.CompareTag("ItemVida")) {
            ItemVida itemVida = collider.GetComponent<ItemVida>();
            ColetarItemVida(itemVida);
        } else if (collider.CompareTag("PowerUp")) {
            PowerUpColetavel powerUp = collider.GetComponent<PowerUpColetavel>();
            ColetarPowerUp(powerUp);
        }
    }

    private void ColidirInimigo(Inimigo inimigo) {        
        if (this.escudo.Ativo) {
            controladorAudio.TocarSomDanoEscudo();
            this.escudo.ReceberDano();
        } else {
            controladorAudio.TocarSomDanoJogador();
            // Caso o escudo não esteja ativo,
            // o dano será aplicado no jogador
            Vida--;
        }
        inimigo.ReceberDano();
    }

    private void ColetarItemVida(ItemVida itemVida) {
        Vida += itemVida.QuantidadeVidas;
        itemVida.Coletar();
    }

    private void ColetarPowerUp(PowerUpColetavel powerUp) {        
        if (this.powerUpAtual != null) {
            this.powerUpAtual.Remover(this);
        }

        EfeitoPowerUp efeitoPowerUp = powerUp.EfeitoPowerUp;
        efeitoPowerUp.Aplicar(this);
        this.powerUpAtual = efeitoPowerUp;

        powerUp.Coletar();
    }

    public int Vida {
        get {
            return this.vidas;
        }
        set {
            this.vidas = value;
            if (this.vidas > QuantidadeMaximaVidas) {
                this.vidas = QuantidadeMaximaVidas;
            } else if (this.vidas <= 0) {
                this.vidas = 0;
                this.gameObject.SetActive(false);
                // Exibir tela de fim de jogo               
                telaFimJogo.Exibir();

                this.controladorAudio.TocarSomDerrotaJogador();
            }
        }
    }

}
