using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace bing.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Campaigns" in code, svc and config file together.
    public class Campaigns : ICampaigns
    {
        public void DoWork()
        {
        }
        public List<Real> SelectCampaigns()
        {
            List<Real> c = new List<Real>();
            dbEntities context = new dbEntities();
            var camp = from r in context.Reals
                    select r;
            foreach (Real campanie in camp)
            {
                c.Add(campanie);
            }
            return c;
        }
        public Real SelectCampanieById(int id)//nu o folosesc inca
        {
            dbEntities context = new dbEntities();
            var campanie = (from r in context.Reals
                       where r.ID==id
                       select r).First();
            Real Campaign = campanie;
            return Campaign;
        }
        public List<ComentariiDetaliat> SelectComentarii(int campanie_id)
        {
            dbEntities context = new dbEntities();
            List<ComentariiDetaliat> L = new List<ComentariiDetaliat>();
            foreach (ComentariiDetaliat comment in context.SelectComentariiFct(campanie_id))
            {
                L.Add(comment);   
            }
            return L;
        }
        public void InsertComment(string text,int FK_real,int FK_user)
        {
            dbEntities context = new dbEntities();
            ComentariiReal Comment = new ComentariiReal();
            Comment.TextCampanie = text;
            Comment.FK_Real = FK_real;
            Comment.FK_User = FK_user;
            Comment.Data = DateTime.Now;
            context.ComentariiReals.AddObject(Comment);
           // ComentariiReal.CreateComentariiReal(id, text, FK_real, FK_user, DateTime.Now);
            context.SaveChanges();
        }
        public List<DonatiiDetalii> SelectDonationsByUserId(int id)
        {
            dbEntities context = new dbEntities();
            List<DonatiiDetalii> L=new List<DonatiiDetalii>();
            foreach (DonatiiDetalii D in context.SelectDonatiiFct(id))
            {
                L.Add(D);
            }
            return L;
        }

        public List<ComentariiDonatiiType> SelectDonatiiComentariiByDonatie(int id)
        {
            dbEntities context = new dbEntities();
            List<ComentariiDonatiiType> L = new List<ComentariiDonatiiType>();
            foreach (ComentariiDonatiiType comment in context.SelectComentariiDonatiiFct(id))
                L.Add(comment);
            return L;
        }

        public void InsertCommentDonations( string text, int FK_donatie, int FK_user)
        {
            dbEntities context = new dbEntities();
            ComentariiDonatii Comment = new ComentariiDonatii();
            Comment.TextComentariu = text;
            Comment.FK_Donatie = FK_donatie;
            Comment.FK_Usr = FK_user;
            Comment.Data = DateTime.Now;
            context.ComentariiDonatiis.AddObject(Comment);
            // ComentariiReal.CreateComentariiReal(id, text, FK_real, FK_user, DateTime.Now);
            context.SaveChanges();
        }
    }
}
