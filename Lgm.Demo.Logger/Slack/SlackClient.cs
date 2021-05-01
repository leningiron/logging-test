namespace Lgm.Demo.Logger.Slack
{
    public class SlackClient : ISlackClient
    {
        public string PostMessage(string text, string channel = null)
        {
            throw new System.NotImplementedException();
        }
    }
    public interface ISlackClient
    {
        string PostMessage(string text, string channel = null);
    }
}
