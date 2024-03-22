using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.MustacheGameStudioTV.SpawnPoints;

[CreateAssetMenu(fileName = "Nova fase", menuName = "Space Shooter/Fases/Nova fase")]
public class Fase : ScriptableObject {

    public delegate void FaseConcluidaDelegate();
    public FaseConcluidaDelegate FaseConcluida;

    [SerializeField]
    private string nome;

    [SerializeField]
    private ControladorInimigo controladorInimigo;


    private void OnValidate() {
        this.controladorInimigo.AtualizarInspector();
    }

    public string Nome {
        get {
            return this.nome;
        }
    }

    public void Iniciar() {
        this.controladorInimigo.OndasInimigosConcluidas += ConcluirFase;
        this.controladorInimigo.Iniciar();
    }

    public void Atualizar() {
        this.controladorInimigo.Atualizar();
    }

    private void ConcluirFase() {
        this.controladorInimigo.OndasInimigosConcluidas -= ConcluirFase;

        if (this.FaseConcluida != null) {
            this.FaseConcluida.Invoke();
        }
    }

}
