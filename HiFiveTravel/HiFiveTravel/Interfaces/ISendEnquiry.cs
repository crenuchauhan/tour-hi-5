using HiFiveTravel.RequestModel;

namespace HiFiveTravel.Interfaces
{
    public interface ISendEnquiry
    {
        public string SendEnquiryMailToAgency(Information info);
    }
}
