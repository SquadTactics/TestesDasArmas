﻿using UnityEngine;
using System.Collections;

public class DP28Behaviour : WeaponBehaviour {

    private bool modoSupressao;

    // Start is called before the first frame update
    void Start()
    {
        this.podeAtirar = true;
        this.modoSupressao = false;
        this.capacidade = 45;
        this.danoPequena = 16;
        this.danoMedio = 12;
        this.danoLongo = 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.capacidade == 0)
        {
            this.podeAtirar = false;
            StartCoroutine(Recarregar());
        }

        if (Input.GetButtonDown("W"))
        {
            this.AtivarModoSupressao();
        }

        if (Input.GetButtonDown("Q"))
        {
            this.AtivarModoNormal();
        }
    }

    public override void Atirar(PlayerBehaviour alvo)
    {
        if (this.podeAtirar)
        {
            this.podeAtirar = false;
            if (!this.modoSupressao)
            {
                int sorteio = (int)Random.Range(5, 7);
                StartCoroutine(Disparar(sorteio, 1, alvo));
            }
            else
            {
                StartCoroutine(Disparar(45, 6, alvo));
            }
        }
    }

    private IEnumerator Disparar(int vezes, int tempoPraVoltarAtirar, PlayerBehaviour alvo)
    {
        for (int i = 0; i < vezes; i++)
        {
            if (this.capacidade > 0)
            {
                float distancia = Vector3.Distance(alvo.transform.position, this.canoDaArma.transform.position);
                this.CalcularDano(distancia);
                alvo.LevaDano(this.dano);
                this.capacidade--;
                yield return new WaitForSeconds(0.2f);
            }
        }
        yield return new WaitForSeconds(tempoPraVoltarAtirar);
        this.podeAtirar = true;
    }

    public override IEnumerator Recarregar()
    {
        yield return new WaitForSeconds(3);
        this.capacidade = 45;
        this.podeAtirar = true;
    }

    public void AtivarModoSupressao()
    {
        this.modoSupressao = true;
    }

    public void AtivarModoNormal()
    {
        this.modoSupressao = false;
    }

    private void CalcularDano(float distancia)
    {
        if (distancia >= 2 && distancia <= 4)
        {
            this.dano = this.danoPequena;
        }
        else if (distancia > 4 && distancia <= 8)
        {
            this.dano = this.danoMedio;
        }
        else if (distancia > 8 && distancia <= 12)
        {
            this.dano = this.danoLongo;
        }
    }
}
