using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVida : MonoBehaviour
{

    [SerializeField]
    private int quantidadeVidas;
    [SerializeField]
    private ParticleSystem particulaPrefab;


    public int QuantidadeVidas {
        get {
            return this.quantidadeVidas;
        }
    }

    public void Coletar() {
        ControladorAudio controladorAudio = GameObject.FindObjectOfType<ControladorAudio>();
        controladorAudio.TocarSomVidaColetada();

        // Cria, exibe e destr�i a part�cula
        ParticleSystem particula = Instantiate(this.particulaPrefab, this.transform.position, Quaternion.identity);
        Destroy(particula.gameObject, 1f);

        // Destr�i o item vida
        Destroy(this.gameObject);
    }

}
