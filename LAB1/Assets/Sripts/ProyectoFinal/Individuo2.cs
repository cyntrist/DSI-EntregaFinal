using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Individuo2 : MonoBehaviour
{

    public event Action Cambio;

    private string nombre;

    public string Nombre
    {
        get { return nombre; }
        set
        {
            if (nombre != value)
            {
                nombre = value;
                Cambio?.Invoke();
            }
        }
    }


    private string element;

    public string Element
    {
        get { return element; }
        set
        {
            if (element != value)
            {
                element = value;
                Cambio?.Invoke();
            }
        }
    }


    private int hp;

    public int HP
    {
        get { return hp; }
        set
        {
            if (hp != value)
            {
                hp = value;
                Cambio?.Invoke();
            }
        }
    }


    private int atk;

    public int Attk
    {
        get { return atk; }
        set
        {
            if (atk != value)
            {
                atk = value;
                Cambio?.Invoke();
            }
        }
    }


    private int def;
    public int Def
    {
        get { return def; }
        set
        {
            if (def != value)
            {
                def = value;
                Cambio?.Invoke();
            }
        }
    }




    private int em;
    public int EM
    {
        get { return em; }
        set
        {
            if (em != value)
            {
                em = value;
                Cambio?.Invoke();
            }
        }
    }


    private int lvl;

    public int LVL
    {
        get { return lvl; }
        set
        {
            if (lvl != value)
            {
                lvl = value;
                Cambio?.Invoke();
            }
        }
    }

    private Sprite icon;

    public Sprite Icon
    {
        get { return icon; }
        set
        {
            if (icon != value)
            {
                icon = value;
                Cambio?.Invoke();
            }
        }
    }


    private string icon_route;

    public string IconRoute
    {
        get { return icon_route; }
        set
        {
            if (icon_route != value)
            {
                icon_route = value;
                Cambio?.Invoke();
            }
        }
    }


    public Individuo2(string nombre, string element)
    {
        this.nombre = nombre;
        this.element = element;
        this.hp = 0;
        this.em = 0;
        this.def = 0;
        this.atk = 0;
        this.lvl = 0;
        icon = null;
    }

    public void setStats(int l, int a, int h, int d, int e)
    {
        this.hp = h;
        this.em = e;
        this.def = d;
        this.atk = a;
        this.lvl = l;
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

