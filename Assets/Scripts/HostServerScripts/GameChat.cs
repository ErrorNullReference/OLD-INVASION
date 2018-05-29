using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using Steamworks;
using System;

public class GameChat : MonoBehaviour
{
    void Start()
    {
        Client.AddCommand(PacketType.Chat, Receive);
        Client.AddCommand(PacketType.Serverchat, ServerReceive);
    }

    void Send(string message)
    {
        byte[] data = Encoding.UTF8.GetBytes(message);
        Client.SendPacketToHost(data, PacketType.Serverchat, EP2PSend.k_EP2PSendReliable);
    }

    //This method will be called if a message is received from a user of the lobby. The message will be sent to all users
    void ServerReceive(byte[] data, uint dataLength, CSteamID senderID)
    {
        Client.SendPacketToLobby(data, PacketType.Chat, senderID, EP2PSend.k_EP2PSendReliable, true);
    }

    //This method will be called if a message is received from the server
    void Receive(byte[] data, uint dataLength, CSteamID senderID)
    {
        string message = Encoding.UTF8.GetString(data);
        string uername = Client.Lobby.GetUserFromID(senderID).SteamUsername;

        //Call method to show message on screen. Yuo can acces the message received and the steam username of the sender.
    }
}
