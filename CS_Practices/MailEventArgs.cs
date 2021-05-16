using   System;

namespace CS_Practices
{
    public class MailEventArgs:EventArgs
    {
        public string From { get; }
        public string To { get; }
        public string Subject { get; }

        public MailEventArgs(string from, string to, string subjet)
        {
            From = from;
            Subject = subjet;
            To = to;
        }

        public override string ToString()
        {
            return " ";
        }
    }
}