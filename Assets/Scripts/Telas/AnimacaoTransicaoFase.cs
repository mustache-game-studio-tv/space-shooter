using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimacaoTransicaoFase : MonoBehaviour {

    public delegate void AnimacaoTrasicaoFaseConcluidaDelegate();
    public AnimacaoTrasicaoFaseConcluidaDelegate AnimacaoTransicaoFaseConcluida;

    [SerializeField]
    private TextMeshProUGUI textoNomeFase;

    [SerializeField]
    private Animator animator;

    // Singleton
    private static AnimacaoTransicaoFase instancia;


    private void Awake() {
        instancia = this;
        Esconder();
    }

    public static AnimacaoTransicaoFase Instancia {
        get {
            return instancia;
        }
    }

    public void Exibir(string nomeFase) {
        this.gameObject.SetActive(true);
        this.textoNomeFase.text = nomeFase;
        this.animator.Play("TransicaoFase");
    }

    public void Esconder() {
        this.gameObject.SetActive(false);
    }

    public void ConcluirAnimacaoTransicao() {
        Esconder();
        if (this.AnimacaoTransicaoFaseConcluida != null) {
            this.AnimacaoTransicaoFaseConcluida.Invoke();
        }
    }


}
