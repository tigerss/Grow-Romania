using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace bing.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {
        // Update Achievements where ID == userID
        public void updateAchievements(
            int userID, int hunger, int education, int equality, int mortality,
            int maternalHealth, int disease, int environment, int partnership
            )
        {
            using (dbEntities update = new dbEntities())
            {
                update.updateAchievements(
                    userID, hunger, education, equality, mortality,
                    maternalHealth, disease, environment, partnership
                    );
            }
        }

        // Update Challenge where ID == challengeID
        public void updateChallenge(int challengeID)
        {
            using (dbEntities update = new dbEntities())
            {
                update.updateChallenge(challengeID);
            }
        }

        // Retrieve plant history from database
        public List<getPlantHistory_Result> getPlantHistoryFromDB(int userID, string imagine1)
        {
            using (dbEntities select = new dbEntities())
            {
                return select.getPlantHistory(userID, imagine1).ToList<getPlantHistory_Result>();
            }
        }

        // Retrieve all plants images from the database
        public List<getPlants_Result> getPlantsFromDB(int isFromPadure)
        {
            using (dbEntities select = new dbEntities())
            {
                return select.getPlants(isFromPadure).ToList<getPlants_Result>();
            }
        }

        // Retrieve a list of challenges using the user's ID as parameter
        public List<getChallenges_Result> getChallengesFromDB(int userID)
        {
            using (dbEntities select = new dbEntities())
            {
                return select.getChallenges(userID).ToList<getChallenges_Result>();
            }
        }

        // Get Achievements from database using the user's ID
        public List<getAchievement_Result> getAchievementsFromDB(int userID)
        {
            using (dbEntities select = new dbEntities())
            {
                return select.getAchievement(userID).ToList<getAchievement_Result>();
            }
        }

        // Retrieve animal history from Database
        public List<getAnimalStats_Result> getAnimalHistoryFromDB(int user_id, string imagine1)
        {
            using (dbEntities select = new dbEntities())
            {
                return select.getAnimalStats(user_id, imagine1).ToList<getAnimalStats_Result>();
            }
        }

        // Retrieve all animal images
        public List<SelectAnimal_Result> GetAnimalFromDB(int isFromPadure)
        {
            using (dbEntities select = new dbEntities())
            {
                select.Connection.Open();
                return select.SelectAnimal(isFromPadure).ToList<SelectAnimal_Result>();
            }
        }
        /// <summary>
        /// Returneaza Animalul cu un anumit ID
        /// </summary>
        /// <param name="ID">ID Animal dorit</param>
        /// <returns>Un Animal</returns>
        public Animale GetAnimalByID(int ID)
        {
            return (from a in new dbEntities().Animales where a.ID==ID select a).ToArray<Animale>()[0];
        }
        /// <summary>
        /// Top 3 Istorice pt Meniu animalului si al Userului
        /// </summary>
        /// <param name="UserID">ID User</param>
        /// <param name="AnimalID">ID Animal</param>
        /// <returns>O lista de 3 elem</returns>
        public List<IstoricAnimalPadureForUserX> GetTop3IstoricAnimaleForUserX(int UserID, int AnimalID)
        {  
            return new dbEntities().IstoricAnimalPadureForUserXes.Where<IstoricAnimalPadureForUserX>(x=>x.AnimalID==AnimalID&&x.UsrID==UserID).Take<IstoricAnimalPadureForUserX>(3).ToList<IstoricAnimalPadureForUserX>();
        }
        public Usr GetUserByUsername(string username)
        {
            var aux = (from a in new dbEntities().Usrs where a.Usr1.ToLower() == username select a).ToArray<Usr>();
            if (aux.Length == 1) return aux[0];
            return null; ;
        }
        public Usr GetUserByEmail(string mail)
        {
            var aux = (from a in new dbEntities().Usrs where a.Mail.ToLower() == mail select a).ToArray<Usr>();
            if (aux.Length == 1) return aux[0];
            return null; ;
        }
        public Usr GetUserByUsernameAndPassword(string username, string Password)
        {
            var aux = new dbEntities().Usrs.Where<Usr>(x => x.Usr1 == username && x.Pass == Password).ToArray<Usr>();
            if (aux.Length == 1) return aux[0];
            return null; ;
        }
        public bool RegisterUser(string firstname, string lastname, string username, string password, string email, string region)
        {
            dbEntities db = new dbEntities();
            try
            {
                Usr u = new Usr() { Nume = lastname, Prenume = firstname, Usr1 = username, Pass = password, Mail = email, Data_Inreg = DateTime.Now, Data_LastLogIn = DateTime.Now, BaniDonati = 0, NrDonatii = 0, Scor = 10, Rank = "Rank1", IsForDelete = false };
                db.AddToUsrs(u);
                db.SaveChanges();
                //---
                int usrid = db.Usrs.Where<Usr>(x => x.Usr1 == username).ToArray<Usr>()[0].ID;
                Regiune r = new Regiune() { Nume = region, FK_User = usrid };
                db.AddToRegiunes(r);
                db.SaveChanges();
            }
            catch(Exception ex)
            { return false; }
            finally { db.Dispose(); }
            return true;
        }
    }
}
