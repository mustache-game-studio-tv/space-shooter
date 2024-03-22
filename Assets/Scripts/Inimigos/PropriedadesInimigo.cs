using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova propriedade inimigo", menuName = "Space Shooter/Inimigos/Proriedades Inimigo")]
public class PropriedadesInimigo : ScriptableObject {

    [SerializeField]
    private ComportamentoMovimentacaoBase comportamentoMovimentacao;

    [SerializeField]
    private int quantidadeMaximaVidas;

    [SerializeField]
    [Range(0, 100)]
    private float chanceSoltarItemVida;

    [SerializeField]
    private ItemVida itemVidaPrefab;

    [SerializeField]
    [Range(0, 100)]
    private float chanceSoltarPowerUp;

    [SerializeField]
    private PowerUpColetavel[] powerUpPrefabs;


    public ComportamentoMovimentacaoBase ComportamentoMovimentacao {
        get {
            return this.comportamentoMovimentacao;
        }
    }

    public int QuantidadeMaximaVidas {
        get {
            return this.quantidadeMaximaVidas;
        }
    }

    public float ChanceSoltarItemVida {
        get {
            return this.chanceSoltarItemVida;
        }
    }

    public ItemVida ItemVidaPrefab {
        get {
            return this.itemVidaPrefab;
        }
    }

    public float ChanceSoltarPowerUp {
        get {
            return this.chanceSoltarPowerUp;
        }
    }

    public PowerUpColetavel[] PowerUpPrefabs {
        get {
            return this.powerUpPrefabs;
        }
    }


}
