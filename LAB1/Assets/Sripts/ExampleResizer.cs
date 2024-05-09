using System;
using UnityEngine;
using UnityEngine.UIElements;

public class ExampleResizer : PointerManipulator
{

    private Vector3 m_Start;
    protected bool m_Active;
    private int m_PointerId;

    private Vector2 m_StartSize;

    public ExampleResizer()
    {
        Debug.Log("Constructora Resizer");
        m_PointerId = -1;
        activators.Add(new ManipulatorActivationFilter { button = MouseButton.LeftMouse });
        m_Active = false;
    }

    protected override void RegisterCallbacksOnTarget()
    {
        Debug.Log("RegisterCallbacks");
        //target.RegisterCallback<PointerDownEvent>(OnPointerDown);
        //target.RegisterCallback<PointerUpEvent>(OnPointerUp);
        //target.RegisterCallback<PointerMoveEvent>(OnPointerMove);

        target.RegisterCallback<WheelEvent>(WheelEvent);
        target.RegisterCallback<PointerEnterEvent>(OnPointerEnter);
    }

    private void OnPointerEnter(PointerEnterEvent e)
    {
        Debug.Log("........ENTER........");

        if (m_Active)
        {
            e.StopImmediatePropagation();
            return;
        }

        if (CanStartManipulation(e))
        {
           // ¿?¿¡
        }

        m_Start = e.localPosition;
        m_StartSize = target.layout.size;
        m_PointerId = e.pointerId;
        m_Active = true;
        //target.CapturePointer(m_PointerId);

        target.CaptureMouse();
        e.StopPropagation();
    }



    protected override void UnregisterCallbacksFromTarget()
    {
        Debug.Log("UnRegisterCallbacks");
        target.UnregisterCallback<PointerDownEvent>(OnPointerDown);
        target.UnregisterCallback<PointerUpEvent>(OnPointerUp);
        target.UnregisterCallback<PointerMoveEvent>(OnPointerMove);
    }


    protected void OnPointerDown(PointerDownEvent e)
    {
        Debug.Log("OnPointerDown");

        if (m_Active)
        {
            e.StopImmediatePropagation();
            return;
        }

        if (CanStartManipulation(e))
        {
            m_Start = e.localPosition;
            m_StartSize = target.layout.size;
            m_PointerId = e.pointerId;
            m_Active = true;
            target.CapturePointer(m_PointerId);
            e.StopPropagation();
        }

    }

    protected void OnPointerMove(PointerMoveEvent e)
    {
        Debug.Log("OnPointerMove");

        if (!m_Active || !target.HasPointerCapture(m_PointerId))
        {
            return;
        }

        Vector2 diff = e.localPosition - m_Start;


        target.style.height = m_StartSize.y - diff.y;
        target.style.width = m_StartSize.x - diff.x;


        e.StopPropagation();

    }

    protected void WheelEvent(WheelEvent e)
    {

        if (m_Active || !target.HasMouseCapture())
        {
            return;
        }

        Debug.Log("SOLARRRRRRRRRRRRRRRRRRRR");

        Vector2 diff;

        diff.x = e.localMousePosition.x - m_Start.x;
        diff.y = e.localMousePosition.y - m_Start.y;


        target.style.height = m_StartSize.y - diff.y;
        target.style.width = m_StartSize.x - diff.x;


        e.StopPropagation();
    }
    protected void OnPointerUp(PointerUpEvent e)
    {
        Debug.Log("OnPointerUp");

        if (!m_Active || !target.HasPointerCapture(m_PointerId))
        {
            return;
        }

        m_Active = false;
        target.ReleasePointer(m_PointerId);
        m_PointerId = -1;
        e.StopPropagation();
    }



}
