using Lab5b_namespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using PF;
using static Unity.VisualScripting.LudiqRootObjectEditor;
using System.Buffers.Text;
using System.Linq;
using UnityEngine.XR;
using TMPro;





public class PFScript : MonoBehaviour
    {
        [SerializeField]
        List<Sprite> icons;

        List<Tarjeta2> tarjetas;

        List<VisualElement> tarjetasl;

        List<Individuo> datos;

        int i2;

        VisualElement info;

        Label char_name;
        Label char_atk;
        Label char_def;
        Label char_hp;
        Label char_em;
        Label char_level;

        VisualElement char_select;

        VisualElement root;

    [SerializeField]
    List<Sprite> backgrounds;



    VisualElement lastSelected;

        Individuo2 selectIndividuo;


        private void OnEnable()
        {
            root = GetComponent<UIDocument>().rootVisualElement;

            char_name = root.Q<Label>("name");
            char_atk = root.Q<Label>("atk_value");
            char_def = root.Q<Label>("def_value");
            char_hp = root.Q<Label>("hp_value");
            char_em = root.Q<Label>("em_value");

        Label char_s = root.Q<Label>("sel");
        char_s.text = @" <rotate=""30""> Character Selection </rotate>
        ";

        char_select = root.Q<VisualElement>("charas2");

            Debug.Log(char_select);


            datos = Database.getData();

            Debug.Log(datos);

            
            InitializeUI();


        }


        void SeleccionTarjeta(ClickEvent e)
        {

            Debug.Log("SON LAS TRES DE LA MAÑANAAAAAAAAAAAA");   

            VisualElement tarjeta = e.target as VisualElement;
            VisualElement father = tarjeta.parent as VisualElement;
            VisualElement top = father.parent as VisualElement;
            VisualElement b = top.Q<VisualElement>("border");
            Label name = b.Q<Label>("name");
            Label id = b.Q<Label>("id");
            string idt = id.text;
            int i = 0;


        switch (idt)
        {
            case "0":
                i = 0;
                break;
            case "1":
                i = 1;
                break;
            case "2":
                i = 2;
                break;
            case "3":
                i = 3;
                break;
            case "4":
                i = 4;
                break;
            case "5":
                i = 5;
                break;
            case "6":
                i = 6;
                break;
            case "7":
                i = 7;
                break;
        }


            char_name.text = name.text;
       
        char_atk.text = datos[i].Attk.ToString();
            char_def.text = datos[i].Def.ToString();
            char_hp.text = datos[i].HP.ToString();
            char_em.text = datos[i].EM.ToString();

        VisualElement ba = root.Q<VisualElement>("base");

        ba.style.backgroundImage = new StyleBackground(backgrounds[i]);

            
        }

        void CambioNombre(ClickEvent evt)
        {
            VisualElement a = evt.target as VisualElement;

            selectIndividuo.Nombre = a.Q<Label>("name").text;
        }

        void CambioElemento(ChangeEvent<string> evt)
        {
            selectIndividuo.Element = evt.newValue;

        }

    void tarjeta_borde_negro()
    {
        if (lastSelected != null)
        {
            lastSelected.style.borderBottomColor = Color.black;
            lastSelected.style.borderRightColor = Color.black;
            lastSelected.style.borderTopColor = Color.black;
            lastSelected.style.borderLeftColor = Color.black;
        }
           

    }

    void tarjeta_borde_blanco(VisualElement tar)
    {

        VisualElement tarjeta = tar.Q("background");

        tarjeta.style.borderBottomColor = Color.white;
        tarjeta.style.borderRightColor = Color.white;
        tarjeta.style.borderTopColor = Color.white;
        tarjeta.style.borderLeftColor = Color.white;

        //lastSelected = tarjeta;

        Debug.Log(lastSelected);

    }


    void InitializeUI()
        {

        i2 = 0;
            for (int i = 0; i < 8; i++)
            {
                VisualTreeAsset a = Resources.Load<VisualTreeAsset>("CharacterCard"); // cambiar ruta!!!
                VisualElement b = a.Instantiate();

                // pone la imagen
                VisualElement icon = b.Q<VisualElement>("icon");
                icon.style.backgroundImage = new StyleBackground(icons[i]);

                // pone el nivel
                Label level = b.Q<Label>("value");
                level.text = datos[i].LVL.ToString();

                // pone el nombre
                Label name = b.Q<Label>("name");
                name.text = datos[i].Nombre.ToString();

                // pone el id
                Label id = b.Q<Label>("id");
                id.text = datos[i].ID.ToString();


            b.RegisterCallback<ClickEvent>(SeleccionTarjeta);

                b.AddManipulator(new Lab3Manipulator());


            switch (i2)
                {
                case 0:
                    char_select = root.Q<VisualElement>("row1");

                    break;
                case 1:
                    char_select = root.Q<VisualElement>("row2");

                    break;
                case 2:
                    char_select = root.Q<VisualElement>("row3");

                    break;

                }

                b.style.width = 100;

                // añade el objeto
                char_select.Add(b);

                if(i%3 == 2)
                {
                    i2++;
                }

                Individuo2 hola = new Individuo2("cono","a");

                Debug.Log(hola);



            //tarjetas[i] = new Tarjeta2(char_select, hola);
        }
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

