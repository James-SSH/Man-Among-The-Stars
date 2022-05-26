using Godot;
using System;

public class QuitGame : Button {
    
    public override void _Ready(){
        GetTree().SetAutoAcceptQuit(true); 
    }
    
    private void _on_Quit_pressed() {
        GetTree().Notification(MainLoop.NotificationWmQuitRequest);
    }
}
