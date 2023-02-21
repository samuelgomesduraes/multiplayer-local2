using Godot;
using System;
using System.Collections.Generic;
public class networking : Node
{
	const int RPC_PORT=31400;
	const int MAX_PLAYERS=2;
	const string TESTING_IP="127.0.0.1";
	const bool OFFLINE_TESTING=false;
	
	public int net_id; //ainda nao sei o tipo dessa variavel,clique em reference pra seber onde a variavel ta sendo usada
	public bool is_host=false;
	public int[] peer_ids;

	public void inicialize_server(){
		is_host=true;
		var peer=new NetworkedMultiplayerENet();
		peer.CreateServer(RPC_PORT,MAX_PLAYERS);
		GetTree().NetworkPeer=peer;
	}
	public void inicialize_client(string server_ip){
		if(OFFLINE_TESTING){
			server_ip=TESTING_IP;
		}
		var peer=new NetworkedMultiplayerENet();
		peer.CreateClient(server_ip,RPC_PORT);
		GetTree().NetworkPeer=peer;
	}
	public void set_ids(){
		net_id=GetTree().GetNetworkUniqueId();
		peer_ids=GetTree().GetNetworkConnectedPeers();
		
	}

}
