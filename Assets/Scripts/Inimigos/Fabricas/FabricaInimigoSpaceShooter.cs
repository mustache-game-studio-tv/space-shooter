using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.MustacheGameStudioTV.SpawnPoints;


[CreateAssetMenu(fileName = "Nova fabrica inimigos", menuName = "Space Shooter/Inimigos/Fabricas/Nova fabrica")]
public class FabricaInimigoSpaceShooter : FabricaInimigo {

    [SerializeField]
    private Inimigo prefabInimigo;

    [SerializeField]
    private PropriedadesInimigo propriedadesInimigo;


    public override InimigoBase CriarInimigo(Vector3 posicao) {
        Inimigo novoInimigo = Instantiate(this.prefabInimigo, posicao, Quaternion.identity);
        novoInimigo.Configurar(this.propriedadesInimigo);

        return novoInimigo;
    }

}
