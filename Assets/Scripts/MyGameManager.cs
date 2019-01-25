using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//游戏管理器
namespace Prototype.NetworkLobby
{
public class MyGameManager {
        private Dictionary<GameObject, LobbyPlayer> mDatas;
        private static MyGameManager instance;
	public static MyGameManager Instance{
		get{
			if(instance == null){
				instance = new MyGameManager();
			}
			return instance;
		}
	}
	private MyGameManager(){
		mDatas = new Dictionary<GameObject,LobbyPlayer> ();
	}
	//添加player数据
	public void addPlayerData(GameObject gamePlayer, LobbyPlayer lobbyPlayer){
		mDatas.Add(gamePlayer,lobbyPlayer);
	}
	//得到lobby中的数据
	public LobbyPlayer GetLobbyPlayer(GameObject gamePlayer){
		return mDatas[gamePlayer];
	}
}
}
