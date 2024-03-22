using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoJogadorToque : IMecanicaMovimentacaoJogador {
    
    private Rigidbody2D rigidbody2d;    
    private float velocidadeMovimentacao;
    private Transform transformJogador;
    private Camera camera;


    public void Configurar(Rigidbody2D rigidbody2d, Transform transformJogador, float velocidadeMovimentacao) {
        this.camera = Camera.main;
        this.rigidbody2d = rigidbody2d;
        this.transformJogador = transformJogador;
        this.velocidadeMovimentacao = velocidadeMovimentacao;
    }

    public void Atualizar() {
        // Caso exista alguma dedo tocando na tela
        if (Input.touchCount > 0) {
            Touch toque = Input.GetTouch(0);
            Vector2 posicaoToque = toque.position;
            Vector2 posicaoNoMundo = this.camera.ScreenToWorldPoint(posicaoToque);

            Vector2 novaPosicao = Vector2.Lerp(this.transformJogador.position, posicaoNoMundo, (this.velocidadeMovimentacao * Time.deltaTime));
            this.rigidbody2d.position = novaPosicao;
        }
    }

}
