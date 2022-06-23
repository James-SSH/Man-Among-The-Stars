using Godot;
using System;

public class Quit : TextureButton
{
    public override void _Ready() {
        GetTree().SetAutoAcceptQuit(true);
    }
    private void _on_Quit_pressed(){
        GetTree().Notification(MainLoop.NotificationWmQuitRequest);
    }


}
