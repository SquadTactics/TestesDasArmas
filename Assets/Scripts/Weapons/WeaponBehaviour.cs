﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 
 */
public abstract class WeaponBehaviour : MonoBehaviour
{

    // Bullet.
    public BulletsBehaviour projetil;

    protected float danoPequena;
    protected float danoMedio;
    protected float danoLongo;
    protected float dano;

    // Speed that the gun can re-shoot.
    protected float velocidade;

    // Shots fired before velocity was reached.
    protected int disparados;

    // Total allowed shots and then wait a while to re-shoot.
    protected int limitesDeDisparos;

    // Capacity of weapon.
    protected int capacidade;

    // Penetration of weapon.
    protected int penetracao;

    // Tempo para arma voltar a atirar depois de ser totalmente descarregada(Tempo de reload).
    protected float tempo;

    // Verifica se a arma pode disparar.
    protected bool podeAtirar;

    public Transform canoDaArma;


    /// <summary>
    ///    Method that will treat the weapon logic of instantiating the bullet.
    /// </summary>
    public abstract void Atirar(PlayerBehaviour alvo);

    /// <summary>
    ///     Method that deals with the logic of reloading the weapon.
    /// </summary>
    public abstract IEnumerator Recarregar();
}
