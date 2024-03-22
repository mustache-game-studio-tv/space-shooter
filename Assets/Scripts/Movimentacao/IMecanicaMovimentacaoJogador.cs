using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMecanicaMovimentacaoJogador {

    void Configurar(Rigidbody2D rigidbody2d, Transform transformJogador, float velocidadeMovimentacao);

    void Atualizar();


}
