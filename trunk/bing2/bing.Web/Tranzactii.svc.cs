using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace bing.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Tranzactii" in code, svc and config file together.
    public class Tranzactii : ITranzactii
    {
        public void Test(int i)
        {
            using (dbEntities e = new dbEntities())
            {
                
                e.TryScor();
            }
        }
        public List<ProcedureUpgrades_Result> GetProceduraUpgrades(int i)
        {
            using (dbEntities e = new dbEntities())
            {
                return e.ProcedureUpgrades(i).ToList<ProcedureUpgrades_Result>();
            }
        }
        public List<ProceduraRealJudet_Result> GetProceduraReal(int i)
        {
            using (dbEntities e = new dbEntities())
            {
                return e.ProceduraRealJudet(i).ToList<ProceduraRealJudet_Result>();
            }
        }
        public List<HistoryPadure_Result> GetHistoryPadure()
        {
            using (dbEntities e = new dbEntities())
            {
                return e.HistoryPadure().ToList<HistoryPadure_Result>();
            }
        }
        public List<StiriProcedure_Result> GetStiri()
        {
            using (dbEntities e = new dbEntities())
            {
                return e.StiriProcedure().ToList<StiriProcedure_Result>();
            }
        }
        public List<HartaCampanii_Result> HartaCuCampanii()
        {
            using (dbEntities e = new dbEntities())
            {
                return e.HartaCampanii().ToList<HartaCampanii_Result>();
            }
        }
        public List<LoginFunction_Result> LoginUser(string nume, string passward)
        {
            using (dbEntities e = new dbEntities())
            {
                return e.LoginFunction(nume, passward).ToList<LoginFunction_Result>();
            }
        }
        public List<StatisticaAimal_Result> StatisticaAnimal(int id, int idRegiune)
        {
            using (dbEntities e = new dbEntities())
            {
                List<StatisticaAimal_Result> lista= e.StatisticaAimal(id, idRegiune).ToList<StatisticaAimal_Result>();
                return lista;
            }
        }
        public List<ProceduraDeces_Result1> PreiaDeces(int IDanimal,int IDuser)
        {
            using (dbEntities e = new dbEntities())
            {

                return e.ProceduraDeces2(IDanimal, IDuser).ToList<ProceduraDeces_Result1>();
            }
            
        }

        public void DoWork()
        {
        }
        public List<string> GetToateAnimalele()
        {
            return (from a in new dbEntities().Animales select a.Nume).ToList<string>();

        }
        public List<string> GetToateFirmele()
        {
            return (from a in new dbEntities().Firmes select a.Nume).ToList<string>();
        }
        public List<Tranzactie> gettranz(string user)
        {
            return new dbEntities().Tranzacties.Where(x => x.Cumparator == user).Take<Tranzactie>(30).ToList<Tranzactie>();
        }
        public List<TranzactiiCumparare> GetTranzactieCumparare()
        {
         List<TranzactiiCumparare> lista= new dbEntities().TranzactiiCumparares.Take<TranzactiiCumparare>(30).ToList<TranzactiiCumparare>();
         return lista;
        }
        public void AddTranzactie(string Nume,string animal,int numar,string numefirma,int pret,string vinde,string cumpara)
        {
            dbEntities db = new dbEntities();
            db.StoredProcedure1(Nume, animal, numefirma, DateTime.Now, numar, DateTime.Now, pret, vinde, cumpara);
           
        }
        public void AddCumparare(string numev,string numec, string numea, string numefirma, int pret,short numar,int id )
        {

            dbEntities db = new dbEntities();
            db.BagaLaMyTrades(numev, numec, numea, numefirma, "lala", DateTime.Now, pret, numar, id);
        }
        public List<TranzactiiCumparare> Cauta(string regiune, string keyward, int cv, bool pretquantity, bool ascdsc, bool enull)
        {
            #region cumparare
            List<TranzactiiCumparare> t=new List<TranzactiiCumparare>();
            using (dbEntities db = new dbEntities())
            {
                
                if (enull == true)
                {
                    var b = from a in db.TranzactiiCumparares
                            where a.Regiune == regiune && a.Nume.Contains(keyward) && a.Vanzare=="1"
                            select a;
                    foreach (var c in b)
                        t.Add(c);
                    return t;
                }
                else
                {

                    if (pretquantity == true && ascdsc == true)
                    {
                        var b = from a in db.TranzactiiCumparares
                                where a.Regiune == regiune && a.Nume.Contains(keyward) && a.Vanzare == "1"
                                orderby a.Pret ascending
                                select a;
                        foreach (var c in b)
                            t.Add(c);
                        return t;
                    }
                    else if (pretquantity == false && ascdsc == true)
                    {
                        var b = from a in db.TranzactiiCumparares
                                where a.Regiune == regiune && a.Nume.Contains(keyward) && a.Vanzare == "1"
                                orderby a.Numar ascending
                                select a;
                        foreach (var c in b)
                            t.Add(c);
                        return t;
                    }
                    else if (pretquantity == false && ascdsc == false)
                    {
                        var b = from a in db.TranzactiiCumparares
                                where a.Regiune == regiune && a.Nume.Contains(keyward) && a.Vanzare == "1"
                                orderby a.Numar descending
                                select a;
                        foreach (var c in b)
                            t.Add(c);
                        return t;
                    }
                    else if (pretquantity == true && ascdsc == false)
                    {
                        var b = from a in db.TranzactiiCumparares
                                where a.Regiune == regiune && a.Nume.Contains(keyward) && a.Vanzare == "1"
                                orderby a.Pret descending
                                select a;
                        foreach (var c in b)
                            t.Add(c);
                        return t;
                    }
                }
            }
            #endregion
            return t; 
        
        }
        
    }
}
