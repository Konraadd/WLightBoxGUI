namespace BleBox_wlightbox_sampleAPI;
public class DurationsMs
{
    public int colorFade { get; set; }
    public int effectFade { get; set; }
    public int effectStep { get; set; }
}

public class Rgbw
{
    public int colorMode { get; set; }
    public int effectID { get; set; }
    public string desiredColor { get; set; }
    public string currentColor { get; set; }
    public string lastOnColor { get; set; }
    public DurationsMs durationsMs { get; set; }
}

public class RgbwState
{
    public Rgbw rgbw { get; set; }
}

