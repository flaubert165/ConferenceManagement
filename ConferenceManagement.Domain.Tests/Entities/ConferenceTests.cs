using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Domain.Entities.Factories;
using Moq;

namespace ConferenceManagement.Domain.Tests.Entities
{
    [TestClass]
    public class ConferenceTests
    {
        [TestMethod]
        public void CreateNewTrack_Test()
        {
            var factoryMock = new Mock<ITrackFactory>();

            Tracker track = new TrackTwoSessions("TestTracker");
            factoryMock.Setup(factory => factory.CreateTrack("TestTracker")).Returns(track);

            Conference conference = new Conference(factoryMock.Object);
            conference.CreateNewTrack();

            factoryMock.VerifyAll();
        }
        
    }
}
