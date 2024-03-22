using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{


    [SerializeField]
    [Tooltip("Quantidade de dano que pode ser recebido pelo escudo, antes de ser desativado.")]
    private int protecaoTotal;

    /// <summary>
    /// Quantidade atual de dano que o escudo ainda pode receber
    /// </summary>
    private int protecaoAtual;




    public void Ativar() {
        this.protecaoAtual = this.protecaoTotal;
        this.gameObject.SetActive(true);
    }

    public void Desativar() {
        this.gameObject.SetActive(false);
    }

    public bool Ativo {
        get {
            return this.gameObject.activeSelf;
        }
    }

    public void ReceberDano() {
        this.protecaoAtual--;
        if (this.protecaoAtual <= 0) {
            Desativar();
        }
    }

}
