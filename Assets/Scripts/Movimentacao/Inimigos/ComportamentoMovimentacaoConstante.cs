using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Comportamento Movimentacao Constante", menuName = "Space Shooter/Inimigos/Movimentacao/Movimentacao Constante")]
public class ComportamentoMovimentacaoConstante : ComportamentoMovimentacaoBase {

    public override Vector2 CalcularVelocidadeAtual(EstadoMovimentacaoBase estadoMovimentacao) {
        return this.velocidadeMovimentacao;
    }

    public override EstadoMovimentacaoBase CriarEstadoMovimentacao() {
        return null;
    }
}