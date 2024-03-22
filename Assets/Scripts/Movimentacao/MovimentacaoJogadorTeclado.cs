using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoJogadorTeclado : IMecanicaMovimentacaoJogador {

    private Rigidbody2D rigidbody2d;
    private float velocidadeMovimentacao;

    public void Configurar(Rigidbody2D rigidbody2d, Transform transformJogador, float velocidadeMovimentacao) {
        this.rigidbody2d = rigidbody2d;
        this.velocidadeMovimentacao = velocidadeMovimentacao;
    }

    public void Atualizar() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float velocidadeX = (horizontal * this.velocidadeMovimentacao);
        float velocidadeY = (vertical * this.velocidadeMovimentacao);

        this.rigidbody2d.velocity = new Vector2(velocidadeX, velocidadeY);
    }

}
