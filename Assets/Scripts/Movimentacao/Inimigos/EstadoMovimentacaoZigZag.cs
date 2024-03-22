using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoMovimentacaoZigZag : EstadoMovimentacaoBase {

    private float tempoDecorrido;

    public override void Atualizar() {
        this.tempoDecorrido += Time.deltaTime;
    }

    public float TempoDecorrido {
        get {
            return this.tempoDecorrido;
        }
    }

}
