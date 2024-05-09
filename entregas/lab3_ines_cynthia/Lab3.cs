using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Lab3 : MonoBehaviour
{
    private void OnEnable()
    {
        //partOne();
        parteDos();
    }


    private void partOne()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        VisualElement bases = root.Q("base");
        VisualElement options = root.Q("options");
        VisualElement attr = root.Q("Attributes");

        bases.RegisterCallback<MouseDownEvent>(
            ev =>
            {
                Debug.Log("BASE " + ev.propagationPhase);



            }, TrickleDown.NoTrickleDown);

        options.RegisterCallback<MouseDownEvent>(
           ev =>
           {
               Debug.Log("OPTIONS " + ev.propagationPhase);

           }, TrickleDown.NoTrickleDown);

        attr.RegisterCallback<MouseDownEvent>(
            ev =>
            {
                Debug.Log("ATRIBUTOS " + ev.propagationPhase);

                (ev.target as VisualElement).style.backgroundColor = Color.blue;

            }, TrickleDown.TrickleDown);

    }


    private void parteDos()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        UQueryBuilder<VisualElement> builder = new(root);

        List<VisualElement> contenedor = builder.Name("artif").ToList();

        contenedor.ForEach(a => {
            a.AddManipulator(new Lab3Manipulator());
            a.AddManipulator(new ExampleResizer());
        });
    }
}


