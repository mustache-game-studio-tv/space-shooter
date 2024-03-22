using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorFase : MonoBehaviour {

    [SerializeField]
    private Fase[] fases;

    private int indiceFaseAtual;
    private Fase faseAtual;
    
    private void Start() {
        this.indiceFaseAtual = -1;
        AvancarParaProximaFase();
    }

    private void Update() {
        if (this.faseAtual != null) {
            this.faseAtual.Atualizar();
        }
    }

    public void ConcluirFase() {
        this.faseAtual.FaseConcluida -= ConcluirFase;

        if (TemProximaFase()) {
            AvancarParaProximaFase();
        } else {
            Debug.Log("Fim de jogo. Todas as fases foram concluídas.");
        }
    }

    private void AvancarParaProximaFase() {
        AnimacaoTransicaoFase.Instancia.AnimacaoTransicaoFaseConcluida += TransicaoFaseConcluida;

        Fase proximaFase = this.fases[this.indiceFaseAtual + 1];
        AnimacaoTransicaoFase.Instancia.Exibir(proximaFase.Nome);        
    }

    private void TransicaoFaseConcluida() {
        AnimacaoTransicaoFase.Instancia.AnimacaoTransicaoFaseConcluida -= TransicaoFaseConcluida;

        if (this.faseAtual != null) {
            Debug.Log("Fase " + this.faseAtual.Nome + " foi concluída. Avançando para a próxima fase...");
        }

        this.indiceFaseAtual++;
        IniciarFaseAtual();
    }

    private bool TemProximaFase() {
        if (this.indiceFaseAtual < (this.fases.Length - 1)) {
            return true;
        }
        return false;
    }

    private void IniciarFaseAtual() {
        this.faseAtual = this.fases[this.indiceFaseAtual];
        this.faseAtual.FaseConcluida += ConcluirFase;
        this.faseAtual.Iniciar();
    }
}
