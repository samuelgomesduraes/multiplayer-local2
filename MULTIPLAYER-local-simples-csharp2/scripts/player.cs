using Godot;
using System;
using System.Collections.Generic;
public class player : KinematicBody2D
{
    networking net;
    const int SPEED=350;
    bool is_master=false;
    public override void _Ready()
    {
        net=GetNode<networking>("/root/Net");
    }
    public void initialize(int id){
        Name=id.ToString();
        if(id == net.net_id){
            is_master=true;
        }
        else
        {
         Modulate=Color.Color8(255,0,0,255) ; 
        }
    }
    public override void _Process(float delta){
        if(is_master){
                Vector2 velocity=new Vector2(0,0);
            if(Input.IsActionPressed("ui_right")){
                velocity.x=SPEED;
            }
            else if(Input.IsActionPressed("ui_left")){
                velocity.x=-SPEED;
            }else{
                velocity.x=0;
            }
            if(Input.IsActionPressed("ui_down")){
                velocity.y=SPEED;
            }
            else if(Input.IsActionPressed("ui_up")){
                velocity.y=-SPEED;
            }else{
                velocity.y=0;
            }
            MoveAndSlide(velocity);
            RpcUnreliable("update_position",Position);
        }
    }
[Remote]public void update_position(Vector2 pos){
    Position=pos;
}

}