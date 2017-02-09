using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EntityFramework.Extensions;
using SportsBetting.Data;
using SportsBetting.Data.UnitOfWork;
using SportsBetting.Models;

namespace Update
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            var context = new SportsBettingContext();
            var xmlDoc = XDocument.Load(@"C:\Users\Home-PC\Desktop\are4.xml");

            var odds = from o in xmlDoc.Descendants("Odd")
                       select new
                       {
                           OddName = o.Attribute("Name").Value,
                           OriginId = Convert.ToInt32(o.Attribute("ID").Value),
                           OddValue = float.Parse(o.Attribute("Value").Value),
                           SpecialBetValue =
                               o.Attribute("SpecialBetValue") != null ? (float.Parse(o.Attribute("SpecialBetValue").Value)) : 0
                       };



            Console.WriteLine(HasPendingChanges(context));
            HasPendingChanges(context);




            Console.WriteLine(DateTime.Now);



            //  foreach (var o in odds)
            //  {
            //      context.Odds.Where(odd => odd.OriginId == o.OriginId).Update(odd => new Odd
            //      {
            //          OddValue = o.OddValue,
            //          SpecialBetValue = o.SpecialBetValue
            //      });
            //    //  context.SaveChanges();
            //  }
            //  context.SaveChanges();


            //    foreach (var o in odds)
            //    {
            //        Odd entity = context.Odds.Where(oo => oo.OriginId == o.OriginId).FirstOrDefault();
            //
            //        if (entity != null)
            //        {
            //            var parentBet =
            //                Convert.ToInt32(
            //                    xmlDoc.Descendants("Bet")
            //                        .Where(odd => odd.Descendants("Odd").Any())
            //                        .FirstOrDefault()
            //                        .Attribute("ID")
            //                        .Value);
            //            // var bet = context.Bets.Where(b => b.BettOriginId == parentBet).FirstOrDefault();
            //           
            //            //46707921
            //
            //        }
            //    }

            //  else
            //  {
            //      var parentBet = Convert.ToInt32(xmlDoc.Descendants("Bet").Where(odd => odd.Descendants("Odd").Any()).FirstOrDefault().Attribute("ID").Value);
            //      var bet = context.Bets.Where(b => b.BettOriginId == parentBet).FirstOrDefault();
            //
            //      Odd oddentity = new Odd
            //      {
            //          OddName = o.OddName,
            //          OddValue = o.OddValue,
            //          OriginId = o.OriginId,
            //          SpecialBetValue = o.SpecialBetValue,
            //          Bet = bet
            //      };
            //
            //      if (bet != null)
            //      {
            //          context.Odds.Add(oddentity);
            //          context.SaveChanges();
            //      }
            //
            //  }





            //  var sports = from sport in xmlDoc.Descendants("Sport")
            //               select new
            //               {
            //                   SportName = sport.Attribute("Name").Value,
            //                   SportOriginId = Convert.ToInt32(sport.Attribute("ID").Value),
            //                   Events = (from ev in sport.Descendants("Event")
            //                             select new
            //                             {
            //                                 EventName = ev.Attribute("Name").Value,
            //                                 EventOriginId = Convert.ToInt32(ev.Attribute("ID").Value),
            //                                 Matches = (from m in ev.Descendants("Match")
            //                                            select new
            //                                            {
            //                                                MatchName = m.Attribute("Name").Value,
            //                                                MatchOriginId = Convert.ToInt32(m.Attribute("ID").Value),
            //                                                StartDate = Convert.ToDateTime(m.Attribute("StartDate").Value),
            //                                                MatchType = m.Attribute("MatchType").Value,
            //                                                Bets = (from b in m.Descendants("Bet")
            //                                                        select new
            //                                                        {
            //                                                            BetName = b.Attribute("Name").Value,
            //                                                            BettOriginId = Convert.ToInt32(b.Attribute("ID").Value),
            //                                                            Odds = (from o in b.Descendants("Odd")
            //                                                                    select new
            //                                                                    {
            //                                                                        OddName = o.Attribute("Name").Value,
            //                                                                        OriginId = Convert.ToInt32(o.Attribute("ID").Value),
            //                                                                        OddValue = float.Parse(o.Attribute("Value").Value),
            //                                                                        SpecialBetValue =
            //                                                                            o.Attribute("SpecialBetValue") != null
            //                                                                                ? (float.Parse(o.Attribute("SpecialBetValue").Value))
            //                                                                                : 0
            //                                                                    })
            //                                                        })
            //                                            })
            //                             })
            //               };
            //   var start = DateTime.Now;
            //   Console.WriteLine(start);

            //   foreach (var s in sports)
            //   {
            //       var sportEntity = context.Sports.Where(ss => ss.SportOriginId == s.SportOriginId).FirstOrDefault();
            //
            //       if (sportEntity == null)
            //       {
            //           sportEntity = CreateSport(s.SportName, s.SportOriginId);
            //
            //           foreach (var ev in s.Events)
            //           {
            //               var eventa = CreateSportEvent(ev.EventName, ev.EventOriginId);
            //
            //               //     sportEntity.SportEvents.Add(eventa);
            //               eventa.Sport = sportEntity;
            //               context.SportEvents.Add(eventa);
            //
            //               foreach (var mm in ev.Matches)
            //               {
            //                   var match = CreateMatch(mm.MatchName, mm.MatchOriginId, mm.MatchType, mm.StartDate);
            //
            //                   //eventa.Matches.Add(match);
            //                   match.SportEvent = eventa;
            //                   context.Matches.Add(match);
            //
            //                   foreach (var b in mm.Bets)
            //                   {
            //                       var bet = CreateBet(b.BetName, b.BettOriginId);
            //                       bet.Match = match;
            //                       context.Bets.Add(bet);
            //
            //                       //     match.Bets.Add(bet);
            //
            //                       foreach (var o in b.Odds)
            //                       {
            //                           var odd = CreateOdd(o.OriginId, o.OddValue, o.OddName, o.SpecialBetValue);
            //
            //                           // bet.Odds.Add(odd);
            //                           odd.Bet = bet;
            //                           context.Odds.Add(odd);
            //                       }
            //                   }
            //               }
            //           }
            //
            //           context.Sports.Add(sportEntity);
            //           context.SaveChanges();
            //       }
            //       else
            //       {
            //           sportEntity.SportName = s.SportName;
            //           context.SaveChanges();
            //       }
            //   }
            //
            //   var end = DateTime.Now;
            //   Console.WriteLine(end);
        }
        //   private static Odd CreateOdd(int originId, float oddValue, string oddName, float SpecialValue)
        //   {
        //       Odd odd = new Odd
        //       {
        //           OriginId = originId,
        //           OddValue = oddValue,
        //           OddName = oddName,
        //           SpecialBetValue = SpecialValue
        //       };
        //       return odd;
        //   }
        //
        //   private static Bet CreateBet(string name, int originId)
        //   {
        //       Bet bet = new Bet
        //       {
        //           BetName = name,
        //           BettOriginId = originId
        //       };
        //       return bet;
        //   }
        //
        //   private static Match CreateMatch(string name, int originId, string matchType, DateTime startingDate)
        //   {
        //       Match match = new Match
        //       {
        //           MatchName = name,
        //           MatchOriginId = originId,
        //           MatchType = matchType,
        //           StartDate = startingDate
        //       };
        //       return match;
        //   }
        //
        //   private static SportEvent CreateSportEvent(string name, int originID)
        //   {
        //       SportEvent eventa = new SportEvent
        //       {
        //           EventName = name,
        //           EventOriginId = originID
        //       };
        //
        //       return eventa;
        //   }
        //
        //   private static Sport CreateSport(string name, int originID)
        //   {
        //       Sport sport = new Sport
        //       {
        //           SportName = name,
        //           SportOriginId = originID
        //       };
        //       return sport;
        //   }

        public static Boolean HasPendingChanges(SportsBettingContext context)
        {
            return context.ChangeTracker.Entries()
                          .Any(e => e.State == EntityState.Added
                                 || e.State == EntityState.Deleted
                                 || e.State == EntityState.Modified);
        }
    }
}
