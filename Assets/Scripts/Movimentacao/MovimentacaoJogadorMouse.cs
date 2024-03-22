using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoJogadorMouse : IMecanicaMovimentacaoJogador {


    private Rigidbody2D rigidbody2d;
    private float velocidadeMovimentacao;
    private Camera camera;
    private Transform transformJogador;


    public void Configurar(Rigidbody2D rigidbody2d, Transform transformJogador, float velocidadeMovimentacao) {
        this.camera = Camera.main;
        this.rigidbody2d = rigidbody2d;
        this.transformJogador = transformJogador;
        this.velocidadeMovimentacao = velocidadeMovimentacao;
    }

    public void Atualizar() {
        Vector2 posicaoMouse = Input.mousePosition;
        Vector2 posicaoNoMundo = this.camera.ScreenToWorldPoint(posicaoMouse);

        Vector2 novaPosicao = Vector2.Lerp(this.transformJogador.position, posicaoNoMundo, (this.velocidadeMovimentacao * Time.deltaTime));
        this.rigidbody2d.position = novaPosicao;
    }

}
