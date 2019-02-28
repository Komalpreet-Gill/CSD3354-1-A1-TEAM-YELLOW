using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSD3354_1_A1_TEAM_YELLOW
{
    class CountrySide
    {
        Village Alst;
        Village Schvenig;
        Village Wessig;
        Village Maeland;
        Village Helmholtz;
        Village Badden;
        Village Uster;




        static void Main()
        {
            new CountrySide().Run();

        }






        public void TravelVillages(Village currentVillage)
        {
            if (Hugi.FoundAstrildge) return;

            Hugi.HugiJournal.Add(new JournalEntry(currentVillage.VillageName, currentVillage.distanceFromPreviousVillage));
            try
            {
                Console.WriteLine("I am in {0}", currentVillage.VillageName);
                if (currentVillage.isAstrildgeHere)
                {

                    Console.WriteLine("I found Dear Astrildge in {0}", currentVillage.VillageName);
                    Console.WriteLine("****Feeling Happy****");
                    Console.WriteLine("Astrildge, I walked {0} vika to find you. " +
                    "Will you marry me?", Hugi.CalculateDistanceWalked());
                    Hugi.FoundAstrildge = true;
                }
                TravelVillages(currentVillage.west);
                TravelVillages(currentVillage.east);

            }
            catch (NullReferenceException nre)
            {


            }
        }

        public void Announcement()
        {
            try
            {
                using (StreamReader sr = new StreamReader("C:/Test/Komal1.txt"))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }


        public void Run()
        {

            Alst = new Village("Alst", false);
            Schvenig = new Village("Schvenig", false);
            Wessig = new Village("Wessig", false);
            Maeland = new Village("Maeland", false);
            Helmholtz = new Village("Helmholtz", false);
            Badden = new Village("Badden", false);
            Uster = new Village("Uster", true);

            Alst.VillageSetup(0, Schvenig, Wessig);
            Schvenig.VillageSetup(14, Maeland, Helmholtz);
            Maeland.VillageSetup(9, null, null);
            Helmholtz.VillageSetup(28, null, null);
            Wessig.VillageSetup(19, Uster, Badden);
            Badden.VillageSetup(11, null, null);
            Uster.VillageSetup(28, null, null);


            this.TravelVillages(Alst);
            this.Announcement();
        }


    }

    class Village
    {
        public Village(string _villageName, bool _isAHere)
        {
            isAstrildgeHere = _isAHere;
            VillageName = _villageName;
        }

        public void VillageSetup(int _prevVillageDist, Village _westVillage, Village _eastVillage)
        {

            west = _westVillage;
            east = _eastVillage;
            distanceFromPreviousVillage = _prevVillageDist;
        }

        public string VillageName;
        public bool isAstrildgeHere;
        public Village west;
        public Village east;
        public int distanceFromPreviousVillage;
        //public int distanceToEastVillage;
        //public int distanceToWestVillage;

    }
    class JournalEntry
    {
        public JournalEntry(string note, int dist)
        {
            villageName = note;
            distanceTravelled = dist;
            HowFarToGetBack = distanceTravelled;
        }

        public int HowFarToGetBack = 0;
        private string villageName;
        private int distanceTravelled;
        public int getDistanceWalked()
        {
            return distanceTravelled;
        }
        public string getVillageName()
        {
            return villageName;
        }
    }
    class Hugi
    {
        private static JournalEntry je;
        public static bool FoundAstrildge = false;
        public static List<JournalEntry> HugiJournal = new List<JournalEntry>();

        public static int CalculateDistanceWalked()
        {
            int DistanceWalked = 0;
            foreach (var je in HugiJournal)
            {
                Console.WriteLine("{0} --  {1}*** --- {2} ", je.getDistanceWalked(), je.getVillageName(), je.HowFarToGetBack);
                DistanceWalked += je.getDistanceWalked() + je.HowFarToGetBack;
            }
            return DistanceWalked;
        }
    }

}
