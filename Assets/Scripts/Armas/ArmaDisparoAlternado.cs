using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaDisparoAlternado : ArmaBasica
{

    private Transform posicaoProximoDisparo;


    public override void Start() {
        base.Start();
        this.posicaoProximoDisparo = this.posicoesDisparo[0];
    }


    protected override void Atirar() {
        // Criar um laser
        CriarLaser(this.posicaoProximoDisparo.position);

        // Alternar as armas
        if (this.posicaoProximoDisparo == this.posicoesDisparo[0]) {
            this.posicaoProximoDisparo = this.posicoesDisparo[1];
        } else {
            this.posicaoProximoDisparo = this.posicoesDisparo[0];
        }
    }

    
}