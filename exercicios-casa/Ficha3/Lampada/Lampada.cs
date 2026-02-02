using System;

namespace Lampada;

public class Lampada
{
    private bool isOn;
    

    public Lampada()
    {
        isOn = false;
    }

    public void TurnOn()
    {
        isOn = true;
    }

    public void TurnOff()
    {
        isOn = false;
    }

    public bool IsOn()
    {
        return isOn;
    }
}
