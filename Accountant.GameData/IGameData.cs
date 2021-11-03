﻿using System;
using Accountant.Enums;
using Accountant.Internal;
using Accountant.Structs;
using Dalamud.Data;
using Dalamud.Game.ClientState;
using Dalamud.Game.ClientState.Objects.SubKinds;
using Dalamud.Game.Gui;
using Dalamud.Game.Text.SeStringHandling;

namespace Accountant;

public static class GameDataFactory
{
    public static IGameData Create(GameGui gui, ClientState state, DataManager data)
        => new GameData(gui, state, data);
}

public interface IGameData : IDisposable
{
    public int Version { get; }

    // Obtain the crop data for the crop or seed with the given ID.
    // If the ID does not correspond to any crop or seed, returns item 0 with times (0, 0).
    public (CropData Data, string Name) FindCrop(uint itemId);

    // Obtain the crop data for the crop or seed with the given name or singular (case insensitive).
    // If the name does not correspond to any crop or seed, returns item 0 with times (0, 0).
    public CropData FindCrop(string name);

    // Obtain the PlotSize for a specific housing plot in a specific housing zone.
    PlotSize GetPlotSize(InternalHousingZone zone, ushort plot);

    // Obtain the name of a world for a given world id.
    public string GetWorldName(uint id);

    // Obtain the name of the homeworld for a player character.
    public string GetWorldName(PlayerCharacter player);
    // Obtain the id of a world by its name.
    public uint GetWorldId(string worldName);

    // Checks if the GameData is still valid.
    public bool Valid { get; }

    // Returns tag, name and the name of the leader of your current FC.
    // Throws InvalidOperationException if not Valid;
    public (SeString Tag, SeString? Name, SeString? Leader) FreeCompanyInfo();
}
