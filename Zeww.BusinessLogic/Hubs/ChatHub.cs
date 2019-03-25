using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Zeww.Repository;

namespace Zeww.Hubs
{
    public class ChatHub : Hub
    {
        private IUnitOfWork _unitOfWork;
        public ChatHub(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public void OnWorkspaceConnect(int userID , int WorkspaceID)
        {
            // Retrieve user.
            //use Context.User.Identity.Name to get logged in user
            // string name = Context.GetHttpContext().Request.Query["name"];
            var userChatIds = _unitOfWork.Users.GetChatsIdsByUserId(userID);
            foreach (var userChat in userChatIds)
            {
                Groups.AddToGroupAsync(Context.ConnectionId, userChat.ToString());
            }
        }






        public async Task sendToAll(string user, string roomName, string message)
        {
            //Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            await Clients.Groups(roomName).SendAsync("sendToAll", user, message);
            //await Clients.All.SendAsync("sendToAll", user, message);
        }
        //this should be replaced by an axious ajax call
        public string retrieveUserName(int userID)
        {
            return "Hassan";
        }

        //this should be replaced by an axious ajax call
        public string retrieveRoomName(int roomID)
        {
            return "Hassan";
        }
        public async Task joinChannel(string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }
        public Task LeaveChannel(string roomName)
        {
            Clients.Groups(roomName).SendAsync("sendToAll", "someone Left the room");
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }
    }
}