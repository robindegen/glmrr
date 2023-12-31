﻿using System;
using Dalamud.Game.Command;
using Glamourer.Gui;
using Glamourer.Gui.Tabs;

namespace Glamourer.Services;

public class CommandService : IDisposable
{
    private const string HelpString         = "[Copy|Apply|Save],[Name or PlaceHolder],<Name for Save>";
    private const string MainCommandString  = "/glamourer";
    private const string ApplyCommandString = "/glamour";

    private readonly CommandManager _commands;
    private readonly MainWindow     _mainWindow;

    public CommandService(CommandManager commands, MainWindow mainWindow)
    {
        _commands   = commands;
        _mainWindow = mainWindow;

        _commands.AddHandler(MainCommandString,  new CommandInfo(OnGlamourer) { HelpMessage = "Open or close the Glamourer window." });
        _commands.AddHandler(ApplyCommandString, new CommandInfo(OnGlamour) { HelpMessage   = $"Use Glamourer Functions: {HelpString}" });
    }

    public void Dispose()
    {
        _commands.RemoveHandler(MainCommandString);
        _commands.RemoveHandler(ApplyCommandString);
    }

    private void OnGlamourer(string command, string arguments)
        => _mainWindow.Toggle();

    private void OnGlamour(string command, string arguments)
    { }
}
