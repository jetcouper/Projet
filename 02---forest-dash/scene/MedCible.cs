using System;
using System.Linq;
using Godot;
using Utils;

public partial class MedCible : Node2D
{
    [ExportGroup("External")]
    [Export]
    private DcmSpawner SpawnerSouris;

    [Export]
    private DCM_PlayerSwitch DPMChat;

    [Export]
    private DcmSpawner SpawnerChien;

    public enum EAlgoSelectionCible
    {
        eChatActif,
        eChatLePlusProche,
        eSourisPlusProche,
        eMax,
    }

    public Node2D ChoisirCible(EAlgoSelectionCible InAlgoSelectionCible, Vector2 Inposition)
    {
        Node2D ret = null;
        switch (InAlgoSelectionCible)
        {
            case EAlgoSelectionCible.eChatActif: { }
                break;
            case EAlgoSelectionCible.eChatLePlusProche: { }
                break;
            default:
            case EAlgoSelectionCible.eSourisPlusProche:
                {
                    ret = SpawnerSouris
                        .EnsureValid()
                        .GatherChildren()
                        .OfType<Souris>()
                        .FirstOrDefault<Souris>();
                    //Plus le temps première souris disponible SVP.
                }
                break;
        }
        return ret;
    }
}
