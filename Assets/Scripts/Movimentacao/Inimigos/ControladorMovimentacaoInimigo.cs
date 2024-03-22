using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMovimentacaoInimigo {

    private ComportamentoMovimentacaoBase comportamentoMovimentacao;
    private EstadoMovimentacaoBase estadoMovimentacao;


    public ControladorMovimentacaoInimigo(ComportamentoMovimentacaoBase comportamentoMovimentacao) {
        this.comportamentoMovimentacao = comportamentoMovimentacao;
        this.estadoMovimentacao = this.comportamentoMovimentacao.CriarEstadoMovimentacao();
    }

    public void Atualizar() {
        if (this.estadoMovimentacao != null) {
            this.estadoMovimentacao.Atualizar();
        }
    }

    public Vector2 CalcularVelocidadeAtual() {
        return this.comportamentoMovimentacao.CalcularVelocidadeAtual(this.estadoMovimentacao);
    }

}
