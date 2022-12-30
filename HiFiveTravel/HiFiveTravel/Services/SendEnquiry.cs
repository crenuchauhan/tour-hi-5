using HiFiveTravel.Interfaces;
using HiFiveTravel.RequestModel;

namespace HiFiveTravel.Services
{
    public class SendEnquiry : ISendEnquiry
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private readonly IMailSend _mailSend;
        private readonly ILogError _logError;
        public SendEnquiry(IMailSend mailSend,ILogError logErr, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _env = webHostEnvironment;
            _mailSend = mailSend;
            _logError = logErr;
        }
        public string SendEnquiryMailToAgency(Information info)
        {
            try
            {
                string OpeningMessage = "";
                if(info.EnquiryFor=="Home")
                {
                    OpeningMessage = "General Enqiury";
                }
                string email_msg = "This is " + OpeningMessage + " <br><br>" +
                        "Name :" + info.Name + " <br><br> Email :" + info.Email + "<br><br> Mobile Number : " + info.MobileNumber +
                        "<br><br> Country :" + info.Country + "<br><br> Arrival Date :" + info.ArrivalDate + "<br><br> No. of Nights :" + info.NoOfNights +
                        "<br><br> No. of Persons :" + info.NoOfPersons + "<br><br> Children :" + info.Children+ "<br><br> Destination :" +info.Destination+
                        "<br><br> Thanks .";
                     

                    bool ResEmail = this._mailSend.Sendmail( email_msg, OpeningMessage);


                    if (ResEmail)
                    {
                        return "success";
                    }

                return "failed";
            }
            catch (Exception ex)
            {
                this._logError.LogErrorFile(ex, _env);
                return ex.Message;

            }
        }
    }
}
