namespace client.Models
{
    public class ClientState
    {
        public string Name {get;set;}
        public bool LoggedIn {get;set;}
        public string Token {get;set;}
        public bool ConversationsReady {get;set;}
        public object[] Messages {get;set;}
        public string NewMessage {get;set;}
        public object[] Conversations {get;set;}
    }
}