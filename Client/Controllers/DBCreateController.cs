using QuickChat.Shared.Services;
using QuickChat.Shared.Data;
using QuickChat.Shared.Entities;
using QuickChat.Shared.Data.InitDataFactory;

namespace QuickChat.Client.Controllers
{
    public static class DBCreateController
    {
        private static QuickChatDbContext context = new QuickChatDbFactory(new TestDataFactory()).CreateContext();
        public static QuickChatDbContext Context
        {
            get { return context; }
        }
        public static void Start() {}

    }
}
