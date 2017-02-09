using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;
using SportsBetting.Data;
using SportsBetting.Models;
using Timer = System.Timers.Timer;

namespace XmlLoading
{
    public static class Load
    {
        public static void Main()
        {

        }

        public static void StartLoadingTimer()
        {
            Timer timer = new Timer(6000);
            timer.Elapsed += async (sender, e) => LoadData();
            timer.Start();
            Console.Write("Press any key to exit... ");
            Console.ReadKey();
         
        }

        private static void LoadData()
        {
            var context = new SportsBettingContext();
            context.Configuration.AutoDetectChangesEnabled = false;

            var xmlDoc = XDocument.Load(@"http://vitalbet.net/sportxml");

            var sports = from sport in xmlDoc.Descendants("Sport")
                         select new
                         {
                             SportName = sport.Attribute("Name").Value,
                             SportOriginId = Convert.ToInt32(sport.Attribute("ID").Value),
                             Events = (from ev in sport.Descendants("Event")
                                       select new
                                       {
                                           EventName = ev.Attribute("Name").Value,
                                           EventOriginId = Convert.ToInt32(ev.Attribute("ID").Value),
                                           Matches = (from m in ev.Descendants("Match")
                                                      select new
                                                      {
                                                          MatchName = m.Attribute("Name").Value,
                                                          MatchOriginId = Convert.ToInt32(m.Attribute("ID").Value),
                                                          StartDate = Convert.ToDateTime(m.Attribute("StartDate").Value),
                                                          MatchType = m.Attribute("MatchType").Value,
                                                          Bets = (from b in m.Descendants("Bet")
                                                                  select new
                                                                  {
                                                                      BetName = b.Attribute("Name").Value,
                                                                      BettOriginId = Convert.ToInt32(b.Attribute("ID").Value),
                                                                      Odds = (from o in b.Descendants("Odd")
                                                                              select new
                                                                              {
                                                                                  OddName = o.Attribute("Name").Value,
                                                                                  OriginId = Convert.ToInt32(o.Attribute("ID").Value),
                                                                                  OddValue = float.Parse(o.Attribute("Value").Value),
                                                                                  SpecialBetValue =
                                                                                      o.Attribute("SpecialBetValue") != null
                                                                                          ? (float.Parse(o.Attribute("SpecialBetValue").Value))
                                                                                          : 0
                                                                              })
                                                                  })
                                                      })
                                       })
                         };

           
            foreach (var sp in sports)
            {
                Sport sport = new Sport
                {
                    SportName = sp.SportName,
                    SportOriginId = sp.SportOriginId
                };

                context.Sports.AddOrUpdate(spp => spp.SportOriginId);

                foreach (var ev in sp.Events)
                {
                    SportEvent eventa = new SportEvent();
                    eventa.EventName = ev.EventName;
                    eventa.EventOriginId = ev.EventOriginId;
                    eventa.Sport = sport;

                    context.SportEvents.AddOrUpdate(spe => spe.EventOriginId);

                    foreach (var mm in ev.Matches
                        .Where(m => m.StartDate >= DateTime.Now && m.StartDate <= DateTime.Now.AddDays(1) && m.Bets.Count() != 0))
                    {
                        Match match = new Match
                        {
                            MatchName = mm.MatchName,
                            MatchOriginId = mm.MatchOriginId,
                            MatchType = mm.MatchType,
                            StartDate = mm.StartDate,
                            SportEvent = eventa
                        };

                        context.Matches.AddOrUpdate(mat => mat.MatchOriginId);

                        foreach (var b in mm.Bets)
                        {
                            Bet bet = new Bet
                            {
                                BetName = b.BetName,
                                BettOriginId = b.BettOriginId,
                                Match = match,
                            };

                            context.Bets.AddOrUpdate(mb => mb.BettOriginId);


                            foreach (var o in b.Odds)
                            {
                                Odd odd = new Odd
                                {
                                    OriginId = o.OriginId,
                                    OddValue = o.OddValue,
                                    OddName = o.OddName,
                                    SpecialBetValue = o.SpecialBetValue,
                                    Bet = bet
                                };
                                context.Odds.AddOrUpdate(od => od.OriginId);
                            }
                        }
                    }
                }
            }
            context.SaveChanges();

        }
    }
}
