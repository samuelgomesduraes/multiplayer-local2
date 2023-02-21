using Godot;
using System;
using System.Collections.Generic;
public class game : Node2D
{
    networking net;
    player jogador;
    public override void _Ready()
    {
        net=GetNode<networking>("/root/Net");
        jogador=GetNode<player>("/root/Player");
       
        net.set_ids();
        create_players();
    }
public void create_players(){
    for (int i = 0; i < net.peer_ids.Length; i++)// aui tem de ser feito um for i in net.peer_ids
    {
        //create_player(id);
    }
    create_player(net.net_id);
}
public void create_player(int id){
   var player=ResourceLoader.Load<PackedScene>("res://scenes/player.tscn").Instance<KinematicBody2D>();
    AddChild(player);
    jogador.initialize(id);
}
}
