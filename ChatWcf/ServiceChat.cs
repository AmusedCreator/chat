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

        //метод для получения списка подключенных пользователей
        public string[] GetUsers()
        {
            string[] usersList = new string[users.Count];
            for (int i = 0; i < users.Count; i++)
            {
                usersList[i] = users[i].Name;
            }

            return usersList;
        }

        public void PlayHangman()
        {
            foreach (var item in users)
            {
                string word;
                char guessLetter = '0';
                string guessedWord = "";
                int guesses = 10;
                bool finded = false;
                string answer = "";

                Random rand = new Random();
                string[] allWords = File.ReadAllLines("words.txt", Encoding.UTF8);
                word = allWords[rand.Next(allWords.Length)];
                //word = "щебень";
                
                for (int i = 0; i < word.Length; i++)
                {
                    guessedWord += "_";
                }

                answer = "|" + DateTime.Now.ToShortTimeString() + "| <Console> Вы решили сыграть в виселицу";
                item.operationContext.GetCallbackChannel<IServerChatCallback>().MsgCallback(answer);
                answer = "|" + DateTime.Now.ToShortTimeString() + "| <Console> У вас будет " + guesses + " попыток чтобы отгадать загаданное компьютером слово";
                item.operationContext.GetCallbackChannel<IServerChatCallback>().MsgCallback(answer);
                answer = "|" + DateTime.Now.ToShortTimeString() + "| <Console> Загаданное слово: " + guessedWord;
                item.operationContext.GetCallbackChannel<IServerChatCallback>().MsgCallback(answer);

                while (guesses > 0 && guessedWord.Contains("_"))
                {
                    while (guessLetter == '0')
                    {
                        //if (последняя строка в чате.length == 1) 
                        //    guessLetter = следующая строка в чате;
                        //else answer = "|" + DateTime.Now.ToShortTimeString() + "| <Console> " + "Пожалуйста, " +
                        //"Введите один символ\n"
                        //item.operationContext.GetCallbackChannel<IServerChatCallback>().MsgCallback(answer);
                        
                        /*string s = File.ReadAllLines("logs.txt").Last();
                        int pos = s.LastIndexOf('>');
                        s = s.Substring(pos);
                        s = s.Remove(0, 2);
                        if(s.Length == 1 && s[0] > 'а' && s[0] < 'я')
                        {
                            guessLetter = s[0];
                        }*/
                        
                        guessLetter = (char)rand.Next('а', 'я' + 1);
                    }
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i].Equals(guessLetter))
                        {
                            char[] charGuessedWord = guessedWord.ToCharArray();
                            charGuessedWord[i] = guessLetter;
                            guessedWord = new string(charGuessedWord);
                            finded = true;
                        }
                    }
                    guesses--;

                    if (finded) answer = "|" + DateTime.Now.ToShortTimeString() + "| <Console> Вы угадали букву! Загаданное слово: " + guessedWord + ";  Осталось попыток: " + guesses;
                    else answer = "|" + DateTime.Now.ToShortTimeString() + "| <Console> Увы, вы ошиблись. Загаданное слово: " + guessedWord + ";  Осталось попыток: " + guesses;
                    item.operationContext.GetCallbackChannel<IServerChatCallback>().MsgCallback(answer);

                    finded = false;
                    guessLetter = '0';
                }
                
                if (!guessedWord.Contains("_"))
                    answer = "|" + DateTime.Now.ToShortTimeString() + "| <Console> Вы угадали слово " +
                    guessedWord + " за " + guesses + " попыток";
                else answer = "|" + DateTime.Now.ToShortTimeString() + "| <Console> Увы, вы не угадали слово." +
                    " Загаданное слово: " + word;

                item.operationContext.GetCallbackChannel<IServerChatCallback>().MsgCallback(answer);
            }
        }
    }
}