using UnityEngine;
using System.Collections;
using System;
namespace Fardin.ColorTools
{
public class ColorTerminal : MonoBehaviour {

    public ColorForm colorForm;
    OnChangeColorHandler changeColorHandler;
    public event EventHandler<OnChangeColorHandler> changedColor;
    public Color starterColor = Color.yellow;

    [SerializeField]
    ColorPick colorPick;
    public void SetColorForm(Color color)
    {
        FillColorForm.ByRGBA(color, colorForm);
    }
    void Start()
    {
        colorForm.Initialize(starterColor);
        changeColorHandler = new OnChangeColorHandler();
        changeColorHandler.form = colorForm;
        colorPick.OnPickColor += OnPickColorChange;
    }

    void FixedUpdate()
    {
        if (colorForm.IsChanged)
        {
            changedColor(this, changeColorHandler);
            colorForm.IsChanged = false;
        }
    }

    void OnPickColorChange(object o, OnPickColorHandler e)
    {
        FillColorForm.ByRGBA(e.color, colorForm);
    }
	
	/// Check if "ColorTerminal.changedColor" contains current eventhandler method
    public bool methodRegistered(EventHandler<OnChangeColorHandler> method)
    {
        if (changedColor == null)
            return false;
        Delegate[] invocationList = changedColor.GetInvocationList();
        for (int i = invocationList.Length-1; i >=0; i--)
        {
            if (invocationList[i].Equals(method))
            {
                return true;
            }
        }
        return false;
    }
}

public class OnChangeColorHandler : EventArgs
{
    public ColorForm form;
}

}