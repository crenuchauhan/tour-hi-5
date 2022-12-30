namespace HiFiveTravel.Interfaces
{
    public interface IMailSend
    {
        public bool Sendmail(string messsg, string subjectofmail);
    }
}
