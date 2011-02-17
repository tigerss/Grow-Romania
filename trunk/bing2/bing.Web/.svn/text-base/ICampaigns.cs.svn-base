using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace bing.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICampaigns" in both code and config file together.
    [ServiceContract]
    public interface ICampaigns
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        List<Real> SelectCampaigns();
        [OperationContract]
        Real SelectCampanieById(int id);
        [OperationContract]
        List<ComentariiDetaliat> SelectComentarii(int campanie_id);
        [OperationContract]
        void InsertComment(string text, int FK_real, int FK_user);
        [OperationContract]
        List<DonatiiDetalii> SelectDonationsByUserId(int id);
        [OperationContract]
        List<ComentariiDonatiiType> SelectDonatiiComentariiByDonatie(int id);
        [OperationContract]
        void InsertCommentDonations(string text, int FK_donatie, int FK_user);
    }
}
