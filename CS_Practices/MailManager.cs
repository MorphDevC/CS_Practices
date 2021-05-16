using System;
namespace CS_Practices
{
    public class MailManager
    {
        public event EventHandler<MailEventArgs> NewMail;

        protected virtual void OnMail(object e)
        {
            if (e is MailEventArgs)
            {
                _ = e ?? throw new ArgumentNullException(nameof(e));
                NewMail?.Invoke(this,(MailEventArgs)e);   
            }
        }

        public void SimulateNewMail(string from, string to, string subject)
        {
            var e = new MailEventArgs(from, to, subject);
            OnMail(e);
        }
    }
}