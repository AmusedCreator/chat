using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace wcf_chat
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
        List<ServerUser> users = new List<ServerUser>();
        int nextId = 1;

        public int Connect(string name)
        {
            string message;
            ServerUser user = new ServerUser()
            {
                ID = nextId,
                Name = name,
                operationContext = OperationContext.Current
            };
            nextId++;

            SendMsg("| <" + user.Name + ">" + " connected", 0);

            users.Add(user);


            using (FileStream fs = new FileStream("logs.txt", FileMode.Append, FileAccess.Write))
            {
                byte[] logmsg = Encoding.Default.GetBytes("|" + DateTime.Now.ToShortTimeString() +
                                                          "| <" + user.Name + ">" + " CONNECTED" + "\n");
                fs.Write(logmsg, 0, logmsg.Length);
            }

            return user.ID;
        }

        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(i => i.ID == id);
            if (user != null)
            {
                users.Remove(user);

                SendMsg("| <" + user.Name + ">" + " disconnected", 0);

                using (FileStream fs = new FileStream("logs.txt", FileMode.Append, FileAccess.Write))
                {
                    byte[] logmsg = Encoding.Default.GetBytes("|" + DateTime.Now.ToShortTimeString() +
                                                              "| <" + user.Name + ">" + " DISCONNECTED" + "\n");
                    fs.Write(logmsg, 0, logmsg.Length);
                }
            }
        }

        public void SendMsg(string msg, int id)
        {
            foreach (var item in users)
            {
                string answer = "|" + DateTime.Now.ToShortTimeString();

                var user = users.FirstOrDefault(i => i.ID == id);
                if (user != null)
                {
                    answer += "| <" + user.Name + ">" + " ";
                }

                answer += msg;

                using (FileStream fs = new FileStream("logs.txt", FileMode.Append, FileAccess.Write))
                {
                    byte[] logmsg = Encoding.Default.GetBytes(answer + "\n");
                    fs.Write(logmsg, 0, logmsg.Length);
                }

                item.operationContext.GetCallbackChannel<IServerChatCallback>().MsgCallback(answer);
            }
        }
    }
}