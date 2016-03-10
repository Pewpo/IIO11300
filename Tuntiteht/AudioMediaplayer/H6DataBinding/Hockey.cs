using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H6DataBinding
{
    public static class TestHockeyBench
    {
        public static List<HockeyPlayer> Get3Players()
        {
            List<HockeyPlayer> players = new List<HockeyPlayer>();
            players.Add(new HockeyPlayer("Teemu Selänne", "8"));
            players.Add(new HockeyPlayer("Jarkko Immonen", "26"));
            players.Add(new HockeyPlayer("Ville Peltonen", "16"));
            return players;
        }
    }
    public class HockeyPlayer : INotifyPropertyChanged
    {   //properties
        private string name;
        public string Name
        {
        set
            {
                name = value;
                Notify("Name");
                Notify("NameAndNumber");
            }
            get
            {
                return name;
            }
        }
        private string number;



        public string Number
        {
            set
            {
                number = value;
                Notify("Number");
                Notify("NameAndNumber");
            }
            get
            {
                return number;
            }
        }
        public string NameAndNumber
        {
            get
            {
                return name + "#" + number;
            }
        }
        public HockeyPlayer()
        {

        }
        public HockeyPlayer(string name, string number)
        {
            this.name = name;
            this.number = number;
        }
        //rajapinnan (interfacen) toteutus
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string propName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
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
