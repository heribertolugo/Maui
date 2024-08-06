namespace Hl.Maui.Controls.Helpers;

internal class ColorTransition
{
    private float _redRate, _greenRate, _blueRate;
    private byte _oldColorR, _oldColorG, _oldColorB;
    public ColorTransition(Color from, Color to, uint rate)
    {
        From = Current = from;
        To = to;
        Rate = rate;
        SetRatesOfChange(from, to, rate);
    }

    public Color GetNext(double v)
    {
        Current = Color.FromRgb(
            (byte)Math.Min(Math.Max(_oldColorR + v * _redRate, 0), 255),
            (byte)Math.Min(Math.Max(_oldColorG + v * _greenRate, 0), 255),
            (byte)Math.Min(Math.Max(_oldColorB + v * _blueRate, 0), 255));
        return Current;
    }

    private void SetRatesOfChange(Color from, Color to, uint rate)
    {
        byte newColorR, newColorG, newColorB;
        to.ToRgb(out newColorR, out newColorG, out newColorB);
        from.ToRgb(out _oldColorR, out _oldColorG, out _oldColorB);

        _redRate = _oldColorR == newColorR ? newColorR / rate : (newColorR - _oldColorR) / rate;
        _greenRate = _oldColorG == newColorG ? newColorG / rate : (newColorG - _oldColorG) / rate;
        _blueRate = _oldColorB == newColorB ? newColorB / rate : (newColorB - _oldColorB) / rate;
    }

    public Color From { get; init; }
    public Color To { get; init; }
    public uint Rate { get; init; }
    public Color Current { get; set; }
}