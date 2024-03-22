using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Comportamento Movimentacao Sequencia", menuName = "Space Shooter/Inimigos/Movimentacao/Movimentacao Sequencia")]
public class ComportamentoMovimentacaoSequencia : ComportamentoMovimentacaoBase {

    [SerializeField]
    private PassoMovimentacaoInimigo[] passosMovimentacaoInimigo;

    [SerializeField]
    private float duracaoPassoMovimentacao;
    
    public override Vector2 CalcularVelocidadeAtual(EstadoMovimentacaoBase estadoMovimentacao) {
        EstadoMovimentacaoSequencia estadoMovimentacaoSequencia = (EstadoMovimentacaoSequencia)estadoMovimentacao;
        PassoMovimentacaoInimigo passoMovimentacaoAtual = estadoMovimentacaoSequencia.PassoMovimentacaoAtual;

        if (estadoMovimentacaoSequencia.TempoDecorrido >= this.duracaoPassoMovimentacao) {
            // Já executou o passo atual por tempo suficiente.
            // Movimentação deve ser alterada para o prõximo passo.
            estadoMovimentacaoSequencia.AvancarPassoMovimentacao();
        }

        if (passoMovimentacaoAtual == PassoMovimentacaoInimigo.Subir) {
            return new Vector2(0, this.velocidadeMovimentacao.y);
        } else if (passoMovimentacaoAtual == PassoMovimentacaoInimigo.Descer) {
            return new Vector2(0, -this.velocidadeMovimentacao.y);
        } else if (passoMovimentacaoAtual == PassoMovimentacaoInimigo.EsquerdaParaDireita) {
            return new Vector2(this.velocidadeMovimentacao.x, 0);
        } else {
            return new Vector2(-this.velocidadeMovimentacao.x, 0);
        }
    }

    public override EstadoMovimentacaoBase CriarEstadoMovimentacao() {
        return new EstadoMovimentacaoSequencia(this.passosMovimentacaoInimigo);
    }
}
