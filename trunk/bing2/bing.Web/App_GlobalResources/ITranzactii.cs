using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace bing.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITranzactii" in both code and config file together.
    [ServiceContract]
    public interface ITranzactii
    {
        [OperationContract]
        List<ProcedureUpgrades_Result> GetProceduraUpgrades(int i);
        [OperationContract]
        List<ProceduraRealJudet_Result> GetProceduraReal(int i);
        [OperationContract]
        List<HistoryPadure_Result> GetHistoryPadure();
        [OperationContract]
        List<StiriProcedure_Result> GetStiri();
        [OperationContract]
        List<HartaCampanii_Result> HartaCuCampanii();
        [OperationContract]
        List<LoginFunction_Result> LoginUser(string nume, string passward);
        [OperationContract]
        List<StatisticaAimal_Result> StatisticaAnimal(int id, int idRegiune);
        
        [OperationContract]
        List<ProceduraDeces_Result1> PreiaDeces(int IDanimal, int IDuser);

         [OperationContract]
          void DoWork();
         [OperationContract]
         List<string> GetToateAnimalele();
         [OperationContract]
        List<string> GetToateFirmele();
         [OperationContract]
        List<Tranzactie> gettranz(string user);
         [OperationContract]
         List<TranzactiiCumparare> GetTranzactieCumparare();
         [OperationContract]
      void AddTranzactie(string Nume,string animal,int numar,string numefirma,int pret,string vinde,string cumpara);
         [OperationContract]
         void AddCumparare(string numev, string numec, string numea, string numefirma, int pret, short numar, int id);
         [OperationContract]
         List<TranzactiiCumparare> Cauta(string regiune, string keyward, int cv, bool ascdsc, bool pretquantity, bool enull);
    }
}
