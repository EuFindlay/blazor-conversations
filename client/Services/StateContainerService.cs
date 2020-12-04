using System;
using client.Models;

namespace client.Services
{
    public class StateContainerService
    {
        public ClientState Property { get; set; }
        public event Action OnChange;

        public void SetProperty(ClientState value)
        {
            Property = value;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

    }
}