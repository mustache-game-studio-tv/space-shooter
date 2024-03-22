using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Comportamento Movimentacao ZigZag", menuName = "Space Shooter/Inimigos/Movimentacao/Movimentacao ZigZag")]
public class ComportamentoMovimentacaoZigZag : ComportamentoMovimentacaoBase {

    [SerializeField]
    private float amplitudeMovimentacaoX;

    public override Vector2 CalcularVelocidadeAtual(EstadoMovimentacaoBase estadoMovimentacao) {
        EstadoMovimentacaoZigZag estadoMovimentacaoZigZag = (EstadoMovimentacaoZigZag)estadoMovimentacao;

        float sentidoMovimentacao = Mathf.Sin(estadoMovimentacaoZigZag.TempoDecorrido * this.velocidadeMovimentacao.x);
        // Converte o valor do seno (sentidoMovimentacao) de uma faixa entre -1 e 1
        // para uma nova faixa de valores entre 0 e 1
        sentidoMovimentacao = ((sentidoMovimentacao / 2f) + 0.5f);
        float velocidadeX = sentidoMovimentacao * this.amplitudeMovimentacaoX;
        return new Vector2(velocidadeX, this.velocidadeMovimentacao.y);
    }

    public override EstadoMovimentacaoBase CriarEstadoMovimentacao() {
        return new EstadoMovimentacaoZigZag();
    }
}
