using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova configuracao", menuName = "Space Shooter/Inimigos/Nova configuracao controlador inimigo")]
public class ConfiguracaoControladorInimigo : ScriptableObject {

    [SerializeField]
    private ConfiguracaoInimigo[] configuracoesInimigos;

    [SerializeField]
    private float intervaloCriacaoInimigo;

    [SerializeField]
    private int quantidadeTotalInimigos;


    public ConfiguracaoInimigo[] ConfiguracoesInimigos {
        get {
            return this.configuracoesInimigos;
        }
    }

    public float IntervaloCriacaoInimigo {
        get {
            return this.intervaloCriacaoInimigo;
        }
    }

    public int QuantidadeTotalInimigos {
        get {
            return this.quantidadeTotalInimigos;
        }
    }


}
