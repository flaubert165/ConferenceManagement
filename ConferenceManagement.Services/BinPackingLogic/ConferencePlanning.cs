using System;
using System.Collections.Generic;
using System.Linq;
using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Domain.Entities.Factories;
using ConferenceManagement.Domain.Services;

namespace ConferenceManagement.Services.BinPackingLogic
{
    public class ConferencePlanningService : IConferencePlanningService
    {
        #region BESTFIT APPROACH IMPLEMENTATION

        public Conference GreedyBestFitApproach(IEnumerable<Talk> talks)
        {
            talks = talks.OrderBy(talk => talk);
            
            Conference conference = new Conference(new TrackTwoSessionsFactory());

            foreach(Talk talk in talks)
            {
                Session bestSession = GetBestSessionBestFitApproach(conference.EnumerateSessions(), talk);

                if(bestSession == null)
                {
                    conference.CreateNewTrack();
                    bestSession = GetBestSessionBestFitApproach(conference.EnumerateSessions(), talk);
                }

                if(bestSession == null)
                {
                    throw new ArgumentException(string.Format("ErrorUnscheduledEvent", talk));
                }

                bestSession.AcceptEvent(talk);
            }
            return conference;
        }

        public Session GetBestSessionBestFitApproach(IEnumerable<Session> sessions, Talk talk)
        {
            Session bestFitSession = null;

            foreach(Session session in sessions)
            {
                if(session.CanAcceptEvent(talk))
                {
                    if (bestFitSession == null || session.TimeLeft() < bestFitSession.TimeLeft())
                    {
                        bestFitSession = session;
                    }
                }
            }

            return bestFitSession;
        }
        #endregion

        #region OTHER APPROACHS IMPLEMENTATIONS

        public Conference GreedyFirstFitApproach(IEnumerable<Talk> talks)
        {
            throw new System.NotImplementedException();
        }

        public Session GetBestSessionFirstFitApproach(IEnumerable<Session> sessions, Talk talk)
        {
            throw new System.NotImplementedException();
        }

        #endregion

    }
}