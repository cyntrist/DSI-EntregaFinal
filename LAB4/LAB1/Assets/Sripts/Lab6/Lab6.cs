using Lab5b_namespace;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using System.Globalization;
using Unity.VisualScripting;



namespace lab6_namespace
{

    public class Lab6 : MonoBehaviour
    {

        VisualElement botonCrear;
        Toggle toggleModificador;
        VisualElement contenedor_izq;
        VisualElement contenedor_elems;
        TextField input_nombre;
        TextField input_element;
        String elem_route;
        VisualElement input_icon;
        Individuo individuoSelec;

        List<Individuo> list_individuos = new List<Individuo>();

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            contenedor_izq = root.Q<VisualElement>("izq");
            contenedor_elems = root.Q<VisualElement>("cont_elems");
            input_nombre = root.Q<TextField>("input_name");
            input_element = root.Q<TextField>("input_element");
            botonCrear = root.Q<Button>("create");
            toggleModificador = root.Q<Toggle>("modify");
            input_icon = null;

            contenedor_izq.RegisterCallback<ClickEvent>(SeleccionTarjeta);
            contenedor_elems.RegisterCallback<ClickEvent>(seleccionElemento);
            botonCrear.RegisterCallback<ClickEvent>(NuevaTarjeta);
            input_nombre.RegisterCallback<ChangeEvent<string>>(CambioNombre);
            input_element.RegisterCallback<ChangeEvent<string>>(CambioElemento);

        }


        void SeleccionTarjeta(ClickEvent evt)
        {
            VisualElement tarjeta = evt.target as VisualElement;

            Label name = tarjeta.Q<Label>("name");
            Label el = tarjeta.Q<Label>("element");

            //individuoSelec = tarjeta.userData as Individuo;
            tarjeta_borde_negro();
            tarjeta_borde_blanco(tarjeta);

            input_nombre.SetValueWithoutNotify(name.text);
            input_element.SetValueWithoutNotify(el.text);
            VisualElement a = tarjeta.Q<VisualElement>("icon");

            Debug.Log("tarjeta");

            a.style.backgroundImage = input_icon.style.backgroundImage;
            //Sprite icon = Resources.Load<Sprite>(elem_route);
            //a.style.backgroundImage = new StyleBackground(icon);

            // recoger la ruta por posicion (locura)


            toggleModificador.value = true;
        }

        void seleccionElemento(ClickEvent evt)
        {
            VisualElement element = evt.target as VisualElement;



            //individuoSelec = tarjeta.userData as Individuo;
            elem_borde_negro();
            elem_borde_blanco(element);

            //switch (element.name)
            //{
            //    case "elem1":
            //        elem_route = "electro";

            //        break;
            //    case "elem2":
            //        elem_route = "anemo";

            //        break;
            //    case "elem3":
            //        elem_route = "hydro";

            //        break;
            //    case "elem4":
            //        elem_route = "pyro";

            //        break;
            //}

            input_icon = element;

            Debug.Log("element select");
        }

        void NuevaTarjeta(ClickEvent evt)
        {

            if (!toggleModificador.value)
            {
                VisualTreeAsset p = Resources.Load<VisualTreeAsset>("ElementTemplate");
                VisualElement t = p.Instantiate();

                contenedor_izq.Add(t);
                tarjeta_borde_negro();
                tarjeta_borde_blanco(t);


                Individuo i = new Individuo(input_nombre.value, input_element.value);
                VisualElement a = t.Q<VisualElement>("icon");
                a.style.backgroundImage = input_icon.style.backgroundImage;
                Tarjeta tr = new Tarjeta(t, i);

                individuoSelec = i;

                list_individuos.Add(i);
                //list_individuos.ForEach(elem => {
                //    Debug.Log(elem.Nombre + " " + elem.Element);
                //    string jsonIndividuo = JsonUtility.ToJson(elem);
                //    Debug.Log(jsonIndividuo);


                //});
                string listaToJson = JsonHelperIndividuo.ToJson(list_individuos, true);
                Debug.Log(listaToJson);


            }

        }

        void guardar(ClickEvent evt)
        {


        }

        void tarjeta_borde_negro()
        {
            List<VisualElement> list_t = contenedor_izq.Children().ToList();
            list_t.ForEach(elem =>
            {
                Debug.Log(elem);

                VisualElement tarjeta = elem.Q("tarjeta");

                Debug.Log(tarjeta.name);


                tarjeta.style.borderBottomColor = Color.black;
                tarjeta.style.borderRightColor = Color.black;
                tarjeta.style.borderTopColor = Color.black;
                tarjeta.style.borderLeftColor = Color.black;


            });
        }


        void tarjeta_borde_blanco(VisualElement tar)
        {

            VisualElement tarjeta = tar.Q("tarjeta");

            tarjeta.style.borderBottomColor = Color.white;
            tarjeta.style.borderRightColor = Color.white;
            tarjeta.style.borderTopColor = Color.white;
            tarjeta.style.borderLeftColor = Color.white;

        }

        void elem_borde_negro()
        {
            List<VisualElement> list_t = contenedor_elems.Children().ToList();
            list_t.ForEach(elem =>
            {

                VisualElement tarjeta = elem.Q("elem");


                tarjeta.style.borderBottomColor = Color.black;
                tarjeta.style.borderRightColor = Color.black;
                tarjeta.style.borderTopColor = Color.black;
                tarjeta.style.borderLeftColor = Color.black;


            });
        }

        void elem_borde_blanco(VisualElement tar)
        {

            VisualElement tarjeta = tar.Q("elem");

            tarjeta.style.borderBottomColor = Color.white;
            tarjeta.style.borderRightColor = Color.white;
            tarjeta.style.borderTopColor = Color.white;
            tarjeta.style.borderLeftColor = Color.white;

        }

        void CambioNombre(ChangeEvent<string> evt)
        {
            if (!toggleModificador.value)
            {
                individuoSelec.Nombre = evt.newValue;
            }
        }





        void CambioElemento(ChangeEvent<string> evt)
        {
            if (!toggleModificador.value)
            {
                individuoSelec.Element = evt.newValue;
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



    public static class JsonHelperIndividuo {
    
        public static List<Individuo> FromJson<Individuo>(string json)
        {
            ListaIndividuo<Individuo> listaInd = JsonUtility.FromJson<ListaIndividuo<Individuo>>(json);
            return listaInd.individuos; 
        }

        public static String ToJson(List<Individuo> lista)
        {
            ListaIndividuo<Individuo> listaInd = new ListaIndividuo<Individuo>();
            listaInd.individuos = lista;

            return JsonUtility.ToJson(listaInd);
        }

        public static string ToJson<Individuo>(List<Individuo> lista, bool pretty)
        {
            ListaIndividuo<Individuo> list = new ListaIndividuo<Individuo>();
            list.individuos = lista;
            return JsonUtility.ToJson(list, pretty);
        }


        [Serializable]
        private class  ListaIndividuo<Individuo>
        {
            public List<Individuo> individuos;
        }
    }
}