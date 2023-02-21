using Godot;
using System;
using System.Collections.Generic;
public class lobby : Control
{
	networking net;
	LineEdit IP_labelj;
	public override void _Ready()
	{
		net=GetNode<networking>("/root/Net");
		GetTree().Connect("connected_to_server",this,nameof(connected));
		IP_labelj=GetNode<LineEdit>("entrar/IP");
	}
	public void connected(){
		if(! net.is_host){
			Rpc("begin_game");
			begin_game();
		}
	}
	[Remote]public void begin_game(){
		GetTree().ChangeScene("res://scenes/game.tscn");
	}

	private void _on_criar_pressed(){//host botao
		net.inicialize_server();
	}
	private void _on_entrar_pressed(){
		net.inicialize_client(IP_labelj.Text);
	}

}
