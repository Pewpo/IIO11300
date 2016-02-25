using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H6DataBinding
{   public class HockeyPlayer
    {

    }
    public class HockeyTeam
    {
        #region PROPERTIES
        //HUOM! Public field ei kelpaa XAMLin bindauksessa, pitää olla Propery
        public string Name { get; set; }
        public string City { get; set; }
        #endregion
        #region CONSTRUCTORS
        public HockeyTeam()
        {
            Name = "";
            City = "None";
        }
        public HockeyTeam(string teamName, string cityName)
        {
            Name = teamName;
            City = cityName;
        }
        #endregion
        public override string ToString()
        {
            return Name + "@" + City;
        }
    }

    public class HockeyLeague
    {
        List<HockeyTeam> teams = new List<HockeyTeam>();
        //perustetaan SMLiiga
        #region CONSTRUCTORS
        public HockeyLeague()
        {
            teams.Add(new HockeyTeam("Ilves", "Tampere"));
            teams.Add(new HockeyTeam("JYP", "Jyväskylä"));
            teams.Add(new HockeyTeam("HIFK", "Helsinki"));
            teams.Add(new HockeyTeam("Kärpät", "Oulu"));
            teams.Add(new HockeyTeam("KALPA", "Kuopio"));
        }
        #endregion
        //metodi joka palauttaa liigan joukkueet
        public List<HockeyTeam> GetTeams()
        {
            return teams;
        }
    }
}
