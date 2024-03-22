using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAudio : MonoBehaviour {

    [SerializeField]
    private AudioClip danoEscudo;

    [SerializeField]
    private AudioClip danoJogador;

    [SerializeField]
    private AudioClip derrotaJogador;

    [SerializeField]
    private AudioClip explosaoInimigo;

    [SerializeField]
    private AudioClip laser;

    [SerializeField]
    private AudioClip powerUpColetado;

    [SerializeField]
    private AudioClip vidaColetada;

    [SerializeField]
    private AudioSource audioSource;



    public void TocarSomDanoEscudo() {
        TocarSom(this.danoEscudo);
    }

    public void TocarSomDanoJogador() {
        TocarSom(this.danoJogador);
    }

    public void TocarSomDerrotaJogador() {
        TocarSom(this.derrotaJogador);
    }

    public void TocarSomExplosaoInimigo() {
        TocarSom(this.explosaoInimigo);
    }

    public void TocarSomLaser() {
        TocarSom(this.laser, 0.15f);
    }

    public void TocarSomPowerUpColetado() {
        TocarSom(this.powerUpColetado);
    }

    public void TocarSomVidaColetada() {
        TocarSom(this.vidaColetada);
    }


    private void TocarSom(AudioClip audioClip, float volume = 1) {
        this.audioSource.PlayOneShot(audioClip, volume);
    }

}
