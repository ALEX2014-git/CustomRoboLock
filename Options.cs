using BepInEx.Logging;
using Menu.Remix.MixedUI;
using Menu.Remix.MixedUI.ValueTypes;
using UnityEngine;

namespace CustomRoboLock;

public class PluginOptions : OptionInterface
{
    private readonly ManualLogSource Logger;

    public PluginOptions(CustomRoboLock modInstance, ManualLogSource loggerSource)
    {
        Logger = loggerSource;
        ShouldLog = this.config.Bind<bool>("ShouldLog", true);
        PacifyPebbles = this.config.Bind<bool>("PacifyPebbles", true);
        UseParser = this.config.Bind<bool>("UseParser", true);
    }

    public readonly Configurable<bool> ShouldLog;
    public readonly Configurable<bool> PacifyPebbles;
    public readonly Configurable<bool> UseParser;
    private UIelement[] UIArrGeneral;
    private UIelement[] UIArrDebug;


    public override void Initialize()
    {
        base.Initialize();
        var opTab = new OpTab(this, "Options");
        var opTab2 = new OpTab(this, "Debug");
        this.Tabs = new[]
        {
            opTab,
            opTab2
        };

        UIArrGeneral = new UIelement[]
        {
            new OpLabel(10f, 550f, "Options", true),
            new OpLabel(10f, 520f, "Enable logging to console?"),
            new OpCheckBox(ShouldLog, 10f, 490f),

            new OpLabel(10f, 480f, "Pacify Five Pebbles while in posession of the drone"),
            new OpCheckBox(PacifyPebbles, 10f, 470f),
        };

        UIArrDebug = new UIelement[]
        {
            new OpLabel(10f, 550f, "Debug", true),
            new OpLabel(10f, 520f, "Should mod use it's custom parser?"),
            new OpCheckBox(UseParser, 10f, 490f),
        };
        opTab.AddItems(UIArrGeneral);
        opTab2.AddItems(UIArrDebug);
    }

    public override void Update()
    {
        //UIArrDebug[2].;
    }

}