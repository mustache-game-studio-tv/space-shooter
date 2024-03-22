using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoMovimentacaoSequencia : EstadoMovimentacaoBase {

    private PassoMovimentacaoInimigo[] passosMovimentacaoInimigo;
    private float tempoDecorrido;
    private int indicePassoAtual;


    public EstadoMovimentacaoSequencia(PassoMovimentacaoInimigo[] passosMovimentacaoInimigo) {
        this.passosMovimentacaoInimigo = passosMovimentacaoInimigo;
        this.tempoDecorrido = 0;
        this.indicePassoAtual = 0;
    }

    public override void Atualizar() {
        this.tempoDecorrido += Time.deltaTime;
    }

    public float TempoDecorrido {
        get {
            return this.tempoDecorrido;
        }
    }

    public void AvancarPassoMovimentacao() {
        this.indicePassoAtual++;
        
        if (this.indicePassoAtual == this.passosMovimentacaoInimigo.Length) {
            this.indicePassoAtual = 0;
        }
        this.tempoDecorrido = 0;
    }

    public PassoMovimentacaoInimigo PassoMovimentacaoAtual {
        get {
            return this.passosMovimentacaoInimigo[this.indicePassoAtual];
        }
    }

}
