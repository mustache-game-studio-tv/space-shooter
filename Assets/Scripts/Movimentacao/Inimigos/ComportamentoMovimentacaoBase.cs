using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ComportamentoMovimentacaoBase : ScriptableObject {

    [SerializeField]
    protected Vector2 velocidadeMovimentacao;

    public abstract Vector2 CalcularVelocidadeAtual(EstadoMovimentacaoBase estadoMovimentacao);

    public abstract EstadoMovimentacaoBase CriarEstadoMovimentacao();

}
