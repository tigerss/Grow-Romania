using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace bing.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void updateAchievements(
            int userID, int hunger, int education, int equality, int mortality,
            int maternalHealth, int disease, int environment, int partnership
            );
        [OperationContract]
        void updateChallenge(int challengeID);
        [OperationContract]
        List<getPlantHistory_Result> getPlantHistoryFromDB(int userID, string imagine1);
        [OperationContract]
        List<getPlants_Result> getPlantsFromDB(int isFromPadure);
        [OperationContract]
        List<getChallenges_Result> getChallengesFromDB(int userID);
        [OperationContract]
        List<getAchievement_Result> getAchievementsFromDB(int userID);
        [OperationContract]
        List<getAnimalStats_Result> getAnimalHistoryFromDB(int user_id, string imagine1);
        [OperationContract]
        List<SelectAnimal_Result> GetAnimalFromDB(int isFromPadure);
      
        [OperationContract]
        Animale GetAnimalByID(int ID);
        [OperationContract]
        List<IstoricAnimalPadureForUserX> GetTop3IstoricAnimaleForUserX(int UserID, int AnimalID);
        
        [OperationContract]
        Usr GetUserByUsername(string username);
        [OperationContract]
        Usr GetUserByEmail(string mail);
        [OperationContract]
        Usr GetUserByUsernameAndPassword(string username, string Password);
        [OperationContract]
        bool RegisterUser(string firstname, string lastname, string username, string password, string email, string region);
    }
}
