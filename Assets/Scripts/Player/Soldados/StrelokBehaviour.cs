﻿using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class StrelokBehaviour : SoldadoBehaviour
{
    void Start()
    {
        this.podeJogar = true;
        this.agente = this.GetComponent<NavMeshAgent>();
        this.weapon = this.GetComponentInChildren<WeaponBehaviour>();
        this.vida = 100;
        this.delay = 1;
        this.precisao = 1;
        this.tamanho = 1;
        this.danoCorpoACorpo = 10;
    }

    public override void Skills()
    {
        if (Input.GetButtonDown("Q"))
        {
            this.weapon.AtivarOuDesativarHabilidade();
        }

        if (Input.GetButtonDown("W"))
        {
            this.ModoAgachado();
        }

        if (Input.GetButtonDown("E"))
        {
            this.AumentarVelocidadeDeCorrer();
        }

        if (Input.GetButtonDown("R"))
        {
            this.ArremessarGranada();
        }
    }
}
