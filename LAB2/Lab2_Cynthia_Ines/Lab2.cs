using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Lab2 : MonoBehaviour
{
    private void OnEnable()
    {
        UIDocument uidoc = GetComponent<UIDocument>();
        VisualElement rootve = uidoc.rootVisualElement;

        UQueryBuilder<VisualElement> builder = new(rootve);
        VisualElement cont = builder.Name("info");
        //List<VisualElement> list_ve = cont.Children().ToList();
        List<VisualElement> list_ve = rootve.Query(className: "weirdButton").ToList();
        //VisualElement vis = rootve.Query<Button>().AtIndex(1);

        VisualElement ve = rootve.Query(className: "weirdButton").First();
        ve.AddToClassList("normalButton");

        VisualElement ve2 = cont.Query<Button>(className: "weirdButton").First();
        ve2.AddToClassList("normalButton");


        list_ve.ForEach(e =>
        {
            Debug.Log(e.name);
            e.AddToClassList("normalButton");
        });



        // SLIDER

        VisualElement cunty = rootve.Q<Slider>("cuntiness");
        Debug.Log(cunty.name);
        cunty.style.backgroundColor = Color.red;

        VisualElement cunty2 = rootve.Q<VisualElement>("unity-dragger");
        Debug.Log(cunty2.name);
        cunty2.style.backgroundColor = Color.red;

        VisualElement cunty3 = rootve.Q<VisualElement>("unity-tracker");
        Debug.Log(cunty3.name);
        cunty3.style.backgroundColor = Color.red;



    }
}
